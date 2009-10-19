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
        public void Test1()
        {
            int id;

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
 
                var c = new Customer
                {
                    FirstName = "Paul",
                    Orders =
                        {
                            new Order
                            {
                                Quantity = 5
                            }
                        }
                };
                session.Save(c);
                tx.Commit();

                id = c.Id;
            }

             using (var session = _sessionFactory.OpenSession())
             {
                 var c2 = session.Get<Customer>(id);
                 System.Diagnostics.Debug.WriteLine(c2.FirstName);
             }
        }

    }
}
