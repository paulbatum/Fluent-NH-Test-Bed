using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public virtual int CustomerId { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual IList<Group> Groups { get; set; }

        public Customer()
        {
            Groups = new List<Group>();    
        }
    }

    public class Group
    {
        public virtual int GroupId { get; set; }
        public virtual IList<Customer> Customers { get; set; }

        public Group()
        {
            Customers = new List<Customer>();
        }
    }



}