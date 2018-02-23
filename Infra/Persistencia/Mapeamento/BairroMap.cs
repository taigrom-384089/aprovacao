using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class BairroMap : ClassMap<Bairro>
    {
        BairroMap()
        {
            Table("TB_BAIRRO");
            Id(x => x.Id).Column("ID_BAIRRO").GeneratedBy.Identity();
            References(x => x.Cidade).Column("ID_CIDADE").Not.Nullable().Not.LazyLoad();
            Map(x => x.Nome).Column("NM_BAIRRO").Length(150).Not.Nullable();
        }
    }
}
