using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    class Order
    {
        // 订单明细列表
        public List<OrderDetail> details = new List<OrderDetail>();

        public uint OrderId { get; set; }
        public Customer Customer { get; set; }

        //客户添加订单
        public void AddDetail(OrderDetail orderDetail)
        {
            details.Add(orderDetail);
        }

        // 构造函数
        public Order(uint orderId, Customer customer)
        {
            this.OrderId = orderId;
            this.Customer = customer;
        }

        // 删除订单
        public void RemoveDetails (uint goodsId)
        {
            details.RemoveAll(d => d.Id == goodsId);
        }

        public override string ToString()
        {
            string result = "======================================================================\n";
            Console.WriteLine("顾客信息:" + Customer);
            Console.WriteLine(Customer.Name + "顾客的所有订单:" + "\n");
            details.ForEach(od => Console.Write(od + "\n"));
            return  result + "\n";
        }

    }
}
