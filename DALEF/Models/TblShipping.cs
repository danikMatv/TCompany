namespace DALEF.Models
{
    public partial class TblShipping
    {
        public int id { get; set; }
        public string start_adress { get; set; }
        public string destination { get; set; }
        public int goods_id {  get; set; }
        public TblGoods Goods { get; set; }
    }
}
