using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    /**
     * Customer the man who orders goods.
     **/
    class Customer {

        /// <summary>
        /// Customer constructor
        /// </summary>
        /// <param name="id">customer id</param>
        /// <param name="name">customer name </param>
        public Customer(uint id, string name) {
            CustomerId = id;
            CustomerName = name;
        }

        /// <summary>
        /// customer's identifier
        /// </summary>
        public uint CustomerId { get; set; }

        /// <summary>
        /// customer's name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Customer object</returns>
        public override string ToString() {
            return $"customerId:{CustomerId}, CustomerName:{CustomerName}";
        }
    }
}
