using System;

namespace Comum.Exceptions
{
    [Serializable]
    public class ServiceException : LogException
    {
        public ServiceException()
            : base()
        {

        }

        public ServiceException(string mensagem)
            : base(mensagem)
        {
            
        }

        public ServiceException(string mensagem, Exception ex = null)
            : base(mensagem, ex)
        {
            
        }

        public ServiceException(string descricao, string status)
            : base(descricao, status)
        {
            
        }
    }
}
