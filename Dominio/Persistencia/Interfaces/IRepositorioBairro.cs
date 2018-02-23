using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
{
    public interface IRepositorioBairro : IRepositorioBase<Bairro>
    {
        Bairro BuscarPorNome(string nome);

        IEnumerable<Bairro> Filtar(string nome);
    }
}
