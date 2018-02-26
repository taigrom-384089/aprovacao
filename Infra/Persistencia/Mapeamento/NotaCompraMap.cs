using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class NotaCompraMap : ClassMap<NotaCompra>
    {
        NotaCompraMap()
        {
            Table("TB_NOTA_COMPRA");
            Id(x => x.Id).Column("ID_NOTA_COMPRA").GeneratedBy.Identity();
            Map(x => x.DataEmissao).Column("DATA_EMISSAO").Not.Nullable();
            Map(x => x.ValorMercadoria).Column("VALOR_MERCADORIA").Length(18).Not.Nullable();
            Map(x => x.ValorDesconto).Column("VALOR_DESCONTO").Length(18).Not.Nullable();
            Map(x => x.ValorFrete).Column("VALOR_FRETE").Length(18).Not.Nullable();
            Map(x => x.ValorTotal).Column("VALOR_TOTAL").Length(18).Not.Nullable();
            Map(x => x.Status).Column("STATUS").Not.Nullable();
            HasMany(x => x.Historicos).Access.CamelCaseField(Prefix.Underscore).Cascade.All().Inverse().KeyColumn("ID_NOTA_COMPRA");
        }
    }
}
