using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ordertest
{
    public class OrderDetail
    {
        [Key]
        public int IdOderDetail { get; set; }
        public string Goods { get; set; }
        public int Quantity { get; set; }
    }
}
