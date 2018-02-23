using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Bairro
    {
        protected IList<Logradouro> _logradouros;

        public virtual Int32 Id { get; set; }

        public virtual string Nome { get; set; }
       
        public virtual IEnumerable<Logradouro> Logradouros 
        {
            get
            {
                return _logradouros;
            }
        }

        public virtual Cidade Cidade { get; set; }
    }
}
