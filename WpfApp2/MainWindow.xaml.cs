using DALEF.Conc;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private readonly UsersDalEf _usersDalEf;
        private readonly ManagersDalEf _managersDalEf;
        private readonly GoodsDalEf _goodsDalEf;
        private readonly ShippingDalEf _shippingDalEf;

        public MainWindow(string userRole, int userId)
        {
            InitializeComponent();

            _usersDalEf = (App.ServiceProvider.GetService<UsersDalEf>());
            _managersDalEf = (App.ServiceProvider.GetService<ManagersDalEf>());
            _goodsDalEf = (App.ServiceProvider.GetService<GoodsDalEf>());
            _shippingDalEf = (App.ServiceProvider.GetService<ShippingDalEf>());

            DataContext = new MainViewModel(_shippingDalEf, _goodsDalEf, userId, userRole, _usersDalEf, _managersDalEf);
        }
    }
}
