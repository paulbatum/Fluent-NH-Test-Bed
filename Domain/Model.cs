using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }

    public class Order
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }

    }
}