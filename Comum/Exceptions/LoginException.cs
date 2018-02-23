using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Comum.Recursos;

namespace Comum.Exceptions
{
    [Serializable]
    public class LoginException : BusinessException
    {
        public LoginException()
            : base(MensagensValidacao.Login_LoginOuSenhaInvalido)
        {

        }

        public LoginException(string Message)
            : base(Message)
        {
        }
    }
}
