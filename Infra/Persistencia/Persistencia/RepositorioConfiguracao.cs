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
    public class RepositorioConfiguracao : RepositorioBase<Configuracao>, IRepositorioConfiguracao
    {
        public Configuracao BuscarPorFaixa(float faixaInicial, float faixaFinal)
        {
            return Session.QueryOver<Configuracao>()
                .Where(x => x.FaixaInicial >= faixaInicial && x.FaixaFinal <= faixaFinal)
                .SingleOrDefault();
        }
    }
}
