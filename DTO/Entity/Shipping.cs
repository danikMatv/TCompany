using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class Shipping
    {
        public int id { get; set; }
        public string start_adress { get; set; }
        public string destination { get; set; }
        public int goods_id { get; set; }
    }
}
