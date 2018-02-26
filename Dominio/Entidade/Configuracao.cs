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
    public class Configuracao 
    {
        public virtual Int32 Id { get; set; }

        public virtual float FaixaInicial { get; set; }

        public virtual float FaixaFinal { get; set; }

        public virtual int Visto { get; set; }

        public virtual int Aprovacao { get; set; }
    }
}
