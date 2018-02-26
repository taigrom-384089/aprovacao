using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class ConfiguracaoMap : ClassMap<Configuracao>
    {
        ConfiguracaoMap()
        {
            Table("TB_CONFIGURACAO");
            Id(x => x.Id).Column("ID_CONFIGURACAO").GeneratedBy.Identity();
            Map(x => x.FaixaInicial).Column("FAIXA_INICIAL").Length(18).Not.Nullable();
            Map(x => x.FaixaFinal).Column("FAIXA_FINAL").Length(18).Not.Nullable();
            Map(x => x.Visto).Column("VISTO").Not.Nullable();
            Map(x => x.Aprovacao).Column("APROVACAO").Not.Nullable();
        }
    }
}
