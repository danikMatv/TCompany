using System.Windows;
using WpfApp2.ViewModel;
using DALEF.Conc;

namespace WpfApp2
{
    public partial class StartWindow : Window
    {
        private readonly UsersDalEf _usersDalEf;

        public StartWindow(UsersDalEf usersDalEf)
        {
            InitializeComponent();
            _usersDalEf = usersDalEf;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginViewModel = new LoginViewModel(_usersDalEf);
            var loginWindow = new LoginWindow(loginViewModel);
            loginWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(_usersDalEf);
            registerWindow.Show();
        }
    }
}
