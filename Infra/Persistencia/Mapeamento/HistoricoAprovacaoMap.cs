using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class HistoricoAprovacaoMap : ClassMap<HistoricoAprovacao>
    {
        HistoricoAprovacaoMap()
        {
            Table("TB_HISTORICO_APROVACAO");
            Id(x => x.Id).Column("ID_HISTORICO_APROVACAO").GeneratedBy.Identity();
            References(x => x.Usuario).Column("ID_USUARIO");
            References(x => x.NotaCompra).Column("ID_NOTA_COMPRA");
            Map(x => x.Operacao).Column("OPERACAO").Not.Nullable();
            Map(x => x.Data).Column("DATA").Not.Nullable();
        }
    }
}
