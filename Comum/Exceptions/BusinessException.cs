using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Comum.Exceptions
{
    [Serializable]
    public class BusinessException : LogException
    {
        public bool HasLayout { get; set; }

        public BusinessException()
            : base()
        {

        }

        public BusinessException(string Message)
            : base(Message)
        {
            
        }

        public BusinessException(string Message, bool hasLayout)
            : base(Message)
        {
            HasLayout = hasLayout;
        }

        public BusinessException(string descricao, string status)
            : base(status)
        {
            Descricao = descricao;
            Status = status;
        }
    }
}
