using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progrom2
{
    class OrderService
    {
        List<OrderDetails> MyOreder = new List<OrderDetails>();
        //（订单明细，编号，名称，数量，价格，客户）
        public static void Add(List<OrderDetails> a, int b, string c, int d, float e, string f) //（订单明细，编号，名称，数量，价格，客户）
        {
            OrderDetails NewOrderDetails = new OrderDetails();
            NewOrderDetails.CommodityID = b;
            NewOrderDetails.CommodityName = c;
            NewOrderDetails.CommodityNumber = d;
            NewOrderDetails.CommodityPrice = e;
            NewOrderDetails.Client = f;
            a.Add(NewOrderDetails);
        }
        public static void Delete(List<OrderDetails> a, int b, string c, int d, float e, string f)//编号删除
        {
            if (a.Count == 0 || a.FindAll(s => (s.CommodityID == b) && (s.Client == c) && (s.CommodityName == f) && (s.CommodityNumber == d) && (s.CommodityPrice == e)) == null)
                throw new Exception("没有此明细");
            a.RemoveAll(s => (s.CommodityID == b) && (s.Client == c) && (s.CommodityName == f) && (s.CommodityNumber == d) && (s.CommodityPrice == e));
            List<OrderDetails> DeleteOrderDetails = a;
            foreach (OrderDetails O in DeleteOrderDetails)
            {
                Console.WriteLine(O.CommodityID + " " + O.CommodityName + " " + O.CommodityNumber + " " + O.CommodityPrice + " " + O.Client);

            }
        }
        public static void Search(List<OrderDetails> a, int b, string c, int d, float e, string f)//编号查询
        {
            if (a.Count == 0 || a.FindAll(s => (s.CommodityID == b) && (s.Client == c) && (s.CommodityName == f) && (s.CommodityNumber == d) && (s.CommodityPrice == e)) == null)
                throw new Exception("没有此明细");
            List<OrderDetails> FindOrderDetails = a.FindAll(s => (s.CommodityID == b) && (s.Client == c) && (s.CommodityName == f) && (s.CommodityNumber == d) && (s.CommodityPrice == e));
            foreach (OrderDetails O in FindOrderDetails)
            {
                Console.WriteLine(O.CommodityID + " " + O.CommodityName + " " + O.CommodityNumber + " " + O.CommodityPrice + " " + O.Client);
            }
        }
    }
}
