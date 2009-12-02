using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public string ID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<CreditCard> CreditCards { get; private set; }

        public Customer()
        {
            CreditCards = new List<CreditCard>();
        }
    }

    public class CreditCard
    {
        public int ID { get; set; }
        public virtual Customer Customer { get; internal set; }
    }

}