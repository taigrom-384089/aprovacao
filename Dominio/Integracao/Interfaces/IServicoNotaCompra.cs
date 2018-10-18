using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Integracao.Interfaces
{
    public interface IServicoNotaCompra
    {
        IEnumerable<NotaCompra> Filtrar(string dataInicial, string dataFinal, Usuario usuario);
    }
}
