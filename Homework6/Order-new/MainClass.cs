using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Order_new
{
    class MainClass
    {
        static void Main(string[] args)
        {
            // 客户信息
            Customer customer1 = new Customer(1, "周旭鹏");
            Customer customer2 = new Customer(2, "张三");

            //商品信息
            Goods cars = new Goods(1, "汽车", 10000);
            Goods ele_bike = new Goods(2, "电动车", 1000);
            Goods bike = new Goods(3, "自行车", 100);

            //订单明细（商品数量）
            OrderDetail orderDetails1 = new OrderDetail(1, cars, 3);
            OrderDetail orderDetails2 = new OrderDetail(2, ele_bike, 25);
            OrderDetail orderDetails3 = new OrderDetail(3, bike, 225);

            // 订单管理
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer1);

            // 订单管理(订单信息添加)
            order1.AddDetail(orderDetails1);
            order1.AddDetail(orderDetails2);
            order1.AddDetail(orderDetails3);
            order2.AddDetail(orderDetails2);
            order2.AddDetail(orderDetails3);

            //订单信息输出
            Console.Write(order1);
            Console.Write(order2);

            OrderService os = new OrderService();
            // 添加订单
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            // 删除订单
            os.RemoveOrder(3);

            os.QueryByCustmerName("周旭鹏"); // 查询订单（客户名称）
            os.QueryByGoodsName("汽车"); // 查询订单（商品名称）

            // 修改订单（修改客户信息）
            //os.UpdateCustmer(1, customer2);

            Console.WriteLine("修改后的订单为:" + "\n" + "===================================================");
            Console.Write(order1);//输出修改后的订单

            os.QueryByOverTirtyThousand(); //查询超过 3万 的订单




            /// XML 序列化 (存在bug，尚未解决)
            /// 
            try
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                string xmlFileName = "xmlOrder.xml";
                os.XmlSerializeExport(xmlser, xmlFileName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("所有对象序列化成功!");
            /// XML 反序列化
            Console.WriteLine("\n开始反序列化，并输出订单\n");
            List<Order> orders = new List<Order>();
            try
            {
                FileStream fs = new FileStream("xmlOrder.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                orders = os.XmlDeSerializeImport(xmlser, fs);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            foreach(Order or in orders)
            {
                Console.WriteLine(or);
            }
            Console.WriteLine("所有对象反序列化成功!");
        }
    }
}
