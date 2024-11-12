using BLL.Services;
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
        private readonly GoodsService _goodsService;
        private readonly ShippingService _shippingService;
        private readonly ManagersService _managersService;

        public MainWindow(string userRole, int userId)
        {
            InitializeComponent();

            _usersDalEf = (App.ServiceProvider.GetService<UsersDalEf>());
            _managersDalEf = (App.ServiceProvider.GetService<ManagersDalEf>());
            _goodsDalEf = (App.ServiceProvider.GetService<GoodsDalEf>());
            _shippingDalEf = (App.ServiceProvider.GetService<ShippingDalEf>());
            _goodsService = (App.ServiceProvider.GetService< GoodsService>());
            DataContext = new MainViewModel(_shippingDalEf, _goodsDalEf, userId, userRole, _usersDalEf, _managersDalEf,_goodsService, _shippingService);
        }
    }
}
