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
            HasManyToMany(x => x.Groups)
                .Cascade.All();                
            
        }
    }

    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(x => x.GroupId);
            HasManyToMany(x => x.Customers)
                .Inverse();                
        }
    }


}
