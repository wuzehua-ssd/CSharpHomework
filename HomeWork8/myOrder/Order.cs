using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    public class Order
    {
        
        public List<OrderDetails> OrderDetailsDicts = new List<OrderDetails>();

        public List<OrderDetails> MyOrder { get => this.OrderDetailsDicts; }
        //订单的编号
        public string OrderId
        {
            set;
            get;
        }
        //该订单的客户
        
        //客户电话
        public string Phone { set; get; }
        //订单金额
        public Customers Customers { get; set; }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            this.MyOrder.Add(orderDetails);
        }

        public void DelectByName(string name)
        {
            var A = MyOrder.Where(a => a.Goods.GoodsName == name).Select(a => a);
            foreach (var B in A)
            {
                MyOrder.Remove(B);
            }
        }


    }
}
