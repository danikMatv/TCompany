using DALEF.Conc;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Commands;

namespace WpfApp2.ViewModel
{
    public class UserRegisterViewModel : INotifyPropertyChanged
    {
        private readonly UsersDalEf _usersDalEf;
        private string _name;
        private string _login;
        private string _password;
        private string _confirmPassword;
        private string _message;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ICommand RegisterCommand { get; }

        public UserRegisterViewModel(UsersDalEf usersDalEf)
        {
            _usersDalEf = usersDalEf;
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            if (Password != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                return;
            }

            try
            {
                var user = new Users
                {
                    name = Name,
                    login = Login,
                    password = Password,
                    role = "User"
                };

                var result = _usersDalEf.Create(user);
                if (result != null)
                {
                    Message = "Registration successful!";
                }
                else
                {
                    Message = "Registration failed.";
                }
            }
            catch (Exception ex)
            {
                Message = $"An error occurred during registration: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
