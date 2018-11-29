using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ordertest
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public String Customer { get; set; }
        public DateTime CreateTime { get; set; }
        public List<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public Order(int id, string customer, DateTime createTime, List<OrderItem> items)
        {
            Id = id;
            Customer = customer;
            CreateTime = createTime;
            Items = items;
        }
    }
}
