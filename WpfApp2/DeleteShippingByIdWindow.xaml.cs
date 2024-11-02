using DALEF.Conc;
using DTO.Entity;
using System.Windows;

namespace WpfApp2
{
    public partial class DeleteShippingByIdWindow : Window
    {
        private readonly ShippingDalEf shippingDalEf;

        public DeleteShippingByIdWindow(ShippingDalEf _shippingDalEf)
        {
            InitializeComponent();
            this.shippingDalEf = _shippingDalEf;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ShippingIdTextBox.Text, out int shippingId))
            {
                Shipping shipping = shippingDalEf.GetById(shippingId);

                if (shipping != null)
                {
                    shippingDalEf.Delete(shippingId);
                    Shipping checkShippingIfExist = shippingDalEf.GetById(shippingId);

                    if (checkShippingIfExist == null)
                    {
                        MessageBox.Show("Shipping deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        ShippingDetailsTextBlock.Text = $"Shipping with ID {shippingId} has been deleted.";
                    }
                    else
                    {
                        MessageBox.Show("Error deleting shipping. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Shipping not found. Please enter a valid ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ShippingDetailsTextBlock.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
