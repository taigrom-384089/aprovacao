using Dominio.Entidade;
using Dominio.InjecaoDependencia.Entidade;
using Dominio.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Persistencia.Entidade
{
    public class Repositorio 
    {
        public static IRepositorioCliente Clientes
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioCliente>();
            }
        }
             
        public static ITransacao Transacao
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<ITransacao>();
            }
        }

        public static IRepositorioBairro Bairros
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioBairro>();
            }
        }

        public static IRepositorioCidade Cidades
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioCidade>();
            }
        }

        public static IRepositorioEstado Estados
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioEstado>();
            }
        }

        public static IRepositorioCep Ceps
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioCep>();
            }
        }

        public static IRepositorioTelefone Telefones
        {
            get
            {
                return ResolvedorDependencia.Instancia.Resolver<IRepositorioTelefone>();
            }
        }
    }
}
