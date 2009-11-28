using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual CreditCard CreditCard { get; private set; }

        public virtual void AddCreditCard(CreditCard c)
        {
            CreditCard = c;
            c.Customer = this;
        }
    }

    public class CreditCard
    {
        public int ID { get; set; }
        public virtual Customer Customer { get; internal set; }
    }

}