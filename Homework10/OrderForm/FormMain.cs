﻿using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.XPath;

namespace OrderForm
{
    public partial class FormMain : Form
    {
        OrderService orderService;
        BindingSource fieldsBS = new BindingSource();
        public FormMain()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //FormEdit form2 = new FormEdit(new Order());
            //form2.ShowDialog();
            //Order newOrder = form2.getResult();
            //if (newOrder!=null){
            //    int flag = orderService.AddOrder(newOrder);
            //    if (flag == 0)
            //    {
            //        MessageBox.Show("您输入的订单号已存在!");
            //    }
            //    else
            //    {
            //        orderBindingSource.DataSource = orderService.QueryAllOrders();
            //    }
            //}
           
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //FormEdit form2 = new FormEdit((Order)orderBindingSource.Current);
            //form2.ShowDialog();
            //if (form2.GetNumber() != 0)
            //{
            //    long phoneNumber = form2.GetNumber();
            //    orderBindingSource.DataSource = orderService.QueryAllOrders();
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Order o=(Order)orderBindingSource.Current;
            //if (o != null)
            //{
            //    orderService.RemoveOrder(o.Id);
            //    orderBindingSource.DataSource=orderService.QueryAllOrders();
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //DialogResult result = saveFileDialog1.ShowDialog();
            //if (result.Equals(DialogResult.OK))
            //{
            //    String fileName = saveFileDialog1.FileName;
            //    orderService.Export(fileName);

            //    // 用XSLT将XML转化为HTML
            //    XmlDocument xDoc = new XmlDocument();
            //    xDoc.Load(fileName);

            //    XPathNavigator nav = xDoc.CreateNavigator();
            //    nav.MoveToRoot();

            //    XslCompiledTransform xt = new XslCompiledTransform();
            //    xt.Load(@"..\..\Order.xslt");

            //    FileStream outFileStream = File.OpenWrite(@"..\..\Order.html");
            //    XmlTextWriter writer =
            //        new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
            //    xt.Transform(nav, null, writer);
            //}
           
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //DialogResult result = openFileDialog1.ShowDialog();
            //if (result.Equals(DialogResult.OK))
            //{
            //    String fileName = openFileDialog1.FileName;
            //    orderService.Import(fileName);
            //    orderBindingSource.DataSource = orderService.QueryAllOrders();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //switch (cbField.SelectedIndex)
            //{
            //    case 0:
            //        orderBindingSource.DataSource =
            //            orderService.QueryAllOrders();
            //        break;
            //    case 1:
            //        uint id = 0;
            //        uint.TryParse(txtValue.Text, out id);
            //        orderBindingSource.DataSource = orderService.GetById(id);
            //        break;
            //    case 2:
            //        orderBindingSource.DataSource =
            //                orderService.QueryByCustomerName(txtValue.Text);
            //        break;
            //    case 3:
            //        orderBindingSource.DataSource =
            //                orderService.QueryByGoodsName(txtValue.Text);
            //        break;
            //    case 4:
            //        double price = 0;
            //        double.TryParse(txtValue.Text, out price);
            //        orderBindingSource.DataSource =
            //               orderService.QueryByPrice(price);
            //        break;
            //}

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
