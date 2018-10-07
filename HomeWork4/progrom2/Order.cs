using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progrom2
{
    class Order
    {
        public string ItemNumber { set; get; }
        public List<OrderDetails> MyOreder;
        public Order()
        {
            MyOreder = new List<OrderDetails>();
        }
    }
}
