using System;

namespace Infra.Persistencia.Interfaces
{
    public interface ITransacao : IDisposable
    {
        void Commit();
       
        void RollBack();
    }
}
