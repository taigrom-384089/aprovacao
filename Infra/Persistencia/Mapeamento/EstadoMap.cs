using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class EstadoMap : ClassMap<Estado>
    {
        EstadoMap()
        {
            Table("TB_ESTADO");
            Id(x => x.Id).Column("ID_ESTADO").GeneratedBy.Identity();
            Map(x => x.Nome).Column("NM_ESTADO").Length(50).Not.Nullable();
            Map(x => x.UF).Column("ESTADO_ABREVIADO").Length(2).Nullable();
        }
    }
}
