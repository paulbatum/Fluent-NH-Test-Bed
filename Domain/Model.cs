using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public virtual int CustomerId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual Address Address { get; set; }
    }

    public class Address
    {
        public int StreetNumber { get; set; }
        public string Street { get; set; }
        public int PostCode { get; set; }
    }


}