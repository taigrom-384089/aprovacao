using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.NHibernate
{
    public interface ISessionManager
    {
        ISession OpenSession(ISessionFactory sessionFactory);

        void CloseSession();
    }
}
