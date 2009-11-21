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
    public class Tests
    {
        private ISessionFactory _sessionFactory;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
            _sessionFactory = Setup.CreateSessionFactory();
        }

        [Test]
        public void Test1()
        {
            int id = 0;

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                Store s = new Store();
                s.AddStaff(new Employee { FirstName = "Staff1"});
                s.AddStaff(new Employee { FirstName = "Staff2" });
                s.AddManager(new Employee { FirstName = "Manager1" });
                
                session.Save(s);
                id = s.Id;
                tx.Commit();
            }

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                Store s = session.Get<Store>(id);
                Assert.AreEqual(2, s.Staff.Count);
                Assert.AreEqual(1, s.Managers.Count);

            }
        }

    }
}
