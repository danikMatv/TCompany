using DALEF.Conc;
using System.Windows;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    public partial class UserRegisterWindow : Window
    {
        private readonly UserRegisterViewModel _viewModel;

        public UserRegisterWindow(UsersDalEf usersDalEf)
        {
            InitializeComponent();
            _viewModel = new UserRegisterViewModel(usersDalEf);
            DataContext = _viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordBox.Password;
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.ConfirmPassword = ConfirmPasswordBox.Password;
        }
    }
}
