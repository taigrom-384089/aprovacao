using Comum.Exceptions;
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

        protected IList<ItemNota> _itensNota;

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

        public virtual IEnumerable<ItemNota> ItensNota
        {
            get
            {
                _itensNota.Add(new ItemNota() { NotaCompra = this });

                return _itensNota;
            }
        }

        //Usuários do sistema poderão registrar um único visto ou aprovação por nota de compra
        public virtual void ValidarUsuario(int idUsuario)
        {
            var historios = Historicos.Where(x => x.Usuario.Id == idUsuario && x.NotaCompra.Id == this.Id);
            if (historios.Count() > 0)
                throw new BusinessException(MensagensValidacao.Usuario_NFComVistoOuAprovacao);
        }

        public virtual void AdicionaHistorioAprovacao(HistoricoAprovacao historicoAprovacao)
        {
            _historicos.Add(historicoAprovacao);
        }

        //As aprovações somente deverão ocorrer quando a quantidade de vistos necessários for atingida
        public virtual void ValidarVistos(Configuracao configuracao)
        {
            var vistos = Historicos.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Visto);
            if (vistos.Count() != configuracao.Visto)
                throw new BusinessException(MensagensValidacao.Usuario_LimiteDeVistosNaoAtigidos);
        }
        
        //A nota de compra será aprovada quando atingir a quantidade de vistos e aprovações necessárias
        public virtual bool ValidarVistoAprovacao(Configuracao configuracao)
        {
            var vistos = Historicos.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Visto);
            var aprovacoes = Historicos.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Aprovacao);
            if (vistos.Count() == configuracao.Visto && aprovacoes.Count() == configuracao.Aprovacao)
                return true;
            return false;
        }

        public virtual void ValidarLimiteVisto(Configuracao configuracao)
        {
            var historioAprovacao = Repositorio.Historicos.BuscarTodos();
            var vistos = historioAprovacao.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Visto);

            if (vistos.Count() == configuracao.Visto)
                throw new BusinessException(MensagensValidacao.Usuario_LimiteDeVistoAtigidos);
        }

        public virtual void ValidarLimiteAprovacao(Configuracao configuracao)
        {
            var historioAprovacao = Repositorio.Historicos.BuscarTodos();
            var aprovacoes = historioAprovacao.Where(x => x.NotaCompra.Id == this.Id && x.Operacao == (byte)TipoOperacao.Aprovacao);

            if (aprovacoes.Count() == configuracao.Aprovacao)
                throw new BusinessException(MensagensValidacao.Usuario_LimiteDeAprovacaoAtigidos);
        }
    }
}
