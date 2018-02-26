using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using Web.Auth;
using System.Web.Security;
using Comum.Util;
using Dominio.Integracao;

namespace Web.ActionFilters
{
    public class AutorizacaoAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public AutorizacaoAttribute() { }

        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            if (!(filterContext.HttpContext.Request.IsAuthenticated) || Sessao.Ativa == null)
            {
                Redirecionar(filterContext, "Login", "Index", string.Empty);
                return;
            }
        }

        public static void Redirecionar(AuthorizationContext filterContext, string controller, string action, string area, HttpStatusCode statusCode = HttpStatusCode.Unauthorized, string returnUrl = "")
        {
            filterContext.HttpContext.Response.StatusCode = (int)statusCode;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            UrlHelper url = new UrlHelper(filterContext.RequestContext);

            filterContext.Result = new RedirectToRouteResult(
                                  new RouteValueDictionary {
                        { "Controller", controller },
                        { "Action", action },
                        { "Area", area },
                        { "ReturnUrl" , returnUrl }
                    });
        }
    }
}
