using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Cidade 
    {
        private string _nome;
        protected IList<Bairro> _bairros;

        public virtual Int32 Id { get; set; }

        public virtual string Nome { get; set; }
        
        public virtual IEnumerable<Bairro> Bairros 
        {
            get
            {
                return _bairros;
            }
        }

        public virtual Estado Estado { get; set; }

        public virtual void AdicionaBairro(string nome)
        {

        }
    }
}
