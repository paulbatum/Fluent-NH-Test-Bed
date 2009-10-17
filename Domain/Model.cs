using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual Address Address { get; set; }
    }

    public class Address
    {
        public virtual string Street { get; set; }
        public virtual string Suburb { get; set; }
    }
}