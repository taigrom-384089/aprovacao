using Dominio.InjecaoDependencia.Entidade;
using Dominio.Persistencia.Interfaces;

namespace Dominio.Persistencia.Entidade
{
    public class Repositorio 
    {
        public static IRepositorioUsuario Usuarios
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioUsuario>();
            }
        }

        public static IRepositorioNotaCompra NotasCompra
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioNotaCompra>();
            }
        }

        public static IRepositorioHistoricoAprovacao Historicos
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioHistoricoAprovacao>();
            }
        }

        public static IRepositorioConfiguracao Configuracoes
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioConfiguracao>();
            }
        }
             
        public static ITransacao Transacao
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<ITransacao>();
            }
        }
    }
}
