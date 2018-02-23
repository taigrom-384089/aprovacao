using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class CepMap : ClassMap<Cep>
    {
        CepMap()
        {
            Table("TB_CEP");
            Id(x => x.Id).Column("ID_CEP").GeneratedBy.Identity();
            References(x => x.Logradouro).Column("ID_LOGRADOURO").Not.Nullable().Not.LazyLoad();
            Map(x => x.CepLogradouro).Column("CEP").Length(10).Not.Nullable();
        }
    }
}
