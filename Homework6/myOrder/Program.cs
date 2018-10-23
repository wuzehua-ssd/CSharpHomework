using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customers customer1 = new Customers(1, "张三");
                Customers customer2 = new Customers(2, "李四");
                Customers customer3 = new Customers(3, "王二麻子");

                Goods milk = new Goods(1, "牛奶", 2.5);
                Goods egg = new Goods(2, "鸡蛋", 1.5);
                Goods apple = new Goods(3, "苹果", 5.0);


                OrderDetails orderDetails1 = new OrderDetails(1, apple, 8);
                OrderDetails orderDetails2 = new OrderDetails(2, egg, 2);
                OrderDetails orderDetails3 = new OrderDetails(3, milk, 1);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                Order order4 = new Order(4, customer3);
                order1.AddOrderDetails(orderDetails1);
                order1.AddOrderDetails(orderDetails2);
                order1.AddOrderDetails(orderDetails3);
                //order1.AddOrderDetails(orderDetails3);
                order2.AddOrderDetails(orderDetails2);
                order2.AddOrderDetails(orderDetails3);
                order3.AddOrderDetails(orderDetails3);
                order4.AddOrderDetails(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);
                os.AddOrder(order4);

                Console.WriteLine("获取所有订单");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("通过顾客姓名查询订单:'李四'");
                orders = os.GetOrdersByCustomerName("李四");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("通过货物名称查询订单:'苹果'");
                orders = os.QueryOrdersByGoodsName("苹果");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder(2);
                orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                os.E();
                os.I();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
