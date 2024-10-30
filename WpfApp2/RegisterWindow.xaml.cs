using System.Windows;
using WpfApp2.ViewModel;
using DALEF.Conc;

namespace WpfApp2
{
    public partial class RegisterWindow : Window
    {
        private readonly UsersDalEf _usersDalEf;

        public RegisterWindow(UsersDalEf usersDalEf)
        {
            InitializeComponent();
            _usersDalEf = usersDalEf;
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserRegisterWindow userRegisterWindow = new UserRegisterWindow(_usersDalEf);
            userRegisterWindow.Show();
            this.Close();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerRegisterWindow managerRegisterWindow = new ManagerRegisterWindow();
            managerRegisterWindow.ShowDialog();
            this.Close();
        }
    }
}
