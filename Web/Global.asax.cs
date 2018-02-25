using Dominio.InjecaoDependencia.Entidade;
using Dominio.Integracao.Interfaces;
using Dominio.Persistencia.Interfaces;
using Infra.NHibernate;
using Infra.Persistencia.Persistencia;
using Infra.Servico;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private void ConfigurarIoC()
        {
            ResolvedorDependencia.Configurar(
                (container) =>
                {
                    container.RegisterType(typeof(IServicoLog), typeof(ServicoLog));
                    container.RegisterType<IRepositorioUsuario, RepositorioUsuario>();
                    container.RegisterType<ISessionManager, SessionManager>();
                    container.RegisterType<ITransacao, Transacao>();
                });
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigurarIoC();

            SessionProvider.Start();
        }
    }
}