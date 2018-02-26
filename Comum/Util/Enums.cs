using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comum.Util
{
    public enum TipoOperacao : byte
    {
        Visto = 1,
        Aprovacao = 2
    }

    public enum TipoStatus : byte
    {
        Pendente = 0,
        Aprovada = 1
    }
}
