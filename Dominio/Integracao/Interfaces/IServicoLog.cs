using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Integracao.Interfaces
{
    public interface IServicoLog
    {
        void Erro(string mensagem);
    }
}
