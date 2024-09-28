using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class Goods
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int manager_id { get; set; }
    }
}
