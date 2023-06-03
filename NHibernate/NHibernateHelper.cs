using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using PublishingCenter_v2.NHibernate.Data;

namespace PublishingCenter_v2.NHibernate
{
    public class NHibernateHelper
    {
        public NHibernateHelper()
        {
            InitializeSessionFactory();
        }

        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            _sessionFactory = Fluently.Configure()
              .Database(PostgreSQLConfiguration.Standard.ConnectionString(@"server=localhost;Port=5432;Database=PublishingCenter;User Id=postgres;Password=12345;"))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Writers>())
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contracts>())
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Customers>())
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Books>())
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Orders>())
              .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
              .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
