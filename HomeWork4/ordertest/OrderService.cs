using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    /**
     * OrderService:provide service for users about ordering,
     * like add order, remove order, query order and so on
     * 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
     * */
    class OrderService {

        // uint : orderId, Order : Order obj
        private Dictionary<uint, Order> orderDict;

        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService() {
            orderDict = new Dictionary<uint, Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order) {
            if (orderDict.ContainsKey(order.OrderId))
                throw new Exception($"order-{order.OrderId} is already existed!");
            orderDict[order.OrderId] = order;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId) {
            if (orderDict.ContainsKey(orderId)) {
                orderDict.Remove(orderId);
            }
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders() {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public List<Order> QueryOrderById(uint orderId) {
            List<Order> result = new List<Order>();
            if (orderDict.ContainsKey(orderId)){
                result.Add(orderDict[orderId]);
            }
            return result;
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryOrdersByGoodsName(string goodsName) {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict.Values.ToList()) {
                List<OrderDetail> orderDetailsList = order.QueryAllOrderDetails();
                foreach(OrderDetail od in orderDetailsList) {
                    if(od.Goods.GoodsName == goodsName) {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> GetOrdersByCustomerName(string customerName) {
            List<Order> result = new List<Order>();
            orderDict.Values.ToList().ForEach(order => {
                if (order.Customer.CustomerName == customerName)
                    result.Add(order);
            });
            return result;
        }

        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateOrderCustomer(uint orderId, Customer newCustomer) {
            if (orderDict.ContainsKey(orderId)) {
                orderDict[orderId].Customer = newCustomer;
            } else {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        /*other update function will write in the future.*/
    }
}
