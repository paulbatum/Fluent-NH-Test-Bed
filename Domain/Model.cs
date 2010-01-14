using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public virtual int CustomerId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual DateTime Birthday { get; set; }

        public virtual IList<Customer> Parents { get; set; }
        public virtual IList<Customer> Children { get; set; }

        public Customer()
        {
            Parents = new List<Customer>();
            Children = new List<Customer>();

        }
    }


}