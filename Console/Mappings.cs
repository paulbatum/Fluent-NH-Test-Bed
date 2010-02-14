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
            Id(x => x.Id);
            Map(x => x.FirstName);
            HasManyToMany<Book>(x => x.FavouriteBooks)
                .Table("FavouriteBooks")                
                .ParentKeyColumn("CustomerID")
                .ChildKeyColumn("BookID")
                .AsMap<string>("Nickname")                
                .Cascade.All();
                
                
        }
    }

    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }



}
