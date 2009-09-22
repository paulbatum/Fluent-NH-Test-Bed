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

        static void Main(string[] args)
        {
            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
            //System.Console.ReadLine();
            var sessionFactory = Setup.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                var a = new TestEntityA { Name = "testA" };
                var b = new TestEntityB { Comment = "commentB" };
                a.AddChild(b);

                session.Save(a);

                tx.Commit();
            }
            System.Console.ReadLine();
        }


       
    }
}
