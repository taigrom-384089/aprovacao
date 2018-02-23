using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Telefone : IEntidade
    {
        public virtual Int32 Id { get; set; }

        public virtual string Ddd { get; set; }
       
        public virtual string NumeroTelefone { get; set; }
       
        public virtual string NumeroTelefoneComDDD { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual void Validar()
        {

        }
    }
}
