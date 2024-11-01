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
        private readonly ManagersDalEf _managersDalEf;
        private readonly UsersDalEf _usersDalEf;
        private readonly ShippingDalEf _shippingDalEf;
        private readonly GoodsDalEf _goodsDalEf;

        public MainViewModel(ShippingDalEf shippingDalEf,GoodsDalEf goodsDalEf, int userId, string userRole, UsersDalEf usersDalEf, ManagersDalEf managersDalEf)
        {
            _goodsDalEf = goodsDalEf;
            _shippingDalEf = shippingDalEf;
            _userRole = userRole;
            _userId = userId;
            _usersDalEf = usersDalEf;
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
            IsManager = _userRole == "Admin"; // Якщо роль "Admin", доступ до функцій для менеджерів
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Команди для кнопок
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

        // Реалізації команд
        private void GetAllItems()
        {
            GoodsList = _goodsDalEf.GetAll();
        }

        private void GetItemById()
        {
            // Логіка для отримання товару за ID
        }

        private void CreateNewItem()
        {
            if (_goodsDalEf == null)
            {
                MessageBox.Show("Goods data access layer is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CreateNewItemWindow createNewItemWindow = new CreateNewItemWindow(_userId, _goodsDalEf);
            createNewItemWindow.ShowDialog();
        }

            private void UpdateItemById()
        {
            // Логіка для оновлення товару за ID
        }

        private void DeleteItemById()
        {
            // Логіка для видалення товару за ID
        }

        private void CreateNewShipping()
        {
            // Логіка для створення нової доставки
        }

        private void GetAllShippings()
        {
            // Логіка для отримання всіх доставок
        }

        private void UpdateShippingById()
        {
            // Логіка для оновлення доставки за ID
        }

        private void DeleteShippingById()
        {
            // Логіка для видалення доставки за ID
        }

        private void ApproveOrders()
        {
            // Логіка для підтвердження замовлень
        }

        private void QuitApplication()
        {
            // Логіка для виходу з програми
        }
    }
}
