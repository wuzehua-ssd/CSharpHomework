using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    public class Customers
    {
        [Key]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }

        public Customers() { }

        public Customers(string id,string name,string phone)
        {
            CustomerId = id;
            CustomerName = name;
            CustomerPhone = phone;
        }

        public override string ToString()
        {
            return $"顾客编号：{CustomerId},顾客姓名：{CustomerName}";
        }
    }
}
