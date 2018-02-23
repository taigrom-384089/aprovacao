using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class CidadeMap : ClassMap<Cidade>
    {
        CidadeMap()
        {
            Table("TB_CIDADE");
            Id(x => x.Id).Column("ID_CIDADE").GeneratedBy.Identity();
            References(x => x.Estado).Column("ID_ESTADO").Not.Nullable().Not.LazyLoad();
            Map(x => x.Nome).Column("NM_CIDADE").Length(150).Not.Nullable();
        }
    }
}
