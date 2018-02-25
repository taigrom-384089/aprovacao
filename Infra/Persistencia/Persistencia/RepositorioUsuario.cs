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
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public Usuario Autenticar(string login, string senha)
        {
            return Session.QueryOver<Usuario>()
                .Where(u => u.Login == login && u.Senha == senha)
                .SingleOrDefault();
        }
    }
}
