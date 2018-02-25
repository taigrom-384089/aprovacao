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
             
        public static ITransacao Transacao
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<ITransacao>();
            }
        }
    }
}
