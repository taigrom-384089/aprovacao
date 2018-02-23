using Dominio.Integracao.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Servico
{
    public class ServicoLog : IServicoLog
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(typeof(ServicoLog));

        public void Erro(string mensagem)
        {
            log.Error(mensagem);
        }
    }
}
