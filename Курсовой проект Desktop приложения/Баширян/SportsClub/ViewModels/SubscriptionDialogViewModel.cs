using System;
using SportsClub.Models;

namespace SportsClub.ViewModels
{
    public class SubscriptionDialogViewModel : ViewModelBase
    {
        private string _name = string.Empty;
        private decimal _price;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now.AddMonths(1);
        private int? _maxVisits = 10;
        private bool _isActive = true;
        private int _clientId;

        public string Title { get; }



            public SubscriptionDialogViewModel(int clientId)
            {
                  Title = "Добавление абонементрв";
                  ClientId = clientId;
            }


        public SubscriptionDialogViewModel(Subscription subscription)
        {
            Title = "Редактирование абонемта";
            Name = subscription.Name;
            Price = subscription.Price;
            StartDate = subscription.StartDate;
            EndDate = subscription.EndDate;
            MaxVisits = subscription.MaxVisits;
            IsActive = subscription.IsActive;
            ClientId = subscription.ClientId;
        }

        public int ClientId
        {
            get => _clientId;
            set => SetField(ref _clientId, value);
        }

        public string Name
        {
            get => _name;
            set { SetField(ref _name, value); OnPropertyChanged(nameof(CanSave)); }
        }

        public decimal Price
        {
            get => _price;
            set { SetField(ref _price, value); OnPropertyChanged(nameof(CanSave)); }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set { SetField(ref _startDate, value); OnPropertyChanged(nameof(CanSave)); }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set { SetField(ref _endDate, value); OnPropertyChanged(nameof(CanSave)); }
        }

        public int? MaxVisits
        {
            get => _maxVisits;
            set => SetField(ref _maxVisits, value);
        }

        public bool IsActive
        {
            get => _isActive;
            set => SetField(ref _isActive, value);
        }

        public bool CanSave => !string.IsNullOrWhiteSpace(Name) && Price > 0 && EndDate > StartDate;

        public Subscription GetSubscription()
        {
            return new Subscription
            {
                ClientId = ClientId,
                Name = Name,
                Price = Price,
                StartDate = StartDate,
                EndDate = EndDate,
                MaxVisits = MaxVisits,
                UsedVisits = 0,
                IsActive = IsActive,
                PurchaseDate = DateTime.Now
            };
        }

        public void UpdateSubscription(Subscription subscription)
        {
            subscription.Name = Name;
            subscription.Price = Price;
            subscription.StartDate = StartDate;
            subscription.EndDate = EndDate;
            subscription.MaxVisits = MaxVisits;
            subscription.IsActive = IsActive;
        }
    }
}