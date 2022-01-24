using Caelum.Stella.CSharp.Validation;
using ERP.Servico.Negocio;
using ERP.Servico.Servicos.Repositorio;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ERP.Servico.Servicos.Servico
{
    public class ServicoEmpresa
    {
        private readonly string _stringConexao;

        public ServicoEmpresa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }

        public List<Empresa> BuscaCnpj(string cnpj)
        {
            try
            {
                new CNPJValidator().AssertValid(cnpj); // Validador do CPF
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CNPJ invalido!" + ex.Message);
            }

            var repositorio = new RepositorioEmpresa(_stringConexao);
            var listEmpresa = repositorio.BuscaCnpj(cnpj);
            return listEmpresa;
        }

        public void Adicionar(string razao, string cnpj)
        {
            var repositorio = new RepositorioEmpresa(_stringConexao);
            repositorio.Adicionar(razao,cnpj);
           // return listEmpresa;
        }
        public void Atualizar(string cnpjAtual, string novaRazao, string novoCnpj,
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {

            var repositorio = new RepositorioEmpresa(_stringConexao);
            repositorio.Atualizar(cnpjAtual, novaRazao, novoCnpj,
                NumeroEndereco, Complemento, CEP, Logradouro, Bairro,
                Localidade, UF);
            // return listEmpresa;
        }

        public void Deletar(string cnpj)
        {
            var repositorio = new RepositorioEmpresa(_stringConexao);
            repositorio.Deletar(cnpj);
        }
    }
}