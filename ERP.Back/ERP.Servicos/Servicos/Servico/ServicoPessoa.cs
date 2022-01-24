using Caelum.Stella.CSharp.Validation;
using ERP.Servico.Negocio;
using ERP.Servico.Servicos.Repositorio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ERP.Servico.Servicos.Servico
{
    public class ServicoPessoa
    {
        private readonly string _stringConexao;
        public ServicoPessoa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }
        public Pessoa BuscaCpf(string cpf)
        {
            try
            {
                _ = cpf.Length != 11;
                new CPFValidator().AssertValid(cpf);
            }

            catch (Exception ex)
            {
                Debug.WriteLine("CPF invalido!" + ex.Message);
            }

            var repo = new RepositorioPessoa(_stringConexao);
            var pessoa = repo.BuscaCpf(cpf);
            return pessoa;
        }

        public Pessoa BuscaNome(string nome)
        {
            var repo = new RepositorioPessoa(_stringConexao);
            var pessoa = repo.BuscaNome(nome);
            return pessoa;
        }

        public void Adicionar(string Nome, string CPF,
           string NumeroEndereco, string Complemento, string CEP
           , string Logradouro, string Bairro, string Localidade, string UF)
        {
            var repositorio = new RepositorioPessoa(_stringConexao);
            repositorio.Adicionar(Nome, CPF, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);

        }
        public void Atualizar(string CpfAtual, string Nome, string Cpf,
    string NumeroEndereco, string Complemento, string CEP
    , string Logradouro, string Bairro, string Localidade, string UF)
        {

            //estrutura para não sobrescrever os dados antigos com null
            var dadosAntigos = BuscaCpf(Cpf);
            if (Nome == null)
            {
                Nome = dadosAntigos.Nome;
            }
            if (Cpf == null)
            {
                Cpf = dadosAntigos.CPF;
            }
            if (NumeroEndereco == null)
            {
                NumeroEndereco = dadosAntigos.NumeroEndereco;
            }
            if (Complemento == null)
            {
                Complemento = dadosAntigos.Complemento;
            }
            if (CEP == null)
            {
                CEP = dadosAntigos.CEP;
            }
            if (Logradouro == null)
            {
                Logradouro = dadosAntigos.Logradouro;
            }
            if (Bairro == null)
            {
                Bairro = dadosAntigos.Bairro;
            }
            if (Localidade == null)
            {
                Localidade = dadosAntigos.Localidade;
            }
            if (UF == null)
            {
                UF = dadosAntigos.UF;
            }

            var repositorio = new RepositorioPessoa(_stringConexao);
            repositorio.Atualizar(CpfAtual, Nome, Cpf,
                NumeroEndereco, Complemento, CEP, Logradouro, Bairro,
                Localidade, UF);
        }
        public void Deletar(string cpf)
        {
            var repositorio = new RepositorioPessoa(_stringConexao);
            repositorio.Deletar(cpf);
        }
    }
}