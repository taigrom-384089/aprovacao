using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InjecaoDependencia.Interfaces
{
    public interface IResolvedorDependencia
    {
        T Resolver<T>();

        IEnumerable<T> ResolverTodos<T>();
    }
}
