using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEF.Models
{
    public partial class TblUsers
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public string? role { get; set; }
    }
}
