using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infra.NHibernate
{
    public class SessionManager : ISessionManager
    {
        private const string ChaveDoContextoHttp = "nhibernate.current_session";

        public ISession OpenSession(ISessionFactory sessionFactory)
        {
            ISession currentSession = CallContext.GetData(ChaveDoContextoHttp) as ISession;
            if (currentSession == null)
            {
                currentSession = sessionFactory.OpenSession();
                CallContext.SetData(ChaveDoContextoHttp, currentSession);
            }
            return currentSession;
        }

        public void CloseSession()
        {
            ISession currentSession = CallContext.GetData(ChaveDoContextoHttp) as ISession;
            if (currentSession != null)
            {
                currentSession.Close();
                CallContext.FreeNamedDataSlot(ChaveDoContextoHttp);
            }
        }
    }
}
