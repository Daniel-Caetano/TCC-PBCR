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
        public List<Empresa> Lista()
        {

            var repositorio = new RepositorioEmpresa(_stringConexao);
            var listEmpresa = repositorio.Lista();
            return listEmpresa;
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

        public void Adicionar(string razao, string cnpj,
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {
            var repositorio = new RepositorioEmpresa(_stringConexao);
            repositorio.Adicionar(razao, cnpj, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);

        }
        public void Atualizar(string cnpjAtual, string novaRazao, string novoCnpj,
                              string NumeroEndereco, string Complemento, string CEP, 
                              string Logradouro, string Bairro, string Localidade, string UF)
        {

            //estrutura para não sobrescrever os dados antigos com null
            var dadosAntigos = BuscaCnpj(cnpjAtual);
            if (novaRazao == null)
            {
                novaRazao = dadosAntigos[0].Razao;
            }
            if (novoCnpj == null)
            {
                novoCnpj = dadosAntigos[0].CNPJ;
            }
            if (NumeroEndereco == null)
            {
                NumeroEndereco = dadosAntigos[0].NumeroEndereco;
            }
            if (Complemento == null)
            {
                Complemento = dadosAntigos[0].Complemento;
            }
            if (CEP == null)
            {
                CEP = dadosAntigos[0].CEP;
            }
            if (Logradouro == null)
            {
                Logradouro = dadosAntigos[0].Logradouro;
            }
            if (Bairro == null)
            {
                Bairro = dadosAntigos[0].Bairro;
            }
            if (Localidade == null)
            {
                Localidade = dadosAntigos[0].Localidade;
            }
            if (UF == null)
            {
                UF = dadosAntigos[0].UF;
            }

            var repositorio = new RepositorioEmpresa(_stringConexao);
            repositorio.Atualizar(cnpjAtual, novaRazao, novoCnpj,
                NumeroEndereco, Complemento, CEP, Logradouro, Bairro,
                Localidade, UF);
        }

        public void Deletar(string cnpj)
        {
            var repositorio = new RepositorioEmpresa(_stringConexao);
            repositorio.Deletar(cnpj);
        }
    }
}