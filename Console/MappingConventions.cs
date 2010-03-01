using System;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Console
{
   public class ComponentConvention : IComponentConvention
   {
       public void Apply(IComponentInstance instance)
       {
           instance.LazyLoad();
       }
   }
}