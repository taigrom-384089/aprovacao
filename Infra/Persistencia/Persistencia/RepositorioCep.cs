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
    public class RepositorioCep : RepositorioBase<Cep>, IRepositorioCep
    {
        public Cep BuscarPorCep(string cep)
        {
            var cepLogradouro = Session.QueryOver<Cep>()
                .WhereRestrictionOn(u => u.CepLogradouro)
                .IsLike("%" + cep.ToLower().Trim() + "%")
                .SingleOrDefault();

            return cepLogradouro;
        }
    }
}
