using DALEF.Conc;
using DTO.Entity;
using System.Windows;

namespace WpfApp2
{
    public partial class UpdateItemByItemId : Window
    {
        private readonly GoodsDalEf goodsDalEf;
        public UpdateItemByItemId(GoodsDalEf _goodsDalEf)
        {
            this.goodsDalEf = _goodsDalEf;
            InitializeComponent();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ItemIdTextBox.Text, out int id))
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string itemName = ItemNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show("Please enter the item name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!double.TryParse(ItemPriceTextBox.Text, out double itemPrice))
            {
                MessageBox.Show("Invalid price format. Please enter a valid number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Goods goods = goodsDalEf.GetById(id);
            if (goods == null)
            {
                MessageBox.Show("Item not found. Please enter a valid ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            goods.name = itemName;
            goods.price = itemPrice;
            goodsDalEf.Update(id, goods);
            MessageBox.Show("Item updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
