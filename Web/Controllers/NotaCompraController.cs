using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Web.ViewModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dominio.Persistencia.Entidade;
using Web.ActionFilters;
using Dominio.Entidade;
using System.Net.Http;
using System.Net;
using Web.Auth;
using Comum.Util;

namespace Web.Controllers
{
    [Autorizacao]
    public class NotaCompraController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return PartialView("_Editar");
        }
        
        public JsonResult Listar(string dataInicial, string dataFinal)
        {
            var usuarioLogado = Sessao.Ativa.Usuario;
            var notasCompra = usuarioLogado.Login.Equals("user0") ? Repositorio.NotasCompra.BuscarTodos() : Repositorio.NotasCompra.Filtrar(dataInicial, dataFinal, usuarioLogado);
            var notasCompraViewModel = notasCompra.Select(x => new NotaCompraViewModel().ToViewModel(x, usuarioLogado));

            return Json(notasCompraViewModel, JsonRequestBehavior.AllowGet);
        }

        public HttpResponseMessage Visto(int idNotaCompra)
        {
            try
            {
                var usuarioLogado = Sessao.Ativa.Usuario;

                using (var transacao = Repositorio.Transacao)
                {

                    var notaCompra = Repositorio.NotasCompra.BuscarPorID(idNotaCompra);
                    var configuracao = Repositorio.Configuracoes.BuscarPorFaixa(usuarioLogado.ValorMinVistoAprovacao, usuarioLogado.ValorMaxVistoAprovacao);

                    notaCompra.ValidarUsuario(usuarioLogado.Id);
                    notaCompra.ValidarLimiteVisto(configuracao);
                    notaCompra.AdicionaHistorioAprovacao(new HistoricoAprovacao()
                    { 
                        Data = DateTime.Now, 
                        NotaCompra = notaCompra,
                        Operacao = (byte)TipoOperacao.Visto,
                        Usuario = usuarioLogado
                    });

                    if (notaCompra.ValidarVistoAprovacao(configuracao))
                        notaCompra.Status = (byte)TipoStatus.Aprovada;
                    else
                        notaCompra.Status = (byte)TipoStatus.Pendente;

                    Repositorio.NotasCompra.SalvarOuAtualizar(notaCompra);
                    transacao.Commit();
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpResponseMessage Aprovacao(int idNotaCompra)
        {
            try
            {
                var usuarioLogado = Sessao.Ativa.Usuario;

                using (var transacao = Repositorio.Transacao)
                {

                    var notaCompra = Repositorio.NotasCompra.BuscarPorID(idNotaCompra);
                    var configuracao = Repositorio.Configuracoes.BuscarPorFaixa(usuarioLogado.ValorMinVistoAprovacao, usuarioLogado.ValorMaxVistoAprovacao);

                    notaCompra.ValidarUsuario(usuarioLogado.Id);
                    notaCompra.ValidarLimiteAprovacao(configuracao);
                    notaCompra.ValidarVistos(configuracao);
                    notaCompra.AdicionaHistorioAprovacao(new HistoricoAprovacao()
                    {
                        Data = DateTime.Now,
                        NotaCompra = notaCompra,
                        Operacao = (byte)TipoOperacao.Aprovacao,
                        Usuario = usuarioLogado
                    });

                    //A aprovação da nota irá mudar o status da nota de pendente para aprovada.
                    if (notaCompra.ValidarVistoAprovacao(configuracao))
                        notaCompra.Status = (byte)TipoStatus.Aprovada;
                    else
                        notaCompra.Status = (byte)TipoStatus.Pendente;

                    Repositorio.NotasCompra.SalvarOuAtualizar(notaCompra);
                    transacao.Commit();
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
