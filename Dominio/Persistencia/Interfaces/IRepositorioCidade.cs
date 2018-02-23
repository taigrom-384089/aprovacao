using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
{
    public interface IRepositorioCidade : IRepositorioBase<Cidade>
    {
        Cidade BuscarPorNome(string nome, Int32 idEstado);

        IEnumerable<Cidade> Filtar(string nome, Int32? idEstado);
    }
}
