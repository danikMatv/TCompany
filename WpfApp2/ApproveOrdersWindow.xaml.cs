using DALEF.Conc;
using DTO.Entity;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class ApproveOrdersWindow : Window
    {
        int managerId;
        private readonly ShippingDalEf shippingDalEf;
        private readonly GoodsDalEf goodsDalEf;

        public ApproveOrdersWindow(ShippingDalEf shippingDalEf, GoodsDalEf goodsDalEf, int _managerId)
        {
            managerId = _managerId;
            InitializeComponent();
            this.shippingDalEf = shippingDalEf;
            this.goodsDalEf = goodsDalEf;

            showRelatedShippings();
        }

        private void showRelatedShippings()
        {
            List<Goods> relatedGoodsToManager = goodsDalEf.GetAllRelatedGoods(managerId);
            List<Shipping> shippingList = new List<Shipping>();

            foreach (var goods in relatedGoodsToManager)
            {
                var newShippings = shippingDalEf.GetShippingsByGoodsIdAndStatusNotAppreved(goods.id);
                shippingList.AddRange(newShippings);
            }

            ShippingDataGrid.ItemsSource = shippingList;
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                int shippingId = (int)button.Tag;

                var shippingToApprove = shippingDalEf.GetById(shippingId);
                if (shippingToApprove != null)
                {
                    shippingToApprove.status = "Approved";
                    shippingDalEf.Update(shippingId, shippingToApprove);
                }
                showRelatedShippings();
            }
        }
    }
}
