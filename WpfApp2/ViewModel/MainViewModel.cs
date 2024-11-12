using BLL.IServices;
using BLL.Services;
using DAL.Repo;
using DAL.Service;
using DALEF.Conc;
using DTO.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Commands;

namespace WpfApp2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _userRole;
        private int _userId;

        private readonly ShippingService _sippingService;
        private readonly ManagersDalEf _managersDalEf;
        private readonly UsersDalEf _usersDalEf;
        private readonly ShippingDalEf _shippingDalEf;
        private readonly GoodsDalEf _goodsDalEf;
        private readonly GoodsService _goodsService;

        public MainViewModel(ShippingDalEf shippingDalEf,GoodsDalEf goodsDalEf, int userId, string userRole, UsersDalEf usersDalEf, ManagersDalEf managersDalEf, GoodsService goodsService, ShippingService shippingService)
        {
            _goodsDalEf = goodsDalEf;
            _shippingDalEf = shippingDalEf;
            _userRole = userRole;
            _sippingService = shippingService;
            _userId = userId;
            _usersDalEf = usersDalEf;
            _goodsService = goodsService;
            _managersDalEf = managersDalEf;
            SetAccessControl();

            GetAllItemsCommand = new RelayCommand(GetAllItems);
            GetItemByIdCommand = new RelayCommand(GetItemById);
            CreateNewItemCommand = new RelayCommand(CreateNewItem);
            UpdateItemByIdCommand = new RelayCommand(UpdateItemById);
            DeleteItemByIdCommand = new RelayCommand(DeleteItemById);
            CreateNewShippingCommand = new RelayCommand(CreateNewShipping);
            GetAllShippingsCommand = new RelayCommand(GetAllShippings);
            UpdateShippingByIdCommand = new RelayCommand(UpdateShippingById);
            DeleteShippingByIdCommand = new RelayCommand(DeleteShippingById);
            ApproveOrdersCommand = new RelayCommand(ApproveOrders);
            QuitCommand = new RelayCommand(QuitApplication);
        }

        private bool _isManager;
        public bool IsManager
        {
            get => _isManager;
            private set
            {
                _isManager = value;
                OnPropertyChanged();
            }
        }
        private List<Goods> _goodsList;
        public List<Goods> GoodsList
        {
            get => _goodsList;
            set
            {
                _goodsList = value;
                OnPropertyChanged();
            }
        }
        private void SetAccessControl()
        {
            IsManager = _userRole == "Admin";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand GetAllItemsCommand { get; set; }
        public ICommand GetItemByIdCommand { get; set; }
        public ICommand CreateNewItemCommand { get; set; }
        public ICommand UpdateItemByIdCommand { get; set; }
        public ICommand DeleteItemByIdCommand { get; set; }
        public ICommand CreateNewShippingCommand { get; set; }
        public ICommand GetAllShippingsCommand { get; set; }
        public ICommand UpdateShippingByIdCommand { get; set; }
        public ICommand DeleteShippingByIdCommand { get; set; }
        public ICommand ApproveOrdersCommand { get; set; }
        public ICommand QuitCommand { get; set; }

        private void GetAllItems()
        {
            GetAllItemsWindow getAllItemsWindow = new GetAllItemsWindow(_goodsDalEf);
            getAllItemsWindow.ShowDialog();
        }

        private void GetItemById()
        {
            GetItemByItemId getItemByItemId = new GetItemByItemId(_goodsDalEf,_goodsService);
            getItemByItemId.ShowDialog();
        }

        private void CreateNewItem()
        {
            CreateNewItemWindow createNewItemWindow = new CreateNewItemWindow(_userId, _goodsDalEf);
            createNewItemWindow.ShowDialog();
        }

        private void UpdateItemById()
        {
            UpdateItemByItemId updateItemByItem = new UpdateItemByItemId(_goodsDalEf);
            updateItemByItem.ShowDialog();
        }

        private void DeleteItemById()
        {
            DeleteItemByIntemId deleteItemByIntemId = new DeleteItemByIntemId(_goodsDalEf,_shippingDalEf);
            deleteItemByIntemId.ShowDialog();
        }

        private void CreateNewShipping()
        {
            CreateNewShippingWindow createNewShippingWindow = new CreateNewShippingWindow(_goodsDalEf,_shippingDalEf);
            createNewShippingWindow.ShowDialog();
        }

        private void GetAllShippings()
        {
            GetAllShippingsWindow getAllShippingsWindow = new GetAllShippingsWindow(_shippingDalEf);
            getAllShippingsWindow.ShowDialog();
        }

        private void UpdateShippingById()
        {
            UpdateShippingByIdWindow updateShippingByIdWindow = new UpdateShippingByIdWindow(_shippingDalEf,_sippingService);
            updateShippingByIdWindow.ShowDialog();
        }

        private void DeleteShippingById()
        {
            DeleteShippingByIdWindow deleteShippingByIdWindow = new DeleteShippingByIdWindow(_shippingDalEf);
            deleteShippingByIdWindow.ShowDialog();
        }

        private void ApproveOrders()
        {
            ApproveOrdersWindow approveOrdersWindow = new ApproveOrdersWindow(_shippingDalEf,_goodsDalEf, _userId);
            approveOrdersWindow.ShowDialog();
        }

        private void QuitApplication()
        {
        //   MainViewModel.Close();
        }
    }
}
