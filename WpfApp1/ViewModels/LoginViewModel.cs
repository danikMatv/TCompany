//using System.ComponentModel;
//using System.Windows.Input;
//using DALEF.Conc;
//using DALEF.Mapping;

//namespace WpfApp1.ViewModels
//{
//    public class LoginViewModel : INotifyPropertyChanged
//    {
//        private readonly ManagersDalEf _managersService;
//        private string _email;
//        private string _password;
//        private string _message;

//        public string Email
//        {
//            get => _email;
//            set
//            {
//                _email = value;
//                OnPropertyChanged(nameof(Email));
//            }
//        }

//        public string Password
//        {
//            get => _password;
//            set
//            {
//                _password = value;
//                OnPropertyChanged(nameof(Password));
//            }
//        }

//        public string Message
//        {
//            get => _message;
//            set
//            {
//                _message = value;
//                OnPropertyChanged(nameof(Message));
//            }
//        }

//        public ICommand LoginCommand { get; }

//        public LoginViewModel(ManagersService managersService)
//        {
//            _managersService = managersService;
//            LoginCommand = new RelayCommand(Login);
//        }

//        private void Login()
//        {
//            var manager = _managersService.Login(Email, Password);
//            if (manager != null)
//            {
//                // Успішний логін, перейдіть до основного вікна
//                Message = $"Welcome {manager.First_Name}!";
//                // Тут можна відкрити нове вікно в залежності від ролі
//            }
//            else
//            {
//                Message = "Invalid email or password.";
//            }
//        }

//        public event PropertyChangedEventHandler PropertyChanged;
//        protected void OnPropertyChanged(string propertyName) =>
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//    }

//}
