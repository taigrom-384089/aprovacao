using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Interfaces
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
