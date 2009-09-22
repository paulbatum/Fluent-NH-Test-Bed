using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Console
{
    public class EntityAMap : IAutoMappingOverride<TestEntityA>
    {
        public void Override(AutoMapping<TestEntityA> mapping)
        {
            mapping.HasMany(x => x.Children)                
                .Cascade.All();
        }
    }
}
