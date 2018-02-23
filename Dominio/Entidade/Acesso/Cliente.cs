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
    public class Cliente : IEntidade
    {
        protected IList<Telefone> _telefones;

        public virtual Int32 Id { get; set; }

        public virtual string Cpf { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Email { get; set; }

        public virtual bool MaritalStatus { get; set; }

        public virtual IEnumerable<Telefone> Telefones 
        {
            get
            {
                return _telefones;
            }
        }

        public virtual Endereco Endereco { get; set; }

        public Cliente()
        {
            this._telefones = new List<Telefone>();
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(this.Cpf))
                throw new BusinessException(MensagensValidacao.Cliente_CpfObrigatorio);
            else if (!Helper.CheckCpfCnpj(this.Cpf))
                throw new BusinessException(MensagensValidacao.Cliente_CpfInvalido);

            if (string.IsNullOrEmpty(this.Email))
                throw new BusinessException(MensagensValidacao.Cliente_EmailObrigatorio);

            if (this.Endereco == null)
                throw new BusinessException(MensagensValidacao.Cliente_EnderecoObrigatorio);

            if (this.Telefones.Count() == 0)
                throw new BusinessException(MensagensValidacao.Cliente_TelefoneObrigatorio);
        }

        public virtual void Inserir()
        {
            var model = new Cliente();

            model.Cpf = this.Cpf;
            model.Email = this.Email;
            model.Nome = this.Nome;
            model.MaritalStatus = this.MaritalStatus;

            if (model.Endereco == null)
                model.Endereco = new Endereco();

            model.Endereco.Cliente = model;
            model.Endereco.Numero = this.Endereco.Numero;

            model.Endereco.Cep = Repositorio.Ceps.BuscarPorCep(this.Endereco.Cep.CepLogradouro);
            if (model.Endereco.Cep == null)
                model.Endereco.Cep = new Cep();

            model.Endereco.Cep.CepLogradouro = this.Endereco.Cep.CepLogradouro;

            if (model.Endereco.Cep.Logradouro == null)
                model.Endereco.Cep.Logradouro = new Logradouro();

            model.Endereco.Cep.Logradouro.Nome = this.Endereco.Cep.Logradouro.Nome;

            if (model.Endereco.Cep.Logradouro.Bairro == null)
                model.Endereco.Cep.Logradouro.Bairro = new Bairro();

            model.Endereco.Cep.Logradouro.Bairro.Nome = this.Endereco.Cep.Logradouro.Bairro.Nome;
            model.Endereco.Cep.Logradouro.Bairro.Cidade = Repositorio.Cidades.BuscarPorID(this.Endereco.Cep.Logradouro.Bairro.Cidade.Id);

            Repositorio.Clientes.SalvarOuAtualizar(model);

            foreach (var telefone in this.Telefones)
                AdicionaTelefone(telefone, model);
        }

        public virtual void Atualizar(Cliente model)
        {
            this.Cpf = model.Cpf;
            this.Email = model.Email;
            this.Nome = model.Nome;
            this.MaritalStatus = model.MaritalStatus;

            RemoverTelefones();

            foreach (var telefone in model.Telefones)
                AdicionaTelefone(telefone);

            if (model.Endereco == null)
                model.Endereco = new Endereco();

            this.Endereco.Numero = model.Endereco.Numero;

            this.Endereco.Cep = Repositorio.Ceps.BuscarPorCep(model.Endereco.Cep.CepLogradouro); 
            if (this.Endereco.Cep == null)
                this.Endereco.Cep = new Cep();

            this.Endereco.Cep.CepLogradouro = model.Endereco.Cep.CepLogradouro;

            if (this.Endereco.Cep.Logradouro == null)
                this.Endereco.Cep.Logradouro = new Logradouro();

            this.Endereco.Cep.Logradouro.Nome = model.Endereco.Cep.Logradouro.Nome;

            if (this.Endereco.Cep.Logradouro.Bairro == null)
                this.Endereco.Cep.Logradouro.Bairro = new Bairro();

            this.Endereco.Cep.Logradouro.Bairro.Nome = model.Endereco.Cep.Logradouro.Bairro.Nome;
            this.Endereco.Cep.Logradouro.Bairro.Cidade = Repositorio.Cidades.BuscarPorID(model.Endereco.Cep.Logradouro.Bairro.Cidade.Id);

            Repositorio.Clientes.SalvarOuAtualizar(this);
        }

        public virtual void RemoverTelefones()
        {
            foreach (var telefone in _telefones)
                Repositorio.Telefones.Excluir(telefone);
        }

        public virtual void AdicionaTelefone(Telefone telefone, Cliente model = null)
        {
            if (model == null)
                telefone.Cliente = this;
            else telefone.Cliente = model;

            Repositorio.Telefones.SalvarOuAtualizar(telefone);
        }
    }
}
