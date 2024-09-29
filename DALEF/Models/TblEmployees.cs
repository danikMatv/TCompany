namespace DALEF.Models
{
    public partial class TblEmployees
    {
        public int id { get; set; }
        public string first_Name { get; set; } = null!;
        public string last_Name { get; set; }
        public string phone_Number { get; set; } = null!;
        public string position { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; }
        public virtual ICollection<TblGoods> Goods { get; set; } = new List<TblGoods>();
    }
}
