using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_new
{
    [Serializable]
    public class OrderDetail
    {
        // 订单信息
        public uint Quantity { get; set; }
        public uint Id { get; set; }
        public Goods Goods { get; set; }
        public double TotalPrice { get; set; } // 总价格

        // 构造函数
        public OrderDetail()
        {

        }
        public OrderDetail(uint id, Goods goods, uint quantity)
        {
            this.Quantity = quantity;
            this.Id = id;
            this.Goods = goods;
            this.TotalPrice = this.Goods.Price * quantity;
        }



        public override string ToString()
        {
            return "商品信息:" + Goods + "\t" + "商品ID:" + Id + "\t" + "商品数量:" + Quantity + "\n";
        }
    }
}
