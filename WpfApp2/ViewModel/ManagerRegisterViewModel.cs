using DALEF.Conc;
using DTO.Entity;
using Microsoft.VisualBasic.Logging;
using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp2.Commands;

namespace WpfApp2.ViewModel
{
    public class ManagerRegisterViewModel : INotifyPropertyChanged
    {
        private readonly ManagersDalEf _managersDalEf;
        private readonly UsersDalEf _usersDalEf;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _confirmPassword;
        private string _phoneNumber;
        private string _email;
        private string _message;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
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

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
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

        public ManagerRegisterViewModel(ManagersDalEf managersDalEf, UsersDalEf usersDalEf)
        {
            _managersDalEf = managersDalEf;
            RegisterCommand = new RelayCommand(Register);
            _usersDalEf = usersDalEf;
        }

        private void Register()
        {
            if (Password != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                return;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            var manager = new Managers
            {
                first_Name = FirstName,
                last_Name = LastName,
                password = hashedPassword,
                phone_Number = PhoneNumber,
                email = Email
            };
            var user = new Users
            {
                name = FirstName,
                login = Email,
                hashed_password = hashedPassword,
                role = "Admin"
            };

            try
            {
                var result = _managersDalEf.Create(manager);
                var resultNew = _usersDalEf.Create(user);
                if (result != null && resultNew != null)
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
                Message = $"An error occurred during registration: {ex.Message} - Inner Exception: {ex.InnerException?.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
