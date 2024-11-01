using System.Windows;
using WpfApp2.ViewModel;
using DALEF.Conc;

namespace WpfApp2
{
    public partial class RegisterWindow : Window
    {
        private readonly UsersDalEf _usersDalEf;
        private readonly ManagersDalEf _managersDalEf;

        public RegisterWindow(UsersDalEf usersDalEf, ManagersDalEf managersDalEf)
        {
            InitializeComponent();
            _usersDalEf = usersDalEf;
            _managersDalEf = managersDalEf;
        }


        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserRegisterWindow userRegisterWindow = new UserRegisterWindow(_usersDalEf);
            userRegisterWindow.Show();
            this.Close();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerRegisterWindow managerRegisterWindow = new ManagerRegisterWindow(_managersDalEf,_usersDalEf);
            managerRegisterWindow.Show();
            this.Close();
        }

    }
}
