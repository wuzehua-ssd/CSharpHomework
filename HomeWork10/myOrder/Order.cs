using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public List<OrderDetails>OrderDetails{get;set;}
        public string   CustomerName { get; set; }
        public DateTime Createtime { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public Order(string id,string customer,DateTime createtime,List<OrderDetails>orderDetails)
        {
            OrderId = id;
            CustomerName = customer;
            Createtime = createtime;
            OrderDetails = orderDetails;
        }
    }
}
