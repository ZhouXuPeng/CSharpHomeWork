using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_new
{
    public class Customer
    {
        //客户信息
        public uint Id { get; set; }
        public string Name { get; set; }

        //构造函数
        public Customer()
        {

        }
        public Customer(uint id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return "客户姓名:" + Name + "\t" + "客户ID:" + Id + "\n";
        }
    }
}
