using HibernatingRhinos.NHibernate.Profiler.Appender;

namespace Console
{
    class Program
    {

        static void Main(string[] args)
        {
            NHibernateProfiler.Initialize();
            var sessionFactory = Setup.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {


                tx.Commit();
            }
            System.Console.ReadLine();
        }


       
    }
}
