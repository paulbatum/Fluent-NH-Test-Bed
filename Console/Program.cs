using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Domain;

namespace Console
{
    class Program
    {
        private static string _dbFile;

        static void Main(string[] args)
        {
            //System.Console.ReadLine();
            var sessionFactory = CreateSessionFactory();
            System.Console.ReadLine();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            _dbFile = "firstProject.db";
            return Fluently.Configure()
                .Database(
                SQLiteConfiguration.Standard
                    .UsingFile(_dbFile)
                    .ShowSql()
                )
                .Mappings(m =>
                          {

                              //m.AutoMappings.Add(
                              //    AutoMap.AssemblyOf<TestEntityA>()
                              //        .IgnoreBase(typeof(EntityBase<>))
                              //        .UseOverridesFromAssemblyOf<Program>()
                              //        .Conventions.AddFromAssemblyOf<Program>()
                              //        .Setup(x => x.IsComponentType = type => type == typeof(Address))
                              //    );
                              //m.AutoMappings.ExportTo("mappings");                              

                              m.FluentMappings.Add(typeof(TestEntityAFluentMap))
                                .Conventions.AddFromAssemblyOf<Program>();

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
