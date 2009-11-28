using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {            
            Id(x => x.ID);
            HasOne(x => x.CreditCard)
                .PropertyRef(x => x.Customer)
                .Cascade.All();
        }
    }

    public class CreditCardMap : ClassMap<CreditCard>
    {
        public CreditCardMap()
        {
            Id(x => x.ID);
            References(x => x.Customer)
                .Unique();
        }
    }
}
