using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class LogradouroMap : ClassMap<Logradouro>
    {
        LogradouroMap()
        {
            Table("TB_LOGRADOURO");
            Id(x => x.Id).Column("ID_LOGRADOURO").GeneratedBy.Identity();
            References(x => x.Bairro).Column("ID_BAIRRO").Not.Nullable().Not.LazyLoad();
            Map(x => x.Nome).Column("NM_LOGRADOURO").Length(150).Not.Nullable();
        }
    }
}
