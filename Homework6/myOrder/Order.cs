using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    [Serializable]
    public class Order
    {
        public Order()
        {

        }
        private Dictionary<uint, OrderDetails> OrderDetailsDicts;

        public Order(uint id,Customers customers)
        {
            OrderId = id;
            Customers = customers;
            OrderDetailsDicts = new Dictionary<uint, OrderDetails>();
        }

        public uint OrderId { get; set; }
        public Customers Customers { get; set; }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            if(OrderDetailsDicts.ContainsKey(orderDetails.OrderDetailsId))
            {
                throw new Exception($"订单明细-{orderDetails.OrderDetailsId}已经存在！");
            }
            else
            {
                OrderDetailsDicts[orderDetails.OrderDetailsId] = orderDetails;
            }
        }

        public void RemoveOrderDetails(uint orderDetailsId)
        {
            if(OrderDetailsDicts.ContainsKey(orderDetailsId))
            {
                OrderDetailsDicts.Remove(orderDetailsId);
            }
            else
            {
                throw new Exception($"订单明细-{orderDetailsId}不存在！");
            }
        }

        public List<OrderDetails> QueryAllOrderDetails()
        {
            return OrderDetailsDicts.Values.ToList();
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{OrderId}, customer:({Customers})";
            OrderDetailsDicts.Values.ToList().ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }

    }
}
