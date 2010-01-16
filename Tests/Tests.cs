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
                var creditCard = new CreditCard { Balance = 2000 };
                var carLoan = new CarLoan { Balance = 7000 };

                var application = new LoanApplication { ExistingDebts = { creditCard, carLoan } };

                session.Save(application);
                tx.Commit();
            }

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var application = session.Get<LoanApplication>(1);
                Assert.That(application.ExistingDebts, Has.Count.EqualTo(2));

            }

        }

    }
}
