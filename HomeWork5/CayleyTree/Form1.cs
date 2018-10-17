using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = Convert.ToInt32(textBox1.Text) * Math.PI / 180;
            th2 = Convert.ToInt32(textBox2.Text) * Math.PI / 180;
            per1 = Convert.ToDouble(textBox3.Text);
            per2 = Convert.ToDouble(textBox4.Text);

            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1+leng*Math.Cos(th)/5, y1+leng*Math.Sin(th)/5, per2 * leng, th - th2);

        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        
    }
}
