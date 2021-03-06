﻿using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
{
    public interface IRepositorioNotaCompra : IRepositorioBase<NotaCompra>
    {
        IEnumerable<NotaCompra> Filtrar(string dataInicial, string dataFinal, Usuario usuario);

        IEnumerable<NotaCompra> Listar();
    }
}
