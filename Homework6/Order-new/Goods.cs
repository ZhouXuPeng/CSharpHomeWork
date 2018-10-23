using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_new
{
    [Serializable]
    public class Goods
    {
        // 商品信息
        private double price;
        public uint Id { get; set; }
        public string Name { get; set; }

        // 构造函数
        public Goods()
        {

        }
        public Goods(uint id, string name, double value)
        {
            this.Id = id;
            this.Name = name;
            this.Price = value;
        }

        // 判断价格是否合格
        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("价格必须 >= 0!");
                }
                price = value;
            }
        }

        // 重写ToString()
        public override string ToString()
        {
            return "商品名称:" + Name + "\t" + "商品ID:" + Id + "\t" + "商品价格:" + Price + "\n";
        }
    }
}
