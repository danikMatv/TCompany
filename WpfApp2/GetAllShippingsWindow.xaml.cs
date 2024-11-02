using DALEF.Conc;
using System.Collections.Generic;
using System.Windows;
using DTO.Entity;

namespace WpfApp2
{
    public partial class GetAllShippingsWindow : Window
    {
        private readonly ShippingDalEf _shippingDalEf;

        public GetAllShippingsWindow(ShippingDalEf shippingDalEf)
        {
            _shippingDalEf = shippingDalEf;
            InitializeComponent();
            InitializeShippings();
        }

        private void InitializeShippings()
        {
            List<Shipping> shippings = _shippingDalEf.GetAll();
            ShippingsListBox.ItemsSource = shippings;
        }
    }
}
