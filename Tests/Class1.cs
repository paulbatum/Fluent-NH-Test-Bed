using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console;
using Domain;
using FluentNHibernate.Testing;
using NHibernate;
using NUnit.Framework;
using System.Collections;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        private ISessionFactory _sessionFactory;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
            _sessionFactory = Setup.CreateSessionFactory();
        }

        [Test]
        public void CanSaveChildEntities()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                Role r;
                Privilege p = new Privilege();                
                p.Path = "*.a";
                foreach (DefaultRoleNames name in Enum.GetValues(typeof
     (DefaultRoleNames)))
                {
                    r = new Role();
                    r.TypeOfContent = typeof (Privilege);
                    r.Name = name;
                    r.AddPrivilege(p); ;
                    session.Save(r);
                }

                tx.Commit();
            }
        }

    }
}
