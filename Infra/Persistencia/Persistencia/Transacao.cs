using Dominio.Persistencia.Interfaces;
using Infra.NHibernate;
using NHibernate;

namespace Infra.Persistencia.Persistencia
{
    public class Transacao : ITransacao
    {
        private ITransaction transacao;

        public Transacao()
        {
            transacao = SessionProvider.OpenSession().BeginTransaction();
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            transacao.Dispose();
            transacao = null;
        }

        #endregion

        #region Implementation of ITransacao

        public void Commit()
        {
            transacao.Commit();
        }

        public void RollBack()
        {
            transacao.Rollback();
        }

        #endregion
    }
}
