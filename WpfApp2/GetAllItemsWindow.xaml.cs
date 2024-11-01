using DALEF.Conc;
using DTO.Entity;
using System.Windows;

namespace WpfApp2
{
    public partial class GetAllItemsWindow : Window
    {
        private readonly GoodsDalEf goodsDalEf;
        public GetAllItemsWindow(GoodsDalEf goodsDalEf)
        {
            this.goodsDalEf = goodsDalEf;
            InitializeComponent();
        }

        private void InitializeItems() 
        {
        }
    }
}
