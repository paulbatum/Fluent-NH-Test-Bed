using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
   public class TripMap : ClassMap<Trip>
   {
       public TripMap()
       {
           Id(x => x.Id);
           Component(x => x.Origin, c =>
           {
               c.Map(x => x.X).Column("OriginX");
               c.Map(x => x.Y).Column("OriginY");
           });
           Component(x => x.Destination, c =>
           {
               c.Map(x => x.X).Column("DestinationX");
               c.Map(x => x.Y).Column("DestinationY");
           });

       }
   }
}
