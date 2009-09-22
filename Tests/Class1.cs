using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console;
using Domain;
using FluentNHibernate.Testing;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
        }

        [Test]
        public void CanSaveChildEntities()
        {
            var sessionFactory = Setup.CreateSessionFactory();

            IList<TestEntityB> list = new List<TestEntityB> { new TestEntityB{Comment = "Test"}};

            using (var session = sessionFactory.OpenSession())
            {
                var a = new TestEntityA {Name = "testA"};
                var b = new TestEntityB {Comment = "commentB"};
                a.AddChild(b);

                session.Save(a);                
                
            }
        }
    }
}
