﻿using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
{
    public interface IRepositorioHistoricoAprovacao : IRepositorioBase<HistoricoAprovacao>
    {
        IEnumerable<HistoricoAprovacao> BuscarPorUsuario(int idUsuario);
    }
}
