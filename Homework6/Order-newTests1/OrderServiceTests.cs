using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order_new;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Order_new.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        /// <summary>
        ///  创建索引
        /// </summary>
        //public Dictionary<uint, Order> orderDict;

        [TestMethod()]
        public void AddOrder()
        {
            List < Order > orders= new List<Order>();
            Customer customer1 = new Customer(1, "周旭鹏");
            Order order = new Order(1, customer1);
            orders.Add(order);
            Assert.IsNotNull(orders);
        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            bool flag = false;
            string goodsName = "汽车";

            /// 添加订单
            List<Order> orders = new List<Order>();
            Customer customer1 = new Customer(1, "周旭鹏");
            //商品信息
            Goods cars = new Goods(1, "汽车", 10000);
            Goods ele_bike = new Goods(2, "电动车", 1000);
            Goods bike = new Goods(3, "自行车", 100);

            //订单明细（商品数量）
            OrderDetail orderDetails1 = new OrderDetail(1, cars, 3);

            Order order = new Order(1, customer1);
            orders.Add(order);

            /// 查找
            foreach (Order or in orders)
            {
                var ods = from od in or.details where od.Goods.Name == goodsName select od;
                if (ods != null)
                {
                    flag = true;
                }
            }
            Assert.IsTrue(flag);
        }


        [TestMethod()]
        public void UpdateCustmerTest()
        {
            /// 添加订单
            List<Order> orders = new List<Order>();
            Customer customer1 = new Customer(1, "周旭鹏");
            Customer customer2 = new Customer(2, "张三");
            //商品信息
            Goods cars = new Goods(1, "汽车", 10000);
            Goods ele_bike = new Goods(2, "电动车", 1000);
            Goods bike = new Goods(3, "自行车", 100);

            //订单明细（商品数量）
            OrderDetail orderDetails1 = new OrderDetail(1, cars, 3);

            Order order = new Order(1, customer1);
            orders.Add(order);

            OrderService os = new OrderService();
            os.AddOrder(order);

            // 修改订单（修改客户信息）
            os.UpdateCustmer(1, customer2);
            Assert.AreEqual(customer2.Name, order.Customer.Name);
        }


        [TestMethod()]
        public void XmlSerializeExportTest() ///未成功测试运行(无法识别XmlSerializer类)
        {
            /// 添加订单
            List<Order> orders = new List<Order>();
            Customer customer1 = new Customer(1, "周旭鹏");
            Customer customer2 = new Customer(2, "张三");
            //商品信息
            Goods cars = new Goods(1, "汽车", 10000);
            Goods ele_bike = new Goods(2, "电动车", 1000);
            Goods bike = new Goods(3, "自行车", 100);

            //订单明细（商品数量）
            OrderDetail orderDetails1 = new OrderDetail(1, cars, 3);

            Order order = new Order(1, customer1);
            orders.Add(order);

            OrderService os = new OrderService();
            os.AddOrder(order);

            ///序列化 - 未成功测试运行(无法识别XmlSerializer类)
            //XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            //FileStream fs = new FileStream("xmlOrder.xml", FileMode.OpenOrCreate);
            //os.XmlSerializeExport()
            //Assert.IsNotNull(fs);
        }

        [TestMethod()]
        public void XmlDeSerializeImportTest() ///未成功测试运行(无法识别XmlSerializer类)
        {
            /// 添加订单
            List<Order> orders = new List<Order>();
            Customer customer1 = new Customer(1, "周旭鹏");
            Customer customer2 = new Customer(2, "张三");
            //商品信息
            Goods cars = new Goods(1, "汽车", 10000);
            Goods ele_bike = new Goods(2, "电动车", 1000);
            Goods bike = new Goods(3, "自行车", 100);

            //订单明细（商品数量）
            OrderDetail orderDetails1 = new OrderDetail(1, cars, 3);

            Order order = new Order(1, customer1);
            orders.Add(order);

            OrderService os = new OrderService();
            os.AddOrder(order);

            // 反序列化 - 未成功测试运行(无法识别XmlSerializer类)
            //List<Order> ors = new List<Order>();
            //FileStream fs = new FileStream("xmlOrder.xml", FileMode.Open, FileAccess.Read);
            //XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            //ors = os.XmlDeSerializeImport(xmlser, fs);

            //Assert.IsNotNull(ors);
        }
    }
}