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
    public class RepositorioCidade : RepositorioBase<Cidade>, IRepositorioCidade
    {
        public Cidade BuscarPorNome(string nome, Int32 idEstado)
        {
            return Session.QueryOver<Cidade>()
                .Where(x => x.Estado.Id == idEstado)
                .WhereRestrictionOn(x => x.Nome)
                .IsInsensitiveLike(nome)
                .SingleOrDefault();
        }

        public IEnumerable<Cidade> Filtar(string nome, Int32? idEstado)
        {
            if (!idEstado.HasValue)
            {
                return Session.QueryOver<Cidade>()
                .WhereLikeCiAi(c => c.Nome, nome, MatchMode.Anywhere)
                .List();
            }
            else
            {
                return Session.QueryOver<Cidade>()
                .Where(x => x.Estado.Id == idEstado.Value)
                .WhereLikeCiAi(c => c.Nome, nome, MatchMode.Anywhere)
                .List();
            }

        }
    }
}
