using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Comum.Util;
using Dominio.Entidade;
using Dominio.Persistencia.Entidade;

namespace Web.ViewModels
{
    public class NotaCompraViewModel
    {
        public Int32 Id { get; set; }

        public string DataEmissao { get; set; }

        public string ValorMercadoria { get; set; }

        public string ValorDesconto { get; set; }

        public string ValorFrete { get; set; }

        public string ValorTotal { get; set; }

        public string Status { get; set; }

        public int TipoOperacao { get; set; }

        public bool HabilitaVisto { get; set; }

        public bool HabilitaAprovacao { get; set; }

        public NotaCompraViewModel ToViewModel(NotaCompra model, int tipoOperacao)
        {
            return new NotaCompraViewModel()
            {
                Id = model.Id,
                DataEmissao = model.DataEmissao.ToShortDateString(),
                ValorMercadoria = model.ValorMercadoria.ToString("n2"),
                ValorDesconto = model.ValorDesconto.ToString("n2"),
                ValorFrete = model.ValorFrete.ToString("n2"),
                ValorTotal = model.ValorTotal.ToString("n2"),
                Status = model.Status == (byte)TipoStatus.Pendente ? "Pendente" : "Aprovada",
                TipoOperacao = tipoOperacao
            };
        }
    }
}