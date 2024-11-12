using BLL.Services;
using DALEF.Conc;
using DTO.Entity;
using System;
using System.Windows;

namespace WpfApp2
{
    public partial class UpdateShippingByIdWindow : Window
    {
        private readonly ShippingDalEf shippingDalEf;
        private readonly ShippingService shippingService;
        public UpdateShippingByIdWindow(ShippingDalEf _shippingDalEf,ShippingService _shippingService)
        {
            this.shippingDalEf = _shippingDalEf;
            this.shippingService = _shippingService;
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ShippingIdTextBox.Text, out int id))
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string startAddress = StartAddressTextBox.Text;
            if (string.IsNullOrWhiteSpace(startAddress))
            {
                MessageBox.Show("Please enter the start address.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string destination = DestinationTextBox.Text;
            if (string.IsNullOrWhiteSpace(destination))
            {
                MessageBox.Show("Please enter the destination.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Shipping shipping = shippingService.GetById(id);
            if (shipping == null)
            {
                MessageBox.Show("Shipping record not found. Please enter a valid ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            shipping.start_adress = startAddress;
            shipping.destination = destination;
            shippingDalEf.Update(id, shipping);
            MessageBox.Show("Shipping updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
