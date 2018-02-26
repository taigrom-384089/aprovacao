using Comum.Exceptions;
using Comum.Recursos;
using Comum.Util;
using Dominio.Integracao;
using Dominio.Persistencia.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Usuario 
    {
        public virtual Int32 Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }

        public virtual int Papel { get; set; }

        public virtual float ValorMinVistoAprovacao { get; set; }

        public virtual float ValorMaxVistoAprovacao { get; set; }
    }
}
