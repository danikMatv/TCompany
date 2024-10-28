using System.ComponentModel;
using DALEF.Conc;
using System.Windows.Input;
using WpfApp2.Commands;

namespace WpfApp2.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ManagersDalEf _managersService;
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
        public LoginViewModel(ManagersDalEf managersService)
        {
            _managersService = managersService;
            LoginCommand = new RelayCommand(Login);
        }
        private void Login()
        {
            try
            {
                var manager = _managersService.login(Email, Password);

                if (manager != null)
                {
                    Message = $"Welcome {manager.first_Name}!";
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
