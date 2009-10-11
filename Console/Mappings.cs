using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class CustomerMap : SubclassMap<Customer>
    {
        public CustomerMap()
        {
            KeyColumn("PersonID");
            Map(x => x.CustomerSince).Not.Nullable();
        }
    }

    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.MiddleInitial);
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.DOB);
            Map(x => x.Email);
        }
    }
}
