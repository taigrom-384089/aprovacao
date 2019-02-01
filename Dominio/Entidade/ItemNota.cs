using Comum.Exceptions;
using Comum.Recursos;
using Comum.Util;
using Dominio.Persistencia.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Entidade
{
    public class ItemNota 
    {
        public virtual Int32 Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual int Quantidade { get; set; }

        public virtual NotaCompra NotaCompra { get; set; }
        
    }
}
