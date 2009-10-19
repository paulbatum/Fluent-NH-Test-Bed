using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Console
{
    public class CustomerMap : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.DynamicUpdate();
            mapping.Version(x => x.Version);
        }
    }

    public class OrderMap : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping)
        {
            mapping.DynamicUpdate();
            mapping.Version(x => x.Version);
        }
    }
}
