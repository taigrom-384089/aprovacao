using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
{
    public interface IRepositorioEstado : IRepositorioBase<Estado>
    {
        Estado BuscarPorNome(string nome);

        Estado BuscarPelaSigla(string sigla);

        IEnumerable<Estado> Filtar(string nome);
    }
}
