using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using SportsClub.Data;
using SportsClub.Models;
using SportsClub.Services;
using SportsClub.Views;

namespace SportsClub.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly GymDbContext _context;
        private readonly DialogService _dialogService;

        private ObservableCollection<Client> _clients = new();
        private ObservableCollection<Subscription> _subscriptions = new();
        private ObservableCollection<Visit> _visits = new();

        private Client? _selectedClient;
        private Subscription? _selectedSubscription;
        private Visit? _selectedVisit;
        private string _searchText = string.Empty;

        public MainWindowViewModel(Window parent)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GymDbContext>();
            optionsBuilder.UseSqlite("Data Source=sportsclub.db");
            _context = new GymDbContext(optionsBuilder.Options);
            _context.Database.EnsureCreated();

            _dialogService = new DialogService(parent);

            LoadClients();

            AddClientCommand = new RelayCommand(async () => await AddClient(), () => true);
            EditClientCommand = new RelayCommand(async () => await EditClient(), () => SelectedClient != null);
            DeleteClientCommand = new RelayCommand(DeleteClient, () => SelectedClient != null);

            AddSubscriptionCommand = new RelayCommand(async () => await AddSubscription(), () => SelectedClient != null);
            EditSubscriptionCommand = new RelayCommand(async () => await EditSubscription(), () => SelectedSubscription != null);
            DeleteSubscriptionCommand = new RelayCommand(DeleteSubscription, () => SelectedSubscription != null);

            AddVisitCommand = new RelayCommand(AddVisit, () => SelectedClient != null && SelectedSubscription != null);
            DeleteVisitCommand = new RelayCommand(DeleteVisit, () => SelectedVisit != null);

            SearchCommand = new RelayCommand(Search);
            RefreshCommand = new RelayCommand(Refresh);
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => SetField(ref _clients, value);
        }

        public ObservableCollection<Subscription> Subscriptions
        {
            get => _subscriptions;
            set => SetField(ref _subscriptions, value);
        }

        public ObservableCollection<Visit> Visits
        {
            get => _visits;
            set => SetField(ref _visits, value);
        }

        public Client? SelectedClient
        {
            get => _selectedClient;
            set
            {
                SetField(ref _selectedClient, value);
                LoadSubscriptionsForClient();
                LoadVisitsForClient();
                RefreshCommands();
            }
        }

        public Subscription? SelectedSubscription
        {
            get => _selectedSubscription;
            set { SetField(ref _selectedSubscription, value); RefreshCommands(); }
        }

        public Visit? SelectedVisit
        {
            get => _selectedVisit;
            set { SetField(ref _selectedVisit, value); RefreshCommands(); }
        }

        public string SearchText
        {
            get => _searchText;
            set => SetField(ref _searchText, value);
        }

        public RelayCommand AddClientCommand { get; }
        public RelayCommand EditClientCommand { get; }
        public RelayCommand DeleteClientCommand { get; }
        public RelayCommand AddSubscriptionCommand { get; }
        public RelayCommand EditSubscriptionCommand { get; }
        public RelayCommand DeleteSubscriptionCommand { get; }
        public RelayCommand AddVisitCommand { get; }
        public RelayCommand DeleteVisitCommand { get; }
        public RelayCommand SearchCommand { get; }
        public RelayCommand RefreshCommand { get; }

        private void RefreshCommands()
        {
            AddClientCommand.RaiseCanExecuteChanged();
            EditClientCommand.RaiseCanExecuteChanged();
            DeleteClientCommand.RaiseCanExecuteChanged();
            AddSubscriptionCommand.RaiseCanExecuteChanged();
            EditSubscriptionCommand.RaiseCanExecuteChanged();
            DeleteSubscriptionCommand.RaiseCanExecuteChanged();
            AddVisitCommand.RaiseCanExecuteChanged();
            DeleteVisitCommand.RaiseCanExecuteChanged();
        }

        private void LoadClients()
        {
            var clients = _context.Clients.OrderBy(c => c.FullName).ToList();
            Clients.Clear();
            foreach (var c in clients) Clients.Add(c);
        }

        private void LoadSubscriptionsForClient()
        {
            Subscriptions.Clear();
            if (SelectedClient == null) return;

            var subs = _context.Subscriptions
                .Where(s => s.ClientId == SelectedClient.Id)
                .OrderByDescending(s => s.StartDate)
                .ToList();

            foreach (var s in subs) Subscriptions.Add(s);
        }

        private void LoadVisitsForClient()
        {
            Visits.Clear();
            if (SelectedClient == null) return;

            var visits = _context.Visits
                .Where(v => v.ClientId == SelectedClient.Id)
                .OrderByDescending(v => v.VisitDate)
                .ToList();

            foreach (var v in visits) Visits.Add(v);
        }

        private async Task AddClient()
        {
            var dialog = new ClientDialog();
            var vm = new ClientDialogViewModel();
            dialog.DataContext = vm;

            var result = await _dialogService.ShowDialog<bool>(dialog);
            if (result && vm.CanSave)
            {
                var client = vm.GetClient();
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                Clients.Add(client);
                SelectedClient = client;
            }
        }

        private async Task EditClient()
        {
            if (SelectedClient == null) return;

            var dialog = new ClientDialog();
            var vm = new ClientDialogViewModel(SelectedClient);
            dialog.DataContext = vm;

            var result = await _dialogService.ShowDialog<bool>(dialog);
            if (result && vm.CanSave)
            {
                vm.UpdateClient(SelectedClient);
                _context.Clients.Update(SelectedClient);
                await _context.SaveChangesAsync();
                Refresh();
            }
        }

        private void DeleteClient()
        {
            if (SelectedClient == null) return;

            var hasSubs = _context.Subscriptions.Any(s => s.ClientId == SelectedClient.Id);
            if (hasSubs) return;

            _context.Clients.Remove(SelectedClient);
            _context.SaveChanges();
            Clients.Remove(SelectedClient);
            SelectedClient = null;
        }

        private async Task AddSubscription()
        {
            if (SelectedClient == null) return;

            var dialog = new SubscriptionDialog();
            var vm = new SubscriptionDialogViewModel(SelectedClient.Id);
            dialog.DataContext = vm;

            var result = await _dialogService.ShowDialog<bool>(dialog);
            if (result && vm.CanSave)
            {
                var sub = vm.GetSubscription();
                _context.Subscriptions.Add(sub);

                SelectedClient.TotalSpent += sub.Price;
                UpdateDiscount(SelectedClient);
                _context.Clients.Update(SelectedClient);

                await _context.SaveChangesAsync();
                LoadSubscriptionsForClient();
                Refresh();
            }
        }

        private async Task EditSubscription()
        {
            if (SelectedSubscription == null) return;

            var dialog = new SubscriptionDialog();
            var vm = new SubscriptionDialogViewModel(SelectedSubscription);
            dialog.DataContext = vm;

            var result = await _dialogService.ShowDialog<bool>(dialog);
            if (result && vm.CanSave)
            {
                vm.UpdateSubscription(SelectedSubscription);
                _context.Subscriptions.Update(SelectedSubscription);
                await _context.SaveChangesAsync();
                LoadSubscriptionsForClient();
            }
        }

        private void DeleteSubscription()
        {
            if (SelectedSubscription == null) return;

            var hasVisits = _context.Visits.Any(v => v.SubscriptionId == SelectedSubscription.Id);
            if (hasVisits) return;

            _context.Subscriptions.Remove(SelectedSubscription);
            _context.SaveChanges();

            if (SelectedClient != null)
            {
                SelectedClient.TotalSpent -= SelectedSubscription.Price;
                UpdateDiscount(SelectedClient);
                _context.Clients.Update(SelectedClient);
                _context.SaveChanges();
            }

            Subscriptions.Remove(SelectedSubscription);
        }

        private void AddVisit()
        {
            if (SelectedClient == null || SelectedSubscription == null) return;

            if (!SelectedSubscription.IsActive ||
                SelectedSubscription.EndDate < DateTime.Now ||
                (SelectedSubscription.MaxVisits.HasValue &&
                 SelectedSubscription.UsedVisits >= SelectedSubscription.MaxVisits.Value))
            {
                return;
            }

            var visit = new Visit
            {
                ClientId = SelectedClient.Id,
                SubscriptionId = SelectedSubscription.Id,
                VisitDate = DateTime.Now
            };

            _context.Visits.Add(visit);
            SelectedSubscription.UsedVisits += 1;

            if (SelectedSubscription.MaxVisits.HasValue &&
                SelectedSubscription.UsedVisits >= SelectedSubscription.MaxVisits.Value)
            {
                SelectedSubscription.IsActive = false;
            }

            _context.Subscriptions.Update(SelectedSubscription);
            _context.SaveChanges();

            LoadVisitsForClient();
            LoadSubscriptionsForClient();
        }

        private void DeleteVisit()
        {
            if (SelectedVisit == null) return;

            _context.Visits.Remove(SelectedVisit);

            var sub = _context.Subscriptions.FirstOrDefault(s => s.Id == SelectedVisit.SubscriptionId);
            if (sub != null)
            {
                sub.UsedVisits = Math.Max(0, sub.UsedVisits - 1);
                sub.IsActive = true;
                _context.Subscriptions.Update(sub);
            }

            _context.SaveChanges();
            Visits.Remove(SelectedVisit);
            LoadSubscriptionsForClient();
        }

        private void UpdateDiscount(Client client)
        {
            if (client.TotalSpent >= 10000) client.DiscountPercent = 15;
            else if (client.TotalSpent >= 5000) client.DiscountPercent = 10;
            else if (client.TotalSpent >= 2000) client.DiscountPercent = 5;
            else client.DiscountPercent = 0;
        }

        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Refresh();
                return;
            }

            var s = SearchText.ToLower();
            var clients = _context.Clients
                .Where(c => c.FullName.ToLower().Contains(s) ||
                            c.Phone.Contains(SearchText) ||
                            (c.Email != null && c.Email.ToLower().Contains(s)))
                .OrderBy(c => c.FullName)
                .ToList();

            Clients.Clear();
            foreach (var c in clients) Clients.Add(c);
        }

        private void Refresh()
        {
            LoadClients();
            LoadSubscriptionsForClient();
            LoadVisitsForClient();
        }
    }
}