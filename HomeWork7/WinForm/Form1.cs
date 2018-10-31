using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myOrder;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public List<Order> orders = new List<Order>();
        public static OrderService os = new OrderService();
        public List<OrderDetails>orderDetails=new List<OrderDetails>();
     


        public string C { get; set; }
        
        public Form1()
        {
            orders = os.orderDict.Values.ToList();
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orders = os.orderDict.Values.ToList();
            List<Order> B = new List<Order>();
            if(orders.Count()==0)
            {
                MessageBox.Show("当前没有订单");
                return;
            }

            if(comboBox1.Text.Equals("订单号"))
            {
                var A = orders.Where(a => a.OrderId==Convert.ToUInt32(textBox1.Text));
                if(A.Count()==0)
                {
                    MessageBox.Show("没有相关订单！");
                    return;
                }
                orderBindingSource.DataSource = A;
                foreach (Order a in A)
                    B.Add(a);
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].OrderDetailsDicts.Values.ToList());
                
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
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].OrderDetailsDicts.Values.ToList());
            }
            else
            {
                MessageBox.Show("没有相关订单！");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(os.orderDict.Values.ToList().Count()!=0)
            {
                orderBindingSource.DataSource = new BindingList<Order>(os.orderDict.Values.ToList());
            }
            else
            {
                MessageBox.Show("当前无订单！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(os.orderDict.Values.ToList().Count()==0)
            {
                return;
            }
            int A = os.orderDict.Values.ToList().FindIndex(a => a.OrderId.ToString().Equals(label1.Text));
         
            //orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(os.orderDict.Values.ToList()[A].OrderDetailsDicts.Values.ToList());
        }
    }
}
