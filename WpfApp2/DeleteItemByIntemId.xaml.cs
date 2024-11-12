using BLL.Services;
using DAL.Service;
using DALEF.Conc;
using DTO.Entity;
using System.Windows;

namespace WpfApp2
{
    public partial class DeleteItemByIntemId : Window
    {
        private readonly GoodsService goodsService;
        private readonly ShippingDalEf shippingDalEf;

        public DeleteItemByIntemId(ShippingDalEf _shippingDalEf, GoodsService _goodsService)
        {
            InitializeComponent();
            this.shippingDalEf = _shippingDalEf;
            this.goodsService = _goodsService;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ItemIdTextBox.Text, out int itemId))
            {
                Goods goods = goodsService.GetById(itemId);

                if (goods != null)
                {

                    List<Shipping> shippings = shippingDalEf.GetShippingsByGoodsId(itemId);
                    if (shippings != null) {
                        foreach (Shipping shippingToDelete in shippings)
                        {
                            shippingDalEf.Delete(shippingToDelete.id);
                        } 
                    }
                    List<Shipping> newShippings = shippingDalEf.GetShippingsByGoodsId(itemId);
                    goodsService.Delete(itemId);
                    Goods checkGoodsIfExist = goodsService.GetById(itemId);

                    if (checkGoodsIfExist == null)
                    {
                        MessageBox.Show("Item deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        ItemDetailsTextBlock.Text = $"Item with ID {itemId} has been deleted.";
                    }
                    else
                    {
                        MessageBox.Show("Error deleting item. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Item not found. Please enter a valid ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ItemDetailsTextBlock.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
