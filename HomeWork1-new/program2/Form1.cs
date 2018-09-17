using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        double num_1, num_2;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s_1 = textBox1.Text;
            num_1 = Double.Parse(s_1);
            string s_2 = textBox2.Text;
            num_2 = Double.Parse(s_2);

            double product;
            product = num_1 * num_2;
            //显示乘积结果
            this.textBox3.Text = "" + product;
        }
    }
}
