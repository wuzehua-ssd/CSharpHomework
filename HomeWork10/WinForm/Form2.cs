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
using System.Text.RegularExpressions;


namespace WinForm
{
    public partial class Form2 : Form
    {
        public static bool IsPhoneNumber(string number)
        {
            return Regex.IsMatch(number, @"[1]+\d{10}");
        }
        public Form2()
        {
            InitializeComponent();
        }
        static uint B = 0;
        private static uint m = 0;
        private static uint count = 0;
        public List<Goods> goods = new List<Goods>();
        public List<Customers> customers = new List<Customers>();
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        private void button1_Click(object sender, EventArgs e)
        {
            Goods goods1 = null, goods2 = null, goods3 = null;
            m++;
            OrderService OrderService = new OrderService();

           
            if(checkBox1.Checked&&textBox2.Text!="")
            {
                goods1 = new Goods(3,Convert.ToInt32(textBox2.Text),"牛奶",Convert.ToString(1));
                B++;
                goods.Add(goods1);
                
                
            }
            if (checkBox2.Checked && textBox3.Text != "")
            {
                goods2 = new Goods(4, Convert.ToInt32(textBox3.Text), "苹果",Convert.ToString(2));
                B++;
                goods.Add(goods2);
               
                
            }
            if (checkBox3.Checked && textBox4.Text != "")
            {
                goods3 = new Goods(5, Convert.ToInt32(textBox4.Text), "牛奶",Convert.ToString(3));
                B++;
                goods.Add(goods3);

            }
            if (!IsPhoneNumber(phoneBox.Text))
            {
                MessageBox.Show("请正确输入电话号码！");
                return;
            }

            if (!textBox1.Text.Equals(""))
            {
                count++;
                Customers customer = new Customers(Convert.ToString(count), textBox1.Text, phoneBox.Text);
                customers.Add(customer);
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
            OrderDetails orderDetail = new OrderDetails(Convert.ToString(B), goods, customers);
            orderDetails.Add(orderDetail);
            string id = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + m.ToString().PadLeft(3, '0');
            Order order = new Order(id,textBox1.Text,DateTime.Now,orderDetails);
            OrderService.AddOrder(order);
            this.Close();

        }

    }
}
