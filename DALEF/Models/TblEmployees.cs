namespace DALEF.Models
{
    public partial class TblEmployees
    {
        public int id { get; set; }
        public string? first_Name { get; set; } 
        public string? last_Name { get; set; } 
        public string? phone_Number { get; set; } 
        public string? position { get; set; } 
        public string? email { get; set; } 
        public string? password { get; set; } 
        public virtual ICollection<TblGoods> Goods { get; set; } = new List<TblGoods>();
    }
}
