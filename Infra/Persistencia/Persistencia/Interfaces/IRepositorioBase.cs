using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Persistencia.Interfaces
{
    public interface IRepositorioBase<T> 
    {
        ITransacao IniciarTransacao();
      
        Boolean SalvarOuAtualizar(T objeto);
     
        T BuscarPorID(object id);
    
        IQueryable<T> BuscarTodos();
      
        void Excluir(T objeto);

        void Adicionar(T objeto);

        void Adicionar(IList<T> objetos);

        void Flush();
    }
}
