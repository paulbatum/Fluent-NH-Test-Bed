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
                var customer1 = new Customer()
                {
                    Birthday = DateTime.Today,
                    FirstName = "Parent"
                };

                var customer2 = new Customer()
                {
                    Birthday = DateTime.Today,
                    FirstName = "Child"
                };

                customer1.Children.Add(customer2);
                customer2.Parents.Add(customer1);

                session.Save(customer1);
                session.Save(customer2);

                tx.Commit();
            }

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                Customer parent = session.CreateQuery("from Customer cust where cust.FirstName = 'Parent'").UniqueResult<Customer>();
                Assert.That(parent.Children.First().FirstName, Is.EqualTo("Child"));
            }


        }

    }
}
