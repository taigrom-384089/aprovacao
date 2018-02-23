using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Cep 
    {
        public virtual Int32 Id { get; set; }

        public virtual string CepLogradouro { get; set; }

        public virtual Logradouro Logradouro { get; set; }
    }
}
