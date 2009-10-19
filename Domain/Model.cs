using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
        public virtual DateTime Version { get; set; }
    }

    public class Customer : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual IList<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }

    public class Order : Entity
    {
        public virtual int Quantity { get; set; }
    }
}