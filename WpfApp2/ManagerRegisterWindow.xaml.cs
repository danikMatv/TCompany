using DALEF.Conc;
using System.Windows;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    public partial class ManagerRegisterWindow : Window
    {
        private readonly ManagerRegisterViewModel _viewModel;

        public ManagerRegisterWindow(ManagersDalEf managersDalEf,UsersDalEf usersDalEf)
        {
            InitializeComponent();
            _viewModel = new ManagerRegisterViewModel(managersDalEf, usersDalEf);
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
