using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        UsuarioMap()
        {
            Table("TB_USUARIO");
            Id(x => x.Id).Column("ID_USUARIO").GeneratedBy.Identity();
            Map(x => x.Login).Column("LOGIN").Length(20).Not.Nullable();
            Map(x => x.Senha).Column("SENHA").Length(8).Not.Nullable();
            Map(x => x.Papel).Column("PAPEL").Not.Nullable();
            Map(x => x.ValorMinVistoAprovacao).Column("VALOR_MIN_VISTO_APROVACAO").Length(18).Not.Nullable();
            Map(x => x.ValorMaxVistoAprovacao).Column("VALOR_MAX_VISTO_APROVACAO").Length(18).Not.Nullable();
        }
    }
}
