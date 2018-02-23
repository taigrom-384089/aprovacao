using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class ClienteMap : ClassMap<Cliente>
    {
        ClienteMap()
        {
            Table("TB_CLIENTE");
            Id(x => x.Id).Column("ID_CLIENTE").GeneratedBy.Identity();
            Map(x => x.Cpf).Column("CPF").Length(11).Not.Nullable();
            Map(x => x.Nome).Column("NM_CLIENTE").Length(150).Not.Nullable();
            Map(x => x.Email).Column("EMAIL").Length(255).Not.Nullable();
            Map(x => x.MaritalStatus).Column("MARITAL_STATUS").Not.Nullable();
            HasMany(x => x.Telefones).Access.CamelCaseField(Prefix.Underscore).Inverse().KeyColumn("ID_CLIENTE");
            HasOne(x => x.Endereco).PropertyRef(c => c.Cliente).Cascade.All().ForeignKey("ID_CLIENTE").Not.LazyLoad();
        }
    }
}
