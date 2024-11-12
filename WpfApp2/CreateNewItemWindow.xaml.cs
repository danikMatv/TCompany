using BLL.Services;
using DALEF.Conc;
using DTO.Entity;
using System.Windows;

namespace WpfApp2
{
    public partial class CreateNewItemWindow : Window
    {
        private readonly GoodsService goodsService;
        private readonly int _managerId;
        public CreateNewItemWindow(int managerId, GoodsService _goodsService)
        {
            _managerId = managerId;
            this.goodsService = _goodsService;
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string itemName = ItemNameTextBox.Text;
            string itemPriceText = ItemPriceTextBox.Text;

            if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(itemPriceText))
            {
                MessageBox.Show("Please enter both item name and item price.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(itemPriceText, out decimal itemPrice))
            {
                MessageBox.Show("Invalid price format. Please enter a valid number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var goods = new Goods()
            {
                manager_id = _managerId,
                name = itemName,
                price = (double)itemPrice
            };

            var successfully = goodsService.Create(goods);
            if (successfully != null)
            {
                MessageBox.Show("New item created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create new item. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
