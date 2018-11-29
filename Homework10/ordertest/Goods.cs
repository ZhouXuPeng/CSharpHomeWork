using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ordertest
{
    public class Goods
    {
        [Key]
        public int IdGoods { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
