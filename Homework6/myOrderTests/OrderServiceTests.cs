using Microsoft.VisualStudio.TestTools.UnitTesting;
using myOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void OrderServiceTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrderTest()
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
            OrderService os = new OrderService();
            os.AddOrder(order1);     
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            OrderService os = new OrderService();
            os.RemoveOrder(1);
        }

        [TestMethod()]
        public void QueryAllOrdersTest()
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
            order2.AddOrderDetails(orderDetails2);
            order2.AddOrderDetails(orderDetails3);
            order3.AddOrderDetails(orderDetails3);
            order4.AddOrderDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            os.AddOrder(order4);
            os.QueryAllOrders();

        }

        [TestMethod()]
        public void QueryOrderByIdTest()
        { 
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOrdersByCustomerNameTest()
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
            order2.AddOrderDetails(orderDetails2);
            order2.AddOrderDetails(orderDetails3);
            order3.AddOrderDetails(orderDetails3);
            order4.AddOrderDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            os.AddOrder(order4);
            os.GetOrdersByCustomerName("张三");
        }

        [TestMethod()]
        public void QueryOrdersByGoodsNameTest()
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
            order2.AddOrderDetails(orderDetails2);
            order2.AddOrderDetails(orderDetails3);
            order3.AddOrderDetails(orderDetails3);
            order4.AddOrderDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            os.AddOrder(order4);
            os.QueryOrdersByGoodsName("苹果");
        }

        [TestMethod()]
        public void UpdateOrderCustomerTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void ETest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void ITest()
        {
            Assert.Fail();
        }
    }
}