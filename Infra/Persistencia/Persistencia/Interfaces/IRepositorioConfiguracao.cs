using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Interfaces
{
    public interface IRepositorioConfiguracao : IRepositorioBase<Configuracao>
    {
        Configuracao BuscarPorFaixa(float faixaInicial, float faixaFinal);
    }
}
