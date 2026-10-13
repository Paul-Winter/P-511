using System;
using SportsClub.Models;

namespace SportsClub.ViewModels
{
    public class ClientDialogViewModel : ViewModelBase
    {
        private string _fullName = string.Empty;
        private string _phone = string.Empty;
        private string _email = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;

        public string Title { get; }

        public ClientDialogViewModel()
        {
            Title = "Добавление клиента";
        }

        public ClientDialogViewModel(Client client)
        {
            Title = "Редактирование клиента";
            FullName = client.FullName;
            Phone = client.Phone;
            Email = client.Email ?? string.Empty;
            Login = client.Login;
        }

        public string FullName
        {
            get => _fullName;
            set { SetField(ref _fullName, value); OnPropertyChanged(nameof(CanSave)); }
        }

        public string Phone
        {
            get => _phone;
            set { SetField(ref _phone, value); OnPropertyChanged(nameof(CanSave)); }
        }

        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        public string Login
        {
            get => _login;
            set { SetField(ref _login, value); OnPropertyChanged(nameof(CanSave)); }
        }

        public string Password
        {
            get => _password;
            set => SetField(ref _password, value);
        }

        public bool CanSave => !string.IsNullOrWhiteSpace(FullName)
                            && !string.IsNullOrWhiteSpace(Phone)
                            && !string.IsNullOrWhiteSpace(Login);

        public Client GetClient()
        {
            return new Client
            {
                FullName = FullName,
                Phone = Phone,
                Email = string.IsNullOrWhiteSpace(Email) ? null : Email,
                Login = Login,
                PasswordHash = string.IsNullOrWhiteSpace(Password) ? "default_hash" : Password,
                RegistrationDate = DateTime.Now
            };
        }

        public void UpdateClient(Client client)
        {
            client.FullName = FullName;
            client.Phone = Phone;
            client.Email = string.IsNullOrWhiteSpace(Email) ? null : Email;
            client.Login = Login;
        }
    }
}