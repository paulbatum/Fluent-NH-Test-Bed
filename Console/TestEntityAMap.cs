using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.ClassBased;

namespace Console
{
    public class TestEntityAMap : IAutoMappingOverride<TestEntityA>
    {
        public void Override(AutoMapping<TestEntityA> mapping)
        {

            //mapping.Component(x => x.Address, c =>
            //                                  {
            //                                      c.Map(x => x.Line1, "address_street");
            //                                      c.Map(x => x.Line2, "address_street2");
            //                                  });
        }
    
    }

    public class AddressMap : IAutoMappingOverride<Address>
    {
        public void Override(AutoMapping<Address> mapping)
        {
            //mapping.Map(x => x.Line1);
            //mapping.Map(x => x.Line2);
        }
    }

    public class TestEntityAFluentMap : ClassMap<TestEntityA>
    {
        public TestEntityAFluentMap()
        {
            Id(x => x.Id);
            Component(x => x.Address,  c =>   {
                                                  c.Map(x => x.Line1);
                                                  c.Map(x => x.Line2);
                                              });
        }
    }


    public class ComponentOverride : IComponentConvention
    {
        public void Apply(IComponentInstance instance)
        {
            var fieldInfo = typeof (ComponentInstance).GetField("mapping", BindingFlags.Instance | BindingFlags.NonPublic);
            var componentMapping = (ComponentMapping) fieldInfo.GetValue(instance);

            foreach (var propertyMapping in componentMapping.Properties)
            {
                ColumnMapping column = propertyMapping.Columns.Defaults.First();
                column.Name = instance.Name + column.Name;
            }
        }
    }


    public class HasManyAccessOverride : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Access.CamelCaseField(CamelCasePrefix.Underscore);
        }
    }

    public class DefaultLazyOverride : IHibernateMappingConvention
    {
        public void Apply(IHibernateMappingInstance instance)
        {
            //if(instance.EntityType == typeof(TestEntityA))
            //    instance.Not.DefaultLazy();
        }
    }
}
