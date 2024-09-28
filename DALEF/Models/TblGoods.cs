namespace DALEF.Models
{
    public partial class TblGoods
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; } = 0;
        public int manager_id { get; set; }
        public virtual TblEmployees Employees { get; set; }
        public virtual ICollection<TblShipping> TblShippings { get; set; } = new List<TblShipping>();
    }
}
