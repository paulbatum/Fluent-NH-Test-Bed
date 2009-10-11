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
        private static string _dbFile;


        public static ISessionFactory CreateSessionFactory()
        {
            //_dbFile = "firstProject.db";
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005
                    .ConnectionString(c => c.Server(@"localhost\sqlexpress")
                                               .Database("TestDB")
                                               .TrustedConnection()
                                               )                                               
                    .ShowSql()
                )
                .Mappings(m =>
                {                    
                    //m.AutoMappings.Add(
                    //    AutoMap.AssemblyOf<TestEntityA>()
                    //        .IgnoreBase(typeof(EntityBase<>))
                    //        .UseOverridesFromAssemblyOf<Program>()
                    //        .Conventions.AddFromAssemblyOf<Program>()
                    //    );
                    //m.AutoMappings.First().MergeMappings = true;                    
                    //m.AutoMappings.ExportTo("mappings");

                    m.FluentMappings.AddFromAssemblyOf<Program>();
                    m.FluentMappings.Conventions.AddFromAssemblyOf<Program>();
                    m.FluentMappings.ExportTo("mappings");
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
