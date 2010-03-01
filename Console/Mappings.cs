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
            Id(x => x.CustomerId);
            Map(x => x.Birthday);
            Component(x => x.Address, c =>
            {
                c.Map(x => x.PostCode);
                c.Map(x => x.Street);
                c.Map(x => x.StreetNumber);
            });
        }
    }


}
