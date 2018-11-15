using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//1.textbox1在哪里传参
//2.无订单号为什么没有客户
//3.改变函数无反应


namespace OrderForm
{
    public partial class FormEdit : Form
    {
        Order result = null;

        public FormEdit()
        {
            InitializeComponent();
            Customer customer1 = new Customer(1, "liuwang");
            Customer customer2 = new Customer(2, "jams");

            Goods apple = new Goods(3, "apple", 5.59);
            Goods egg = new Goods(2, "egg", 4.99);
            Goods milk = new Goods(1, "milk", 69.9);
            customerBindingSource.Add(customer1);
            customerBindingSource.Add(customer2);
            goodsBindingSource.Add(apple);
            goodsBindingSource.Add(egg);
            goodsBindingSource.Add(milk);

        }

        public Order getResult() //窗口关闭时，自动调用
        {
            return result;
        }

        public FormEdit(Order order):this()
        {
           orderBindingSource.DataSource = order;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dataGridView1.CurrentCell.Value != null)
                {
                    comboBox2.Text = dataGridView1.CurrentCell.Value.ToString();  //对combobox赋值 
                }
              
                Rectangle R = dataGridView1.GetCellDisplayRectangle(
                                    dataGridView1.CurrentCell.ColumnIndex,
                                    dataGridView1.CurrentCell.RowIndex, false);

                comboBox2.Location = new Point(dataGridView1.Location.X + R.X,
                    dataGridView1.Location.Y + R.Y);

                comboBox2.Width = R.Width;
                comboBox2.Height = R.Height;
                comboBox2.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (detailsBindingSource.Current == null)
            {
                detailsBindingSource.Add(new OrderDetail());
            }
            ((OrderDetail)detailsBindingSource.Current).Goods=(Goods)comboBox2.SelectedItem;  //把combox的Item与数据库连接
        }

        //获得电话号码
        public long GetNumber()
        {
            try
            {
                if (textBox2.Text != null)
                {
                    return long.Parse(textBox2.Text);
                }
                else
                {
                    return 0;
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result=(Order)orderBindingSource.Current;
            try
            {
                if (textBox2.Text != null)
                {
                    result.PhoneNumber = long.Parse(textBox2.Text);
                }
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe);
            }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Order)orderBindingSource.Current).Customer =(Customer)comboBox1.SelectedItem;
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = 
                ((Order)orderBindingSource.Current).Customer;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length + 1) % 5 == 0)//每多出4个字符的时候自动在最后加一个空格  
            {
                textBox1.Text += " "; // 追加空格  
                textBox1.Select(textBox1.Text.Length, 0); // 选择文本末尾位置  
                //textBox1.ScrollToCaret(); // 将光标滚动到末尾位置，不然追加一个空格光标会跳转到开头位置  
            }
        }
        static int i = 0;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                    i++;
                    if(i > 11)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        static int j = 0;
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                j++;
                if (j > 11)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
