using Dominio.InjecaoDependencia.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InjecaoDependencia.Entidade
{
    public class ResolvedorDependencia : IResolvedorDependencia
    {
        private static Lazy<IUnityContainer> _container;

        private static Action<IUnityContainer> _configuracao;

        public static ResolvedorDependencia Instancia { get; protected set; }

        public ResolvedorDependencia(Action<IUnityContainer> configuracao)
        {
            _configuracao = configuracao;

            _container = new Lazy<IUnityContainer>(
                () =>
                {
                    var container = new UnityContainer();
                    _configuracao(container);

                    return container;
                });
        }

        protected ResolvedorDependencia(IUnityContainer iUnityContainer)
        {
            _container = new Lazy<IUnityContainer>(
                () =>
                    {
                        var container = iUnityContainer;
                        return container;
                    });
        }

        public T Resolver<T>()
        {
            if (_container == null)
            {
                throw new ConfigurationException("Injecao de dependência não configurada");
            }

            return _container.Value.Resolve<T>();
        }

        public IEnumerable<T> ResolverTodos<T>()
        {
            if (_container == null)
            {
                throw new ConfigurationException("Injecao de dependência não configurada");
            }

            return _container.Value.ResolveAll<T>();
        }

        public static void Configurar(Action<IUnityContainer> configuracao)
        {
            Instancia = new ResolvedorDependencia(configuracao);    
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            _container = null;
        }

        #endregion

        #region Implementation of IDependencyScope

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Value.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.Value.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        #endregion
    }
}
