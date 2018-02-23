using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration = NHibernate.Cfg.Configuration;
using System.Configuration;
using Dominio.InjecaoDependencia.Entidade;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;

namespace Infra.NHibernate
{
    public static class SessionProvider
    {
        private static ISessionFactory sessionFactory;

        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["Minu"].ConnectionString;

        private static ISessionManager _sessionManager;

        static SessionProvider(){ }

        public static void Start()
        {
            var configuration = CreateConfiguration();
            sessionFactory = configuration.BuildSessionFactory();
            _sessionManager = ResolvedorDependencia.Instancia.Resolver<ISessionManager>();
        }

        public static ISessionFactory GetSessionFactory()
        {
            return sessionFactory;
        }

        public static ISession OpenSession()
        {
            var session = _sessionManager.OpenSession(sessionFactory);
            session.FlushMode = FlushMode.Auto;

            return session;
        }

        public static void CloseSession()
        {
            _sessionManager.CloseSession();
        }

        public static Configuration CreateConfiguration()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnString).ShowSql)
                //   .ProxyFactoryFactory<ProxyFactoryFactory>()
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                    m.HbmMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                }
                    )
                .BuildConfiguration();
        }

        public static void CreateSchema()
        {
            var schemaExport = new SchemaExport(CreateConfiguration());
            schemaExport.Drop(true, true);
            schemaExport.Create(true, true);
            schemaExport.Execute(false, true, false);
        }
    }
}
