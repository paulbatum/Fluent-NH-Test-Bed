using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class EntityBaseMap<T> : ClassMap<T> where T : EntityBase
    {
        public EntityBaseMap()
        {
            Id(x => x.Key);
        }
    }

    public class JobMap : EntityBaseMap<Job>
    {
        public JobMap()
        {
            Map(x => x.NotServedPenalty);
            HasMany(x => x.Stops)
                .Inverse()
                .Cascade.All();
        }
    }

    public class StopMap : EntityBaseMap<Stop>
    {
        public StopMap()
        {
            
        }
    }
}
