using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    public class Customers
    {
        public Customers(uint id,string name)
        {
            CustomerId = id;
            CustomerName = name;
        }

        public Customers()
        {

        }

        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public override string ToString()
        {
            return $"顾客编号：{CustomerId},顾客姓名：{CustomerName}";
        }
    }
}
