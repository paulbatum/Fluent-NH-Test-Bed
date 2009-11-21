using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Console
{
   public class StoreMap : IAutoMappingOverride<Store>
   {
       public void Override(AutoMapping<Store> mapping)
       {
           mapping.HasMany(x => x.Managers)
               .Cascade.All()
               .Where("(IsManager = 1)");
           mapping.HasMany(x => x.Staff)
               .Cascade.All()
               .Where("(IsManager = 0)");
       }
   }
}
