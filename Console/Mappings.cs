using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class FooMap : ClassMap<Foo>
    {
        public FooMap()
        {
            Id(x => x.Id);

            Component<Bar>(x => x.Bar, m =>
            {
                m.Map(x => x.Text);
            });
        }
    }

}
