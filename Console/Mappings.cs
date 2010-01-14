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
            Map(x => x.FirstName);

            HasManyToMany(x => x.Parents)
                .ParentKeyColumn("ChildID")
                .ChildKeyColumn("ParentID")
                .Inverse();
            
            HasManyToMany(x => x.Children)
                .ParentKeyColumn("ParentID")
                .ChildKeyColumn("ChildID");
        }
    }


}
