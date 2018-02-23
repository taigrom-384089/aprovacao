using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
{
    public interface IRepositorioCep : IRepositorioBase<Cep>
    {
        Cep BuscarPorCep(string cep);
    }
}
