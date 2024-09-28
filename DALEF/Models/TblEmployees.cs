using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual ICollection<TblGoods> Goods { get; set; } = new List<TblGoods>();
    }
}
