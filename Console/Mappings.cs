using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.ID);

            HasManyToMany(x => x.Groups)
                .AsMap<Group>("indexColName")
                .Element("elementColName", ep => ep.Type<bool>());
                    
                
        }
    }

    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(x => x.ID);            
        }
    }


}
