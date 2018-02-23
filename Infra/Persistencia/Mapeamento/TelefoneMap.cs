using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class TelefoneMap : ClassMap<Telefone>
    {
        TelefoneMap()
        {
            Table("TB_TELEFONE");
            Id(x => x.Id).Column("ID_TELEFONE").GeneratedBy.Identity();
            References(x => x.Cliente).Column("ID_CLIENTE").Nullable();
            Map(x => x.Ddd).Column("DDD").Length(3).Not.Nullable();
            Map(x => x.NumeroTelefone).Column("NU_TELEFONE").Length(10).Not.Nullable();
            Map(x => x.NumeroTelefoneComDDD).Formula("CONCAT(DDD, NU_TELEFONE)");
        }
    }
}
