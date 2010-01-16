using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Console
{
   public class LoanApplicationMap : IAutoMappingOverride<LoanApplication>
   {
       public void Override(AutoMapping<LoanApplication> mapping)
       {
           mapping.HasManyToMany(x => x.ExistingDebts)
               .Cascade.All();
       }
   }
}
