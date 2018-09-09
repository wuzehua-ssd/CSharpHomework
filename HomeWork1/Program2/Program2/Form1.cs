using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = Int32.Parse(textBox1.Text);
            double num2 = Int32.Parse(textBox2.Text);
            double num = num1 * num2;

            string str1 = Convert.ToString(num);
            textBox3.Text = str1;
        }
    }
}
