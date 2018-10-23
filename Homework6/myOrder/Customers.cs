using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    [Serializable]
    public class Customers
    {
        public Customers()
        {

        }
        public Customers(uint id,string name)
        {
            CustomerId = id;
            CustomerName = name;
        }

        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }

        public override string ToString()
        {
            return $"顾客编号：{CustomerId},顾客姓名：{CustomerName}";
        }
    }
}
