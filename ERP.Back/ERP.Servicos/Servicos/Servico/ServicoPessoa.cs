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

    }
}