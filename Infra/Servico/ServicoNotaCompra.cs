using Dominio.Integracao.Interfaces;
using System.Collections.Generic;
using Dominio.Entidade;
using Infra.Persistencia.Entidade;

namespace Infra.Servico
{
    public class ServicoNotaCompra : IServicoNotaCompra
    {
        public IEnumerable<NotaCompra> Filtrar(string dataInicial, string dataFinal, Usuario usuario)
        {
            return Repositorio.NotasCompra.Filtrar(dataInicial, dataFinal, usuario);
        }
    }
}
