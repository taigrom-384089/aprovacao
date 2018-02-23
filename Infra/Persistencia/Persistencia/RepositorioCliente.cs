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
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public Cliente BuscarPorCpf(string cpf)
        {
            return Session.QueryOver<Cliente>()
                .WhereLikeCiAi(c => c.Cpf, cpf, MatchMode.Anywhere)
                .SingleOrDefault();
        }

        public IList<Cliente> BuscarPorNome(string nome)
        {
            return Session.QueryOver<Cliente>()
                .WhereLikeCiAi(c => c.Nome, nome, MatchMode.Anywhere)
                .List();
        }

        public Cliente BuscarPorEmail(string email)
        {
            return Session.QueryOver<Cliente>()
                .WhereLikeCiAi(c => c.Email, email, MatchMode.Anywhere)
                .SingleOrDefault();
        }
    }
}
