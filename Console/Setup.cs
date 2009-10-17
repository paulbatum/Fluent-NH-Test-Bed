using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Console
{
    public class Setup
    {
        private static string _dbFile = "firstProject.db";


        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(_dbFile)
                        .ShowSql()                
                )
                .Mappings(m =>
                {
                    m.AutoMappings.Add(
                        AutoMap.AssemblyOf<Customer>()
                            .Where(t => t.Namespace == "Domain")
                            .Setup(e => e.IsComponentType = x => x == typeof(Address))
                            //.IgnoreBase(typeof(EntityBase<>))                            
                            //.UseOverridesFromAssemblyOf<Program>()
                            //.Conventions.AddFromAssemblyOf<Program>()
                        );
                    m.AutoMappings.First().MergeMappings = true;
                    m.AutoMappings.ExportTo("mappings");

                    //m.FluentMappings.AddFromAssemblyOf<Program>();
                    //m.FluentMappings.Conventions.AddFromAssemblyOf<Program>();
                    //m.FluentMappings.ExportTo("mappings");
                }


                )                
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(_dbFile))
                File.Delete(_dbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(true, true);
        }
    }
}
