using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    [Serializable]
    public class OrderDetails
    {
        public OrderDetails()
        {

        }
        public OrderDetails(uint id,Goods goods,uint quantity)
        {
            OrderDetailsId = id;
            Goods = goods;
            Quantity = quantity;
        }

        public uint OrderDetailsId { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }

        public override string ToString()
        {
            string result = "";
            result += $"订单明细编号：{OrderDetailsId}:";
            result += Goods + $"数目：{Quantity}";
            return result;
        }

    }
}
