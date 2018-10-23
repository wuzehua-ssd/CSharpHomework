using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace myOrder
{
     public class OrderService
    {
        private Dictionary<uint, Order> orderDict;

        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.OrderId))
                throw new Exception($"订单-{order.OrderId}已经存在！");
            else
                orderDict[order.OrderId] = order;
        }

        public void RemoveOrder(uint orderId)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict.Remove(orderId);
            }
        }

        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        public List<Order> QueryOrderById(uint orderId)
        {
            List<Order> result = new List<Order>();
            if (orderDict.ContainsKey(orderId))
            {
                result.Add(orderDict[orderId]);
            }
            return result;
        }

        public List<Order> GetOrdersByCustomerName(string customerName)
        {
            List<Order> result = new List<Order>();
            var query = orderDict.Values.ToList().Where(s => s.Customers.CustomerName == customerName);
            orderDict.Values.ToList().ForEach(s =>
            {
                if (query.Contains(s))
                {
                    result.Add(s);
                }
            });

            return result;
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict.Values.ToList())
            {
                List<OrderDetails> orderDetailsList = order.QueryAllOrderDetails();
                var query = orderDetailsList.Where(s => s.Goods.GoodsName == goodsName);
                orderDetailsList.ForEach(s =>
                {
                    if (query.Contains(s))
                    {
                        result.Add(order);
                    }
                });
            }
            return result;
        }

        public void UpdateOrderCustomer(uint orderId, Customers newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customers = newCustomer;
            }
            else
            {
                throw new Exception($"订单-{orderId} 不存在！");
            }
        }

        public void E()
        {
            List<Order> orders = new List<Order>();
            foreach(Order order in orderDict.Values)
            {
                orders.Add(order);
            }
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("fs.xml",FileMode.Create))
            {
                xml.Serialize(fs, orders);
            }
        }
        public void I()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("fs.xml", FileMode.Open))
            {
                List<Order> orders1=(List<Order>)xml.Deserialize(fs);
            }
        }
    }   
    
}
