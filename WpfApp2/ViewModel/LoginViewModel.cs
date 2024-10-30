using System.ComponentModel;
using DALEF.Conc;
using System.Windows.Input;
using System.Windows;
using WpfApp2.Commands;
using DTO.Entity;

namespace WpfApp2.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UsersDalEf _usersDalEf;
        private string _email;
        private string _password;
        private string _message;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
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

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(UsersDalEf usersDalEf)
        {
            _usersDalEf = usersDalEf;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            try
            {
                var users = _usersDalEf.login(Email, Password);
                if (users != null)
                {
                    Message = $"Welcome {users.name}!";

                    if (users.role == "Admin" || users.role == "User")
                    {
                        var mainWindow = new MainWindow();
                        mainWindow.Show();

                        Application.Current.Windows[0].Close();
                    }
                    else
                    {
                        Message = "Access denied.";
                    }
                }
                else
                {
                    Message = "Invalid email or password.";
                }
            }
            catch (Exception ex)
            {
                Message = "An error occurred during login.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
