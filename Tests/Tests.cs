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
                var book = new Book() {Title = "Domain Driven Design"};
                book.Ratings.Add(new Rating() { UserId = 1, Value = 10});
                book.Ratings.Add(new Rating() { UserId = 2, Value = 8 });

                var cd = new CD() {Title = "Lateralus"};
                cd.Ratings.Add(new Rating() { UserId = 1, Value = 9 });
                cd.Ratings.Add(new Rating() { UserId = 2, Value = 7 });

                session.Save(book);
                session.Save(cd);

                tx.Commit();
            }


        }

    }
}
