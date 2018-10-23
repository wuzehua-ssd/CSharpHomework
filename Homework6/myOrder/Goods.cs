using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    [Serializable]
    public class Goods
    {
        public Goods()
        {

        }
        private double goodsValue;

        public Goods(uint id,string name,double value)
        {
            GoodsId = id;
            GoodsName = name;
            GoodsValue = value;
        }

        public uint GoodsId { get; set; }
        public string GoodsName { get; set; }
        public double GoodsValue
        {
            get { return goodsValue; }
            set
            {
                if(value>=0)
                {
                    goodsValue = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("货物价值必须大于0！");
                }
            }
        }

        public override string ToString()
        {
            return $"货物编号：{GoodsId},货物名称：{GoodsName},货物价值：{GoodsValue}";
        }
    }
}
