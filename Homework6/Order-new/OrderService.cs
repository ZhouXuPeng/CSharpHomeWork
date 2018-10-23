using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Order_new
{
    public class OrderService  /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    {
        // 创建索引
        private Dictionary<uint, Order> orderDict;

        // 构造函数
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        // 添加订单
        public void AddOrder(Order order)
        {
            orderDict[order.OrderId] = order;
        }

        // 删除订单
        public void RemoveOrder(uint orderId)
        {
            orderDict.Remove(orderId);
        }

        // 所有订单储存到列表中
        public List<Order> QueryAllOrder()
        {
            return orderDict.Values.ToList();
        }

        // 通过订单号查询
        public void QueryByOrderId(uint orderId)
        {
            Console.WriteLine("通过订单号查询到的结果为: ");
            Console.Write(orderDict[orderId]);
        }

        // 通过商品名称查询
        public void QueryByGoodsName(string goodsName)
        {
            /// 原来方法
            foreach (Order order in orderDict.Values)
            {
                foreach (OrderDetail od in order.details)
                {
                    if (od.Goods.Name == goodsName)
                    {
                        Console.WriteLine("通过商品名称查询到的结果为: ");
                        Console.Write(order);
                    }
                }
            }

            /// Linq 语句
            //var ors = from order in orderDict.Values where true select order;
            //foreach (Order order in ors)
            //{
            //    var ods = from od in order.details where od.Goods.Name == goodsName select od;
            //    if (ods != null)
            //    {
            //        Console.WriteLine("通过商品名称查询到的结果为: ");
            //        Console.Write(order);
            //    }
            //}
        }

        // 通过客户姓名查询
        public void QueryByCustmerName(string custmerName)
        {
            /// 原来方法
            //foreach(Order order in orderDict.Values)
            //{
            //    if(order.Customer.Name == custmerName)
            //    {
            //        Console.WriteLine("通过客户姓名查询到的结果为: ");
            //        Console.Write(order);
            //    }
            //}

            /// Linq 语句
            var ors = from or in orderDict.Values where true select or;
            var custNames = from cn in ors where cn.Customer.Name == custmerName select cn;
            foreach (Order n in custNames)
            {
                Console.WriteLine("通过客户姓名查询到的结果为: ");
                Console.Write(n);
            }
        }

        // 修改订单(客户)
        public void UpdateCustmer(uint orderId, Customer newCustmer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustmer;
            }
            else
            {
                Console.WriteLine("不存在此订单，修改失败!");
            }
        }

        // 查找超过 3万 的订单，并且输出
        public void QueryByOverTirtyThousand()
        {
            foreach (Order order in orderDict.Values)
            {
                foreach (OrderDetail od in order.details)
                {
                    if (od.TotalPrice >= 30000)
                    {
                        Console.WriteLine("查询超过 3万 的订单的结果为: ");
                        Console.Write(order);
                    }
                }
            }
        }

        // XML序列化
        public void XmlSerializeExport(XmlSerializer ser, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            ser.Serialize(fs, orderDict.Values.ToList());
            fs.Close();
        }

        // XML 反序列化
        public List<Order> XmlDeSerializeImport(XmlSerializer xmlser, FileStream fs)
        {
            //List<Order> ors = new List<Order>();
            if (fs.CanRead)
            {
                return (List<Order>)xmlser.Deserialize(fs);
            }
            return null;
        }
    }
}
