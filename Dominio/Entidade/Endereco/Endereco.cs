using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Endereco
    {
        public virtual Int32 Id { get; set; }

        public virtual Cep Cep { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual string Numero { get; set; }
    }
}
