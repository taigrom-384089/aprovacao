using Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Mapeamento
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        EnderecoMap()
        {
            Table("TB_ENDERECO");
            Id(x => x.Id).Column("ID_ENDERECO").GeneratedBy.Identity();
            References(x => x.Cliente).Column("ID_CLIENTE").Not.Nullable();
            References(x => x.Cep).Column("ID_CEP").Not.Nullable().Not.LazyLoad();
            Map(x => x.Numero).Column("NUMERO").Length(10).Not.Nullable();
        }
    }
}
