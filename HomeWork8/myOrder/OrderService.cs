using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace myOrder
{
    public class OrderService
    {
        public List<Order> orderDict = new List<Order>();

       
        public void AddOrder(Order order)
        {
            this.orderDict.Add(order);
        }

        //按订单号删除订单
        public void RemoveOrder(int orderId)
        {
            if (this.orderDict.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            var A = orderDict.Where(a => a.OrderId.Equals(orderId.ToString())).Select(a => a);
            //判断是否有相关订单
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            this.orderDict.RemoveAll(a => a.OrderId.Equals(orderId.ToString()));
        }

        
        //按客户删除订单
        public void DeleteByCliend(string client)
        {
            if (this.orderDict.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            var A = orderDict.Where(a => a.Customers.CustomerName.Equals(client)).Select(a => a);
            //判断是否有相关订单
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            this.orderDict.RemoveAll(a => a.Customers.CustomerName.Equals(client));
        }


        //按照客户查询订单
        public void FindByName(string client)
        {
            if (this.orderDict.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            //筛选订单
            var A = orderDict.Where(a => a.Customers.CustomerName == client).Select(a => a);
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            //输出所得订单
            foreach (var B in A)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Customers.CustomerName}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.OrderDetailsId}.  商品编号：{C.Goods.GoodsId}\t名称：{C.Goods.GoodsName}\t单价：{C.Goods.GoodsValue}\t数量：{C.Quantity}");
                }
                
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}*****");
            }
        }

        //按照订单号查询订单
        public void FindByID(int id)
        {
            if (this.orderDict.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }

            //筛选订单
            var A = orderDict.Where(a => a.OrderId.Equals(id.ToString())).Select(a => a);
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            //输出所得订单

            foreach (var B in A)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Customers.CustomerName}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.OrderDetailsId}.  商品编号：{C.Goods.GoodsId}\t名称：{C.Goods.GoodsName}\t单价：{C.Goods.GoodsValue}\t数量：{C.Quantity}");
                }
               
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}*****");
            }
        }

        //按照商品名称查询
        public void FindByGN(string name)
        {
            if (this.orderDict.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            var A = orderDict.Where(a => a.MyOrder.Exists(b => b.Goods.GoodsName == name)).Select(a => a);

            foreach (var B in A)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Customers.CustomerName}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.OrderDetailsId}.  商品编号：{C.Goods.GoodsId}\t名称：{C.Goods.GoodsName}\t单价：{C.Goods.GoodsValue}\t数量：{C.Quantity}");
                }
               
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}*****");
            }
        }

        //显示所有订单
        public void ShowForUser()
        {
            if (this.orderDict.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            foreach (var B in this.orderDict)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Customers.CustomerName}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.OrderDetailsId}.  商品编号：{C.Goods.GoodsId}\t名称：{C.Goods.GoodsName}\t单价：{C.Goods.GoodsValue}\t数量：{C.Quantity}");
                }
               
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}//{DateTime.Now.Month.ToString()}//{DateTime.Now.Day.ToString()}*****");
            }


        }

        //XML序列化
        public string Export()
        {
            DateTime time = System.DateTime.Now;
            string fileName = "Order_" + time.Year + "_" + time.Month
                + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
                + "_" + time.Second + ".xml";
            Export("Order.xml");
            return fileName;
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, orderDict);
            }
        }


    }
}
