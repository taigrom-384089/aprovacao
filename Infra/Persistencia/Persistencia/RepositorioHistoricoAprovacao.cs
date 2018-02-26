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
    public class RepositorioHistoricoAprovacao : RepositorioBase<HistoricoAprovacao>, IRepositorioHistoricoAprovacao
    {
        public IEnumerable<HistoricoAprovacao> BuscarPorUsuario(int idUsuario)
        {
            return Session.QueryOver<HistoricoAprovacao>()
                .JoinQueryOver(x => x.Usuario)
                .Where(x => x.Id == idUsuario)
                .List();
        }
    }
}
