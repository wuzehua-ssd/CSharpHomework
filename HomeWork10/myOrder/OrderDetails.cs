using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    public class OrderDetails
    {
       [Key]
       
        

        public string OrderDetailsId { get; set; }
        public uint Quantity { get; set; }
        public List<Goods> Goods { get; set; }
        public List<Customers> Customers { get; set; }

        public OrderDetails()
        {
            Goods = new List<Goods>();
            Customers = new List<Customers>();
        }

        public OrderDetails(string id,List<Goods>goods,List<Customers>customers)
        {
            OrderDetailsId = id;
            Goods = goods;
            
            Customers = customers;
        }
        public override string ToString()
        {
            string result = "";
            result += $"订单明细编号：{OrderDetailsId}:";
            result += Goods;
            return result;
        }

    }
}
