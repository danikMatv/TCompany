using DALEF.Conc;
using DTO.Entity;
using System;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for CreateNewShippingWindow.xaml
    /// </summary>
    public partial class CreateNewShippingWindow : Window
    {
        private readonly GoodsDalEf goodsDalEf;
        private readonly ShippingDalEf shippingDalEf;

        public CreateNewShippingWindow(GoodsDalEf _goodsDalEf, ShippingDalEf _shippingDalEf)
        {
            this.shippingDalEf = _shippingDalEf;
            this.goodsDalEf = _goodsDalEf;
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string destination = ItemNameTextBox.Text;
            string startAddress = ItemPriceTextBox.Text;
            if (!int.TryParse(ItemIdTextBox.Text, out int goodsId))
            {
                MessageBox.Show("Please enter a valid Goods ID.");
                return;
            }

            string status = "Waiting for approval";
            DateTime startDate = DateTime.Now;
            DateTime destinationDate = DateTime.Now.AddDays(2);

            if (string.IsNullOrWhiteSpace(destination) || string.IsNullOrWhiteSpace(startAddress))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var newShipping = new Shipping
            {
                destination = destination,
                start_adress = startAddress,
                goods_id = goodsId,
                status = status,
                start_date = startDate,
                destination_date = destinationDate
            };
            
            shippingDalEf.Create(newShipping); 
            MessageBox.Show("Shipping created successfully.");
            this.Close();
        }
    }
}
