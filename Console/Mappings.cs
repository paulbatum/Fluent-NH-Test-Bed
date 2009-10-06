using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.TypeOfContent)
                .Access.CamelCaseField(Prefix.Underscore)
                .CustomType<string>();
            HasManyToMany(x => x.Privileges)
                .Cascade.All()
                .Table("RolePrivilege");
            Table("roles");
        }
    }

    public class PrivilegeMap : ClassMap<Privilege>
    {
        public PrivilegeMap()
        {
            Id(x => x.Id);
            Map(x => x.Path).Not.Nullable();
            HasManyToMany(x => x.RolesWithThisPrivilege)
                .Cascade.All()
                .Inverse()
                .Table("RolePrivilege");
            Table("privileges");
        }
    }
}
