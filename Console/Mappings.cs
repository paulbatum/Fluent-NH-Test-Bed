using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);

            HasMany(x => x.Ratings)
                .KeyColumn("BOOK_ID")                
                .Table("BOOK_RATINGS")
                .Component(c =>
                {
                    c.Map(x => x.UserId, "USER_ID");
                    c.Map(x => x.Value, "VALUE");
                })
                .Cascade.SaveUpdate();

        }
    }

    public class CDMap : ClassMap<CD>
    {
        public CDMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);

            HasMany(x => x.Ratings)
                .KeyColumn("CD_ID")
                .Table("CD_RATINGS")
                .Component(c =>
                {
                    c.Map(x => x.UserId, "USER_ID");
                    c.Map(x => x.Value, "VALUE");
                })
                .Cascade.SaveUpdate();

        }
    }




}
