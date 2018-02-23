using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Estado
    {
        protected IList<Cidade> _cidades;

        public virtual Int32 Id { get; set; }

        public virtual string Nome { get; set; }
       
        public virtual IEnumerable<Cidade> Cidades 
        {
            get
            {
                return _cidades;
            }
        }

        public virtual string UF { get; set; }
    }
}
