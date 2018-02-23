using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Comum.Exceptions
{
    [Serializable]
    public class LogException : Exception
    {
        public Exception Exception { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

        public LogException()
            :base()
        {

        }

        public LogException(string mensagem)
            : base(mensagem)
        {

        }

        public LogException(string mensagem, Exception ex)
            : base(mensagem)
        {
            this.Exception = ex;
        }

        public LogException(string descricao, string status)
            :base(status)
        {
            this.Descricao = descricao;
            this.Status = status;
        }
    }
}
