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
    public class HistoricoAprovacao 
    {
        public virtual Int32 Id { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual NotaCompra NotaCompra { get; set; }

        public virtual int Operacao { get; set; }

        public virtual DateTime Data { get; set; }
    }
}
