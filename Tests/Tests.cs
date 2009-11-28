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
            int customerId = 0;
            int cardId = 0;

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = new Customer();
                var creditCard = new CreditCard();

                customer.AddCreditCard(creditCard);

                session.Save(customer);
                customerId = customer.ID;
                tx.Commit();
            }

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Get<Customer>(customerId);
                Assert.NotNull(customer.CreditCard);

                cardId = customer.CreditCard.ID;
                session.Delete(customer);
                tx.Commit();
            }

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var card = session.Get<CreditCard>(cardId);
                Assert.IsNull(card);
            }
        }

    }
}
