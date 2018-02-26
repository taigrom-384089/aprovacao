﻿using Comum.Exceptions;
using Comum.Recursos;
using Comum.Util;
using Dominio.Integracao;
using Dominio.Persistencia.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class NotaCompra 
    {
        protected IList<HistoricoAprovacao> _historicos;

        public virtual Int32 Id { get; set; }

        public virtual DateTime DataEmissao { get; set; }

        public virtual float ValorMercadoria { get; set; }

        public virtual float ValorDesconto { get; set; }

        public virtual float ValorFrete { get; set; }

        public virtual float ValorTotal { get; set; }

        public virtual int Status { get; set; }

        public virtual IEnumerable<HistoricoAprovacao> Historicos
        {
            get
            {
                return _historicos;
            } 
        }

        public virtual void ValidarUsuario(Usuario usuario)
        {
            var historios = Historicos.Where(x => x.Usuario.Id == usuario.Id && x.NotaCompra.Id == this.Id);
            if (historios.Count() > 0)
                throw new BusinessException(MensagensValidacao.Usuario_JaAprovouNotaCompra);
        }

        public virtual void AdicionaHistorioAprovacao(HistoricoAprovacao historicoAprovacao)
        {
            _historicos.Add(historicoAprovacao);
        }

        public virtual void ValidarVistos(Configuracao configuracao)
        {
            var vistos = Historicos.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Visto);
            if (vistos.Count() != configuracao.Visto)
                throw new BusinessException(MensagensValidacao.Usuario_LimiteDeVistosNaoAtigidos);
        }

        public virtual bool ValidarVistoAprovacao(Configuracao configuracao)
        {
            var vistos = Historicos.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Visto);
            var aprovacoes = Historicos.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Aprovacao);
            if (vistos.Count() == configuracao.Visto && aprovacoes.Count() == configuracao.Aprovacao)
                return true;
            return false;
        }
    }
}