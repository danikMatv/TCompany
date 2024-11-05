using DALEF.Conc;
using DTO.Entity;
using System.ComponentModel;
using System.Text.RegularExpressions;
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
            _usersDalEf = usersDalEf;
            RegisterCommand = new RelayCommand(Register);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword) ||
                string.IsNullOrWhiteSpace(PhoneNumber) ||
                string.IsNullOrWhiteSpace(Email))
            {
                Message = "All fields are required.";
                return false;
            }

            if (Password != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                return false;
            }

            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Message = "Invalid email format.";
                return false;
            }

            if (!Regex.IsMatch(PhoneNumber, @"^\d{10}$"))
            {
                Message = "Phone number must be 10 digits.";
                return false;
            }

            return true;
        }

        private void Register()
        {
            if (!ValidateInputs())
                return;

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
                var managerResult = _managersDalEf.Create(manager);
                var userResult = _usersDalEf.Create(user);

                if (managerResult != null && userResult != null)
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
