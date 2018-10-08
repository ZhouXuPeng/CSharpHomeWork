using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    //订单
    interface Order
    {
        void AddOrder(int OrderNumber, string TradeName, string Customer);//添加订单
        void RemoveOrder(int element);//删除订单
        void ChangeOrder(int originated, int changed, int flag);//修改订单 （订单号 flag 为0）
        void ChangeOrder(string originated, string changed, int flag);//修改订单 （商品名称 flag 为1、客户 flag 为2）
        void InquriyOrder(int ordernumber, int flag);//查找并打印订单 （订单号 flag 为0）
        void InquriyOrder(string ordername, int flag);//查找并打印订单 （商品名称 flag 为1、客户 flag 为2）
        void OrderPrint();//打印全部订单
    }

    //订单服务
    public class OrderService : Order
    {
        //设置变量
        private int OrderNumber;
        private string TradeName;
        private string Customer;

        //储存订单订单
        List<int> OrderNumbers = new List<int> { }; //创建订单号数组
        List<string> TradeNames = new List<string> { }; //创建商品名数组
        List<string> Customers = new List<string> { }; //创建顾客数组

        //添加订单
        public void AddOrder(int OrderNumber, string TradeName, string Customer)
        {
            OrderNumbers.Add(OrderNumber);
            TradeNames.Add(TradeName);
            Customers.Add(Customer);
        }

        //删除订单
        public void RemoveOrder(int element)
        {
            element = element - 1;//向前推一个

            int sum = 0;
            foreach (int a in OrderNumbers)//获取数组长度
            {
                sum++;
            }

            int i = 0;
            for(int n = 0; n < sum; n++)
            {
                if(i == element)
                {
                    int b = i;
                    for (int a = 0; a < sum - 1 - element; a++)
                    {
                        OrderNumbers[b] = OrderNumbers[b + 1];
                        TradeNames[b] = TradeNames[b + 1];
                        Customers[b] = Customers[b + 1];
                        b++;
                    }
                    OrderNumbers[b] = 0;
                    TradeNames[b] = null;
                    Customers[b] = null;
                    break;
                }
                i++;
            }

        }


        //查询订单(按照订单号、商品名称、客户字段进行查询)
        public void InquriyOrder(int ordernumber, int flag)
        {
            //订单号查询 flag为 0
            if (flag == 0)
            {
                int i = 0;
                foreach(int n in OrderNumbers)
                {
                    if(n == ordernumber)
                    {
                        Console.Write("\n按照订单号查询结果为:\n" + "订单号:" + OrderNumbers[i] + "\n商品名称:" +
                            TradeNames[i] + "\n客户:" + Customers[i] + "\n");
                        break;
                    }
                    i++;
                }
            }
            else
            {
                Console.WriteLine("您输入的信息有误!");
            }
        }
        public void InquriyOrder(string ordername, int flag)
        {
            //商品名称查询 flag为 1
            if (flag == 1)
            {
                int i = 0;
                foreach (string n in TradeNames)
                {
                    if (n == ordername)
                    {
                        Console.Write("\n按照商品名称查询结果为:\n" + "订单号:" + OrderNumbers[i] + "\n商品名称:" +
                            TradeNames[i] + "\n客户:" + Customers[i] + "\n");

                        break;
                    }
                    i++;
                }
            }
            //客户查询 flag为 2
            else if (flag == 2)
            {
                int i = 0;
                foreach (string n in Customers)
                {
                    if (n == ordername)
                    {
                        Console.Write("\n按照客户查询结果为:\n" + "订单号:" + OrderNumbers[i] + "\n商品名称:" +
                            TradeNames[i] + "\n客户:" + Customers[i] + "\n");

                        break;
                    }
                    i++;
                }
            }
            else
            {
                Console.WriteLine("您输入的信息有误!");
            }
        }

        //修改订单
        public void ChangeOrder(int originated, int changed, int flag)
        {
            //订单号修改 flag为 0
            if (flag == 0)
            {
                int sum = 0;
                foreach (int a in OrderNumbers)//获取数组长度
                {
                    sum++;
                }

                int i = 0;
                foreach (int n in OrderNumbers)
                {
                    if (n == originated)
                    {
                        OrderNumbers[i] = changed; //找到后进行修改
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("您输入的信息有误!");
            }
        }
        public void ChangeOrder(string originated, string changed, int flag)
        {
            int sum = 0;
            foreach (int a in OrderNumbers)//获取数组长度
            {
                sum++;
            }

            //商品名称修改 flag为 1
            if (flag == 1)
            {
                int i = 0;
                foreach (string n in TradeNames)
                {
                    if (n == originated)
                    {
                        TradeNames[i] = changed; //找到后进行修改
                        break;
                    }
                }
            }
            //客户修改 flag为 2
            else if (flag == 2)
            {
                int i = 0;
                foreach (string n in Customers)
                {
                    if (n == originated)
                    {
                        Customers[i] = changed; //找到后进行修改
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("您输入的信息有误!");
            }
        }

        //打印订单
        public void OrderPrint()
        {
            Console.WriteLine("打印全部订单:");
            foreach (string a in Customers)
            {
                Console.Write(a + "\t");
            }
            Console.Write("\n");
            foreach (string b in TradeNames)
            {
                Console.Write(b + "\t");
            }
            Console.Write("\n");
            foreach (int c in OrderNumbers)
            {
                Console.Write(c + "\t");
            }
            Console.WriteLine("");
        }

    }

    //订单明细
    class OrderDetails : OrderService
    {
        //重载ToString()
        //public override string ToString()
        //{
        //    foreach(string a in Customers)
        //    return "订单信息";
        //}


        //public new void OrderPrint(OrderService order){ }
    }




    class Program
    {
        static void Main(string[] args)
        {
            //添加订单
            Order order = new OrderService();
            order.AddOrder(111, "汽车", "周旭鹏");
            order.AddOrder(112, "电动车", "张三");
            order.AddOrder(113, "自行车", "李四");

            order.OrderPrint();//订单全部打印

            order.InquriyOrder(112, 0);//按照订单号查询(参数为 0 )，并输出
            order.InquriyOrder("自行车", 1);//按照商品名称查询(参数为 1 )，并输出
            order.InquriyOrder("周旭鹏", 2);//按照客户查询(参数为 2 )，并输出

            order.RemoveOrder(2);//删除第二个订单

            order.ChangeOrder("周旭鹏", "王五", 2);//修改订单（将 “周旭鹏”改为 “王五”）

            order.OrderPrint();//打印修改、删除后的全部订单

            // try,catch,finish 的异常处理 ！！！！！！！！！！因为使用了参数（0-订单号，1-商品名称，2-客户）和if-else语句,所以运行以下错误代码不会报错，所以未使用 try-catch 语句
            //order.InquriyOrder(114, 0); //查找错误
            //order.ChangeOrder("周", "王五", 2); //传参错误


            //订单明细(未能正常运行)
            //OrderDetails orderdetails = new OrderDetails();
            //orderdetails.OrderPrint(order);
        }
    }
}
