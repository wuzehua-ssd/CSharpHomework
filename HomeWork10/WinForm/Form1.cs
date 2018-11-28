using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using myOrder;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;


namespace WinForm
{
    public partial class Form1 : Form
    {
        public static bool IsNumber(string number)
        {
            return Regex.IsMatch(number, @"^[0-9]*s");
        }
        OrderService OrderService = new OrderService();
        public Form1()
        {
            InitializeComponent();
            orderBindingSource.DataSource = OrderService.ShowForUser();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        //创建订单
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        //查询订单
        private void button2_Click(object sender, EventArgs e)
        {
            queryOrder();
        }

        //显示订单
        private void button3_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = OrderService.ShowForUser();
        }

        //删除订单
        private void button4_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                Order order = (Order)orderBindingSource.Current;
                OrderService.RemoveOrder(order.OrderId);
                queryOrder();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void queryOrder()
        {
            switch (comboBox1.SelectedIndex)
            {

                case 1:
                    orderBindingSource.DataSource =
                      OrderService.FindByID(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                      OrderService.FindByName(textBox1.Text);
                    break;
                default:
                    orderBindingSource.DataSource = OrderService.ShowForUser();
                    break;
            }
            orderBindingSource.ResetBindings(false);
            orderDetailsBindingSource.ResetBindings(false);
            //goodsBindingSource.ResetBindings(false);
        }
    }
}
