using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTreeUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 35 * Math.PI / 180;
        double dn = 0.4; // 分叉系数
        Pen color; // 树枝颜色
        double per1 = 0.6;
        double per2 = 0.7;

        private void button1_Click(object sender, EventArgs e)
        {
            //改变偏转角度
            try
            {
                string new_th1 = textBox1.Text.ToString();
                string new_th2 = textBox2.Text.ToString();
                if (new_th1 != null && new_th2 != null)
                {
                    double dth1 = Double.Parse(new_th1);
                    double dth2 = Double.Parse(new_th2);
                    th1 = dth1 * Math.PI / 180;
                    th2 = dth2 * Math.PI / 180;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("您输入的角度不是整数型数据");
            }
            catch (FormatException)
            {
                MessageBox.Show("您未输入的角度有误! ");
            }

            //改变树枝长度
            try
            {
                string new_per1 = textBox3.Text.ToString();
                string new_per2 = textBox4.Text.ToString();
                if (new_per1 != null && new_per2 != null)
                {
                    double dper1 = Double.Parse(new_per1);
                    double dper2 = Double.Parse(new_per2);
                    per1 = dper1;
                    per2 = dper2;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("您输入的长度不是整数型数据");
            }
            catch (FormatException)
            {
                MessageBox.Show("您未输入的长度有误! ");
            }

            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 400, 360, 100, -Math.PI / 2);


            
        }

        void drawCayleyTree(int n, double x0, double y0, double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * dn * Math.Cos(th);
            double y2 = y0 + leng * dn * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(color, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectColor = comboBox1.SelectedItem.ToString();
            if(selectColor == "红色")
            {
                color = Pens.Red;
            }
            else if(selectColor == "绿色")
            {
                color = Pens.Green;
            }
            else if (selectColor == "白色")
            {
                color = Pens.White;
            }
            else if (selectColor == "蓝色")
            {
                color = Pens.Blue;
            }
            else
            {
                color = Pens.Yellow;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

                string n = domainUpDown1.SelectedItem.ToString();
                double new_dn = double.Parse(n);
                dn = new_dn; 
        }
    }
}
