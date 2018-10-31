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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private static uint m = 0;
        private static uint count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Goods goods1 = null, goods2 = null, goods3 = null;
            m++;
            Order order = new Order(m);
            uint B = 0;
            if(checkBox1.Checked&&textBox2.Text!="")
            {
                goods1 = new Goods(3,Convert.ToInt32(textBox2.Text),"牛奶");
                B++;
                OrderDetails orderDetails = new OrderDetails(B,goods1, Convert.ToUInt32(textBox2.Text));
                
                order.AddOrderDetails(orderDetails);
            }
            if (checkBox2.Checked && textBox3.Text != "")
            {
                goods2 = new Goods(4, Convert.ToInt32(textBox3.Text), "苹果");
                B++;
                OrderDetails orderDetails = new OrderDetails(B, goods2, Convert.ToUInt32(textBox3.Text));
               
                order.AddOrderDetails(orderDetails);
            }
            if (checkBox3.Checked && textBox4.Text != "")
            {
                goods3 = new Goods(5, Convert.ToInt32(textBox4.Text), "牛奶");
                B++;
                OrderDetails orderDetails = new OrderDetails(B, goods3, Convert.ToUInt32(textBox4.Text));
           
                order.AddOrderDetails(orderDetails);
            }
         
            if (!textBox1.Text.Equals(""))
            {
                count++;
                Customers customers = new Customers(count,textBox1.Text);
                order.Customers = customers;

            }
            else
            {
                MessageBox.Show("请输入客户名！");
                return;
            }
            if (B == 0)
            {
                MessageBox.Show("抱歉！您添加的订单为空！");
                return;
            }
            else
                MessageBox.Show("添加成功！");

            order.OrderId = (uint)(m + DateTime.Now.Month * 10000 + DateTime.Now.Day * 100);
            Form1.os.AddOrder(order);
            this.Close();

        }

    }
}
