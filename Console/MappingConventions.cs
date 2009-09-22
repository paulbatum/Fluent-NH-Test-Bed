using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Console
{
    public class AccessAsUnderscoredCamelCaseFieldConvention :
        IPropertyConvention, IHasManyConvention, IReferenceConvention
    {
        #region IHasManyConvention Members

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField(CamelCasePrefix.Underscore);
            //instance.Access.CamelCaseField(CamelCasePrefix.Underscore);
        }

        #endregion

        #region IPropertyConvention Members

        public void Apply(IPropertyInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField(CamelCasePrefix.Underscore);
        }

        #endregion

        #region IReferenceConvention Members

        public void Apply(IManyToOneInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField(CamelCasePrefix.Underscore);
        }

        #endregion
    }
}