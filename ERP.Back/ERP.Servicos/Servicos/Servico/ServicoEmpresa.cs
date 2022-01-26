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
        public bool verificaNull(string razao, string cnpj,
                                 string NumeroEndereco, string Complemento,
                                 string CEP, string Logradouro, string Bairro,
                                 string Localidade, string UF)
        {
            if (razao == null)
            {
                Console.WriteLine("Razao INVÁLIDO");
                return false;
            }
            if (cnpj == null)
            {
                Console.WriteLine("CNPJ INVÁLIDO");
                return false;
            }
            if (NumeroEndereco == null)
            {
                Console.WriteLine("NumeroEndereco INVÁLIDO");
                return false;
            }
            if (Complemento == null)
            {
                Console.WriteLine("Complemento INVÁLIDO");
                return false;
            }
            if (CEP == null)
            {
                Console.WriteLine("CEP INVÁLIDO");
                return false;
            }
            if (Logradouro == null)
            {
                Console.WriteLine("Logradouro INVÁLIDO");
                return false;
            }
            if (Bairro == null)
            {
                Console.WriteLine("Bairro INVÁLIDO");
                return false;
            }
            if (Localidade == null)
            {
                Console.WriteLine("Localidade INVÁLIDO");
                return false;
            }
            if (UF == null)
            {
                Console.WriteLine("UF INVÁLIDO");
                return false;
            }
            return true;
        }

        public bool validaEmpresa(string razao, string cnpj,
                                 string NumeroEndereco, string Complemento, 
                                 string CEP, string Logradouro, string Bairro, 
                                 string Localidade, string UF)
        {

            if (!(verificaNull(razao, cnpj, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF)))
            {
                Console.WriteLine("Contém dados Nulos");
                return false;
            }
            var empresaNova = BuscaCnpj(cnpj);

            if (cnpj.Length != 14)
            {
                Console.WriteLine("CNPJ INVÁLIDO");
                return false;
            }
            if (empresaNova.Count > 0)
            {
                Console.WriteLine("CNPJ JA EXISTENTE");
                return false;
            }
            if (UF.Length != 2)
            {
                Console.WriteLine("Digito UF para estado inválido");
                return false;
            }

            if (CEP.Length != 8)
            {
                Console.WriteLine("CEP inválido");
                return false;
            }
            return true;
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

            if (validaEmpresa(razao, cnpj, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF))
            {
                var repositorio = new RepositorioEmpresa(_stringConexao);
                repositorio.Adicionar(razao, cnpj, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
            }
            else
            {
                Console.WriteLine("FALHA AO ADICIONAR, CONTÉM DADOS INVÁLIDOS!");
            }
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
            var repositorioEmpresa = new RepositorioEmpresa(_stringConexao);
            if (repositorioEmpresa.BuscaCnpj(cnpj).Count > 0)
            {
                var repositorio = new RepositorioEmpresa(_stringConexao);
                repositorio.Deletar(cnpj);
            }
            else
            {
                Console.WriteLine("Empresa não existe");
            }

        }
    }
}