using BLL.Services;
using DALEF.Conc;
using DTO.Entity;
using System;
using System.Windows;

namespace WpfApp2
{
    public partial class GetItemByItemId : Window
    {
        private readonly GoodsDalEf goodsDalEf;
        private readonly GoodsService goodsService; 

        public GetItemByItemId(GoodsDalEf _goodsDalEf, GoodsService _goodsService)
        {
            this.goodsService = _goodsService;
            this.goodsDalEf = _goodsDalEf;
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ItemIdTextBox.Text, out int itemId))
            {
                Goods goods = goodsService.GetById(itemId);

                if (goods != null)
                {
                    ItemDetailsTextBlock.Text = $"ID: {goods.id}\nName: {goods.name}\nPrice: {goods.price:C}\nManager ID: {goods.manager_id}";
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
