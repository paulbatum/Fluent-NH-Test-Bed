using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Console
{
    public class JoinedSubclassConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            StringBuilder keyName = new StringBuilder();
            keyName.Append("FK_");
            keyName.Append(instance.EntityType.Name);
            keyName.Append("_");
            keyName.Append(instance.Key.Columns.First().Name);
            keyName.Remove(keyName.Length - 2, 2);
            instance.Key.ForeignKey(keyName.ToString());
        }
    }
}