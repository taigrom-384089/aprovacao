using Dominio.Entidade;
using Dominio.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comum.Util;
using System.Collections.ObjectModel;
using NHibernate;
using Infra.NHibernate;
using NHibernate.Criterion;

namespace Infra.Persistencia.Persistencia
{
    public class RepositorioNotaCompra : RepositorioBase<NotaCompra>, IRepositorioNotaCompra
    {
        public IEnumerable<NotaCompra> Filtrar(string dataInicial, string dataFinal, Usuario usuario)
        {
            IQueryOver<NotaCompra, NotaCompra> query = Session.QueryOver<NotaCompra>();
            IQueryOver<HistoricoAprovacao, Usuario> joinHistoricos = Session.QueryOver<HistoricoAprovacao>()
                                                                    .JoinQueryOver(x => x.Usuario)
                                                                    .Where(x => x.Id == usuario.Id);

            query = query.Where(x => x.ValorTotal >= usuario.ValorMinVistoAprovacao &&
                                            x.ValorTotal <= usuario.ValorMaxVistoAprovacao &&
                                            //x.StatusOperacao == usuario.Papel &&
                                            x.Status == (byte)TipoStatus.Pendente);


            int[] ids = joinHistoricos.List().Select(x => x.NotaCompra.Id).ToArray(); 

            query.WhereNot(x => x.Id.IsIn(ids));

            if (!string.IsNullOrEmpty(dataInicial) && !string.IsNullOrEmpty(dataFinal))
            {
                var dtInicial = DateTime.Parse(dataInicial);
                var dtFinal = DateTime.Parse(dataFinal);
                query = query.Where(x => x.DataEmissao >= dtInicial.Date && x.DataEmissao.Date <= dtFinal);
            }

            if (!string.IsNullOrEmpty(dataInicial))
            {
                var dtInicial = DateTime.Parse(dataInicial);
                query = query.Where(x => x.DataEmissao >= dtInicial.Date && x.DataEmissao.Date <= DateTime.Now.Date);
            }

            if (!string.IsNullOrEmpty(dataFinal))
            {
                var dtFinal = DateTime.Parse(dataFinal);
                query = query.Where(x => x.DataEmissao.Date <= dtFinal);
            }

            return query.List();
        }

        public IEnumerable<NotaCompra> Listar()
        {
            var query = Session.QueryOver<NotaCompra>();
                
            var result = query.List();

            return null;
        }
    }
}
