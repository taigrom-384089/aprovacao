using Comum.Util;
using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Auth
{
    public class Sessao
    {
        public Usuario Usuario { get; set; }

        public static Sessao Ativa
        {
            get
            {
                return (Sessao)HttpContext.Current.Session[Constantes.SessionKeys.Sessao];
            }
        }

        public Sessao(Usuario usuario)
        {
            this.Usuario = usuario;
        }
    }
}