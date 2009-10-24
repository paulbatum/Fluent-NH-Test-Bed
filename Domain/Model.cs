using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public IDictionary<Order, bool> Orders { get; set; }
    }
}