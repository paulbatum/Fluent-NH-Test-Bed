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
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var group1 = new Group();
                var group2 = new Group();

                session.Save(group1);
                session.Save(group2);

                var user = new User();
                session.Save(user);

                user.Groups[group1] = false;
                user.Groups[group2] = true;

                tx.Commit();
            }


        }

    }
}
