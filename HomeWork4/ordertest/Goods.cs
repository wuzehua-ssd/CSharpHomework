using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {
    /**
     * Goods class:the message of goods
     **/
    class Goods {

        private double goodsValue;

        /// <summary>
        /// Goods constuctor
        /// </summary>
        /// <param name="id">goods id</param>
        /// <param name="name">goods name</param>
        /// <param name="value">>goods value</param>
        public Goods(uint id, string name, double value) {
            GoodsId = id;
            GoodsName = name;
            GoodsValue = value;
        }

        /// <summary>
        /// property : goods id
        /// </summary>
        public uint GoodsId { get; set; }

        /// <summary>
        /// property : goods name
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// property : goods value
        /// </summary>
        public double GoodsValue {
            get { return goodsValue; }
            set {
                if (value >= 0)
                    goodsValue = value;
                else
                    throw new ArgumentOutOfRangeException("value must >= 0!");
            }
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Goods object</returns>
        public override string ToString() {
            return $"goodsId:{GoodsId}, goodsName:{GoodsName}, goodsValue:{GoodsValue}";
        }
    }
}
