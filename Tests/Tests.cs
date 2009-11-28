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
                var sheet = new CashBalanceSheet();
                sheet.Transactions.Add(new Transaction { DollarAmount = 500, TransactionDate = DateTime.Now});
                
                session.Save(sheet);
                id = sheet.ClaimId;
                tx.Commit();
            }

            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var sheet = session.Get<CashBalanceSheet>(id);
                sheet.Transactions.Remove(sheet.Transactions.First());

                tx.Commit();
            }
        }

    }
}
