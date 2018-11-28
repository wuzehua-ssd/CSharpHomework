using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace myOrder
{
    public class OrderService
    {
        
       
        public void AddOrder(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        //按订单号删除订单
        public void RemoveOrder(string orderId)
        {
            using (var db = new OrderDB())
            {
                db.OrderDetails.Include("Goods").ToList<OrderDetails>();
                db.OrderDetails.Include("Customers").ToList<OrderDetails>();
                var order = db.Orders.Include("OrderDetails").SingleOrDefault(o => o.OrderId == orderId);
                db.OrderDetails.RemoveRange(order.OrderDetails);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
        
        //按客户删除订单
        public void DeleteByCliend(string client)
        {
            using (var db = new OrderDB())
            {
                var order = db.Orders.Include("OrderDetails").SingleOrDefault(o => o.CustomerName == client);
                db.OrderDetails.RemoveRange(order.OrderDetails);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }


        //按照客户查询订单
        public List<Order> FindByName(string client)
        {
            using (var db = new OrderDB())
            {
                return db.Orders.Include("OrderDetails").Where(o => o.CustomerName.Equals(client)).ToList<Order>();
            }
        }

        //按照订单号查询订单
        public List<Order> FindByID(string id)
        {
            using (var db = new OrderDB())
            {
                return db.Orders.Include("OrderDetails").Where(o => o.OrderId.Equals(id)).ToList<Order>();
            }
        }

        

        //显示所有订单
        public List<Order> ShowForUser()
        {
            using (var db = new OrderDB())
            {
                db.OrderDetails.Include("Goods").ToList<OrderDetails>();
                return db.Orders.Include("OrderDetails").ToList<Order>();
            }

        }

       

    }
}
