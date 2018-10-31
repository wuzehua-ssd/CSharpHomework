using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrder
{
    public class Goods
    {
        public double goodsValue;

        public Goods(int m,int n,string str)
        {

            this.GoodsName = str;
            this.goodsValue = m * n;
        }
        

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
            return $"货物名称：{GoodsName},货物价值：{GoodsValue}";
        }
    }
}
