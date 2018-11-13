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
        public List<Order> orders = new List<Order>();
        public static OrderService os = new OrderService();
        public List<OrderDetails>orderDetails=new List<OrderDetails>();
        public string C { get; set; }
        public Form1()
        {
           
            orders = os.orderDict;
            InitializeComponent();
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
            orders = os.orderDict;
            List<Order> B = new List<Order>();
            if(orders.Count()==0)
            {
                MessageBox.Show("当前没有订单");
                return;
            }

            if(comboBox1.Text.Equals("订单号"))
            {
                var A = orders.Where(a => a.OrderId.Equals(textBox1.Text));
                if(A.Count()==0)
                {
                    MessageBox.Show("没有相关订单！");
                    return;
                }
                orderBindingSource.DataSource = A;
                foreach (Order a in A)
                    B.Add(a);
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].OrderDetailsDicts);
                
            }
            else if (comboBox1.Text.Equals("客户名"))
            {
                var A = orders.Where(a => a.Customers.CustomerName.Equals(textBox1.Text));
                if(A.Count()==0)
                {
                    MessageBox.Show("没有相关订单！");
                    return;
                }
                orderBindingSource.DataSource = A;
                foreach (Order a in A)
                    B.Add(a);
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].OrderDetailsDicts);
            }
            else
            {
                MessageBox.Show("没有相关订单！");
                return;
            }
        }

        //显示订单
        private void button3_Click(object sender, EventArgs e)
        {
            if(os.orderDict.Count()!=0)
            {
                orderBindingSource.DataSource = new BindingList<Order>(os.orderDict);
            }
            else
            {
                MessageBox.Show("当前无订单！");
            }
        }

        //删除订单
        private void button4_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(os.orderDict.Count()==0)
            {
                return;
            }
            int A = os.orderDict.FindIndex(a => a.OrderId.Equals(label2.Text));
            
            
            orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(os.orderDict[A].OrderDetailsDicts);
            
        }

        //导出HTML
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                os.Export();
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Order.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"./Order.xslt");

                FileStream outFileStream = File.OpenWrite(@"./Order.html");
                XmlTextWriter writer = new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, writer);
                MessageBox.Show("成功！");                
            }
            catch(XmlException ea)
            {
                Console.WriteLine("XML Exception:" + ea.ToString());
            }
            catch(XsltException ea)
            {
                Console.WriteLine("XSLT Exception:" + ea.ToString());
            }
        }

        
    }
}
