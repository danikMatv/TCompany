using DALEF.Conc;
using DTO.Entity;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp2
{
    public partial class GetAllItemsWindow : Window
    {
        private readonly GoodsDalEf _goodsDalEf;

        public GetAllItemsWindow(GoodsDalEf goodsDalEf)
        {
            _goodsDalEf = goodsDalEf;
            InitializeComponent();
            InitializeItems();
        }

        private void InitializeItems()
        {
            List<Goods> goods = _goodsDalEf.GetAll();
            GoodsListBox.ItemsSource = goods;
        }
    }
}
