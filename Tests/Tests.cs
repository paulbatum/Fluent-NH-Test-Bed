using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var customer = new Customer()
                {
                    Birthday = DateTime.Today,
                    FirstName = "Paul",
                    LastName = "Batum",
                    Address = new Address()
                    {
                        StreetNumber = 33,
                        Street = "Mort St",
                        PostCode = 2612
                    }
                };

                session.Save(customer);
                tx.Commit();
            }

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Get<Customer>(1);
                Debug.WriteLine("Loaded customer");
                Debug.WriteLine(customer.Address.PostCode);
            }


        }

    }
}
