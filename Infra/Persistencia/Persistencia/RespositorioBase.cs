using Comum.Util;
using Dominio.Entidade;
using Dominio.InjecaoDependencia.Entidade;
using Dominio.Persistencia.Interfaces;
using Infra.NHibernate;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia.Persistencia
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private ISession session;

        public ISession Session
        {
            get
            {
                if (session == null)
                {
                    session = SessionProvider.OpenSession();
                }
                return session;
            }
        }

        public ITransacao IniciarTransacao()
        {
            return ResolvedorDependencia.Instancia.Resolver<ITransacao>();
        }

        public bool SalvarOuAtualizar(T objeto)
        {
            try
            {
                Session.SaveOrUpdate(objeto);                
            }
            catch (TypeInitializationException ex)
            {
                throw new Exception("Erro ao acessar base de dados. Favor entrar em contato com a área de sistemas");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public IQueryable<T> BuscarTodos()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> BuscarTodos(ISession session)
        {
            return session.Query<T>();
        }

        public T BuscarPorID(object id)
        {
            return Session.Get<T>(id);
        }

        public int Count()
        {
            return Session.Query<T>().Count();
        }

        public void Excluir(T objeto)
        {
            try
            {
                Session.Delete(objeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Adicionar(T objeto)
        {
            Session.Merge(objeto);
        }

        public void Adicionar(IList<T> objetos)
        {
            foreach (var obj in objetos)
                Session.Merge(obj);    
        }

        public void Flush()
        {
            Session.Flush();
        }

        public bool TestaConexao()
        {
            return Session.IsConnected || session.IsOpen || session.Connection != null;
        }

        public String GetGeneratedSql(IQueryable queryable, ISession session)
        {
            var sessionImp = (ISessionImplementor)session;
            var nhLinqExpression = new NhLinqExpression(queryable.Expression, sessionImp.Factory);
            var translatorFactory = new ASTQueryTranslatorFactory();
            var translators = translatorFactory.CreateQueryTranslators(nhLinqExpression, null, false, sessionImp.EnabledFilters, sessionImp.Factory);

            return translators[0].SQLString;
        }
    }
}
