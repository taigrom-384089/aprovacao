using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class ItemNotaMap : ClassMap<ItemNota>
    {
        ItemNotaMap()
        {
            Table("TB_ITEM_NOTA");
            Id(x => x.Id).Column("ID_ITEM_NOTA").GeneratedBy.Identity();
            Map(x => x.Descricao).Column("DESCRICAO").Not.Nullable();
            Map(x => x.Quantidade).Column("QUANTIDADE").Not.Nullable();
            References(x => x.NotaCompra).Column("ID_NOTA_COMPRA");
        }
    }
}
