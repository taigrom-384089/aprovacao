using Comum.IoC;
using Dominio.InjecaoDependencia.Entidade;
using Dominio.Integracao.Interfaces;
using Dominio.Persistencia.Interfaces;
using Infra.NHibernate;
using Infra.Persistencia.Persistencia;
using Infra.Servico;
using Microsoft.Practices.Unity;

namespace IoC.InversaoControle
{
    public class ConfiguradorDependencias : IConfiguradorDependencias
    {
        public void Configurar()
        {
            ResolvedorDependencia.Configurar(
                (container) =>
                {
                    container.RegisterType(typeof(IServicoLog), typeof(ServicoLog));
                    container.RegisterType<IRepositorioUsuario, RepositorioUsuario>();
                    container.RegisterType<IRepositorioHistoricoAprovacao, RepositorioHistoricoAprovacao>();
                    container.RegisterType<IRepositorioNotaCompra, RepositorioNotaCompra>();
                    container.RegisterType<IRepositorioConfiguracao, RepositorioConfiguracao>();
                    container.RegisterType<ISessionManager, SessionManager>();
                    container.RegisterType<ITransacao, Transacao>();
                });

            SessionProvider.Start();
        }
    }
}
