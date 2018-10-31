using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入删除目标！");
                return;
            }
            if(Form1.os.orderDict.Values.ToList().Exists(a=>a.Customers.CustomerName.Equals(textBox1.Text))&&comboBox1.Text.Equals("客户名"))
            {
                Form1.os.DeleteByCliend(textBox1.Text);
                MessageBox.Show("恭喜你，删除" + textBox1.Text + "成功！");
            }
            else if(Form1.os.orderDict.Values.ToList().Exists(a=>a.OrderId==Convert.ToUInt32(textBox1.Text))&&comboBox1.Text.Equals("订单号"))
            {
                Form1.os.RemoveOrder(Convert.ToUInt32(textBox1.Text));
                MessageBox.Show("恭喜你，删除成功！");
            }
            else
            {
                MessageBox.Show("未找到该订单！");
                return;
            }
            this.Close();
        }
    }
}
