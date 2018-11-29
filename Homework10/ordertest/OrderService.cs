using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using System.Data.Entity;

namespace ordertest {
    
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    public class OrderService {

        public void Add(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                //db.Order.Attach(order);
                //db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(int orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("Items").SingleOrDefault(o => o.Id == orderId);
                db.OrderItem.RemoveRange(order.Items);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.Items.ForEach(
                    item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public Order GetOrder(int Id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items").
                  SingleOrDefault(o => o.Id == Id);
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("items").ToList<Order>();
            }
        }


        public List<Order> QueryByCustormer(String custormer)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items")
                  .Where(o => o.Customer.Equals(custormer)).ToList<Order>();
            }
        }

        public List<Order> QueryByGoods(String product)
        {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("items")
                  .Where(o => o.Items.Where(
                    item => item.Product.Equals(product)).Count() > 0);
                return query.ToList<Order>();
            }
        }















        //private Dictionary<uint, Order> orderDict;

        //public OrderService() {
        //    orderDict = new Dictionary<uint, Order>();
        //}

        //public int AddOrder(Order order) {
        //    if (orderDict.ContainsKey(order.Id))
        //    {
        //        return 0; //添加失败

        //    }
        //    else
        //    {
        //        orderDict[order.Id] = order;
        //        return 1; //添加成功
        //    }
        //}

        //public void RemoveOrder(uint orderId) {
        //      orderDict.Remove(orderId);
        //}

        //public List<Order> QueryAllOrders() {
        //    return orderDict.Values.ToList();
        //}

        //public Order GetById(uint orderId) {
        //    if (orderDict.ContainsKey(orderId)){ 
        //        return orderDict[orderId];
        //    }
        //    return null;
        //}

        //public List<Order> QueryByGoodsName(string goodsName) {
        //    var query = orderDict.Values.Where(order =>
        //            order.Details.Where(d => d.Goods.Name == goodsName)
        //            .Count() > 0
        //        );
        //    return query.ToList();

        //}

        //public List<Order> QueryByCustomerName(string customerName) {
        //    var query=orderDict.Values
        //        .Where(order => order.Customer.Name == customerName);
        //    return query.ToList();
        //}

        //public List<Order> QueryByPrice(double price)
        //{
        //    var query = orderDict.Values
        //        .Where(order => order.Amount> price);
        //    return query.ToList();
        //}

        //public void UpdateCustomer(uint orderId, Customer newCustomer) {
        //    if (orderDict.ContainsKey(orderId)) {
        //        orderDict[orderId].Customer = newCustomer;
        //    } else {
        //        throw new Exception($"order-{orderId} is not existed!");
        //    }
        //}

        //public string Export()
        //{
        //    DateTime time = System.DateTime.Now;
        //    string fileName = "orders_" + time.Year + "_" + time.Month
        //        + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
        //        + "_" + time.Second + ".xml";
        //    Export(fileName);
        //    return fileName;
        //}

        //public void Export(String fileName)
        //{
        //    XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
        //    using (FileStream fs = new FileStream(fileName, FileMode.Create))
        //    {
        //        xs.Serialize(fs, orderDict.Values.ToList());
        //    }
        //}

        //    public List<Order> Import(string path)
        //{
        //    if (Path.GetExtension(path) != ".xml")
        //        throw new ArgumentException("It isn't a xml file!");
        //    XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
        //    List<Order> result = new List<Order>();

        //    using (FileStream fs = new FileStream(path, FileMode.Open))
        //    {
        //        List<Order> temp = (List<Order>)xs.Deserialize(fs);
        //        temp.ForEach(order =>
        //        {
        //            if (!orderDict.Keys.Contains(order.Id))
        //            {
        //                orderDict[order.Id] = order;
        //                result.Add(order);
        //            }
        //        });
        //    }
        //    return result;
        //}
    }
}
