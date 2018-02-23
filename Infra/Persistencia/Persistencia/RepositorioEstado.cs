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

namespace Infra.Persistencia.Persistencia
{
    public class RepositorioEstado : RepositorioBase<Estado>, IRepositorioEstado
    {
        public Estado BuscarPorNome(string nome)
        {
            return Session.QueryOver<Estado>().WhereRestrictionOn(x => x.Nome).IsLike(nome).SingleOrDefault();
        }

        public Estado BuscarPelaSigla(string sigla)
        {
            return Session.QueryOver<Estado>().WhereRestrictionOn(x => x.UF).IsLike(sigla).SingleOrDefault();
        }

        public IEnumerable<Estado> Filtar(string nome)
        {
            return Session.QueryOver<Estado>().WhereRestrictionOn(x => x.Nome).IsLike("%" + nome + "%").List();
        }
    }
}
