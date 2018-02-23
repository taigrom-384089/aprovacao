using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        Cliente BuscarPorCpf(string cpf);

        IList<Cliente> BuscarPorNome(string nome);

        Cliente BuscarPorEmail(string email);

    }
}
