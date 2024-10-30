using System.Windows;

namespace WpfApp2
{
    public partial class ManagerRegisterWindow : Window
    {
        public ManagerRegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            MessageBox.Show($"Manager registered with Email: {email}");
            this.Close();
        }
    }
}
