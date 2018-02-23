using Dominio.InjecaoDependencia.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comum.Util;
using Dominio.Integracao.Interfaces;

namespace Dominio.Integracao
{
    public class Integrador
    {
        public static IServicoLog ServicoLog
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IServicoLog>();
            }
        }
    }
}
