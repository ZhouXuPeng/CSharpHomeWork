using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_WinForm
{
    public partial class Form1 : Form
    {
        public static Dictionary<uint, string> orders = new Dictionary<uint, string>();
        public static BindingList<Order_new.Order> OrderList = new BindingList<Order_new.Order>();
        public static BindingList<Order_new.Order> OrderListQuary = new BindingList<Order_new.Order>();
        public static BindingList<Order_new.OrderDetail> OrderDetails = new BindingList<Order_new.OrderDetail>();
        public static BindingList<Order_new.OrderDetail> OrderDetailsQuary = new BindingList<Order_new.OrderDetail>();
        public uint flag = 0;
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.dataGridView1.DataSource = OrderList;
            this.dataGridView2.DataSource = OrderDetails;
            this.dataGridView3.DataSource = OrderListQuary;
            //this.dataGridView4.DataSource = OrderDetailsQuary;
            orders.Add(1, "order1");
            orders.Add(2, "order2");
            orders.Add(3, "order3");
        }

        public void OrderAdvance()
        {
            // 客户信息
            Order_new.Customer customer1 = new Order_new.Customer(1, "周旭鹏");
            Order_new.Customer customer2 = new Order_new.Customer(2, "张三");

            //商品信息
            Order_new.Goods cars = new Order_new.Goods(1, "汽车", 10000);
            Order_new.Goods ele_bike = new Order_new.Goods(2, "电动车", 1000);
            Order_new.Goods bike = new Order_new.Goods(3, "自行车", 100);

            //订单明细（商品数量）
            Order_new.OrderDetail orderDetails1 = new Order_new.OrderDetail(1, cars, 3);
            Order_new.OrderDetail orderDetails2 = new Order_new.OrderDetail(2, ele_bike, 25);
            Order_new.OrderDetail orderDetails3 = new Order_new.OrderDetail(3, bike, 225);

            // 订单管理
            Order_new.Order order1 = new Order_new.Order(1, customer1);
            Order_new.Order order2 = new Order_new.Order(2, customer2);
            Order_new.Order order3 = new Order_new.Order(3, customer1);

            // 订单管理(订单信息添加)
            order1.AddDetail(orderDetails1);
            order1.AddDetail(orderDetails2);
            order1.AddDetail(orderDetails3);
            order2.AddDetail(orderDetails2);
            order2.AddDetail(orderDetails3);

            //订单信息输出
            Console.Write(order1);
            Console.Write(order2);

            Order_new.OrderService os = new Order_new.OrderService();

            /// 添加订单 
            if (flag == 1)
            {
                if (textBox1.Text.ToString() == "order1")
                {
                    OrderList.Add(order1);
                }
                else if (textBox1.Text.ToString() == "order2")
                {
                    OrderList.Add(order2);
                }
                else if (textBox1.Text.ToString() == "order3")
                {
                    OrderList.Add(order3);
                }
            }
            else if(flag == 2)
            {
                if (textBox2.Text.ToString() == "order1")
                {
                    OrderList.Remove(order1);
                }
                else if (textBox2.Text.ToString() == "order2")
                {
                    OrderList.Remove(order2);
                }
                else if (textBox2.Text.ToString() == "order3")
                {
                    OrderList.Remove(order3);
                }
            }
            else if (flag == 3)
            {
                if(comboBox1.SelectedItem.ToString() == "订单号")
                {
                    uint uId = UInt32.Parse(textBox4.Text.ToString());
                    var OrderIdQ = from or in OrderList where or.OrderId == uId select or;
                    foreach(Order_new.Order order in OrderIdQ)
                    {
                        OrderListQuary.Add(order);
                        dataGridView4.DataSource = order.details;
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "商品名称")
                {
                    string sName = textBox4.Text.ToString();
                    foreach (Order_new.Order or in OrderList)
                    {
                        foreach (Order_new.OrderDetail orderdetail in or.details)
                        {
                            if (orderdetail.Goods.Name == sName)
                            {
                                OrderListQuary.Add(or);
                                dataGridView4.DataSource = orderdetail;
                            }
                        }
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "客户姓名")
                {
                    string sCustomerName = textBox4.Text.ToString();
                    foreach (Order_new.Order or in OrderList)
                    {
                            if (or.Customer.Name == sCustomerName)
                            {
                                OrderListQuary.Add(or);
                                dataGridView4.DataSource = or.details;
                            }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)   // 添加订单
        {
            flag = 1;
            OrderAdvance();

            // 跳转Form2
            //Form2 form2 = new Form2();
            //form2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e) // 删除订单
        {
            flag = 2;
            OrderAdvance();
        }

        private void button4_Click(object sender, EventArgs e) // 查询订单
        {
            flag = 3;
            OrderAdvance();
        }

        private void button5_Click(object sender, EventArgs e) // 显示所有订单
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e) // 订单明细
        {
            try
            {
                if (listBox1.SelectedItem.ToString() == "order1")
                {
                    dataGridView2.DataSource = OrderList[0].details;
                }
                else if (listBox1.SelectedItem.ToString() == "order2")
                {
                    dataGridView2.DataSource = OrderList[1].details;
                }
                else if (listBox1.SelectedItem.ToString() == "order3")
                {
                    dataGridView2.DataSource = OrderList[2].details;
                }
                else
                {
                    MessageBox.Show("订单明细输出错误！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("订单明细输出错误！" + ex);
            }
        }

    }
}
