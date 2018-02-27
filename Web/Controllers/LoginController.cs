using Comum;
using Comum.Recursos;
using Comum.Util;
using Dominio.Entidade;
using Dominio.InjecaoDependencia.Entidade;
using Dominio.Integracao.Interfaces;
using Dominio.Persistencia.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Comum.Exceptions;
using Web.Models;
using System.Configuration;
using Dominio.Integracao;
using System.Reflection;
using Web.ActionFilters;
using Web.Auth;
using Web.ViewModels;
using System.Net.Http;
using System.Net;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        public HttpResponseMessage Autenticar(UsuarioViewModel viewModel)
        {
            var usuarioCadastrado = Repositorio.Usuarios.Autenticar(viewModel.Login, viewModel.Senha);
            if (usuarioCadastrado != null)
            {

                FormsAuthentication.SetAuthCookie(usuarioCadastrado.Login, false);

                HttpContext.Session[Constantes.SessionKeys.Sessao] = new Sessao(usuarioCadastrado);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                throw new LoginException(MensagensValidacao.Login_LoginOuSenhaInvalido);
            }
        }

        public HttpResponseMessage Sair()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [AllowAnonymous]
        public ActionResult Timeout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();

            if (Request.IsAjaxRequest())
                throw new LoginException("TimeOut");
            else return RedirectToAction("Index");
        }
    }
}