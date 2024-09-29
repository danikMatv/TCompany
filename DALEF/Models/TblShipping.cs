namespace DALEF.Models
{
    public partial class TblShipping
    {
        public int id { get; set; }
        public string start_adress { get; set; }
        public string destination { get; set; }
        public int goods_id {  get; set; }
        public string status { get; set; } = "Waiting for approve";
        public DateTimeOffset start_date { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset destination_date { get; set; } = DateTimeOffset.Now.AddDays(1);
        public TblGoods Goods { get; set; }
    }
}
