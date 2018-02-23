using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Logradouro 
    {
        public virtual Int32 Id { get; set; }

        public virtual string Nome { get; set; }
       
        public virtual Bairro Bairro { get; set; }
    }
}
