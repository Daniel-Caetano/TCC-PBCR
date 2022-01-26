using Caelum.Stella.CSharp.Validation;
using ERP.Servico.Negocio;
using ERP.Servico.Servicos.Repositorio;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ERP.Servico.Servicos.Servico
{
    public class ServicoPessoa
    {
        private readonly string _stringConexao;
        public ServicoPessoa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }
        public bool verificaNull(string Nome, string CPF, string NumeroEndereco,
                                 string Complemento, string CEP,
                                 string Logradouro, string Bairro,
                                 string Localidade, string UF)
        {
            if (Nome == null)
            {
                Console.WriteLine("Nome INVÁLIDO");
                return false;
            }
            if (CPF == null)
            {
                Console.WriteLine("CPF INVÁLIDO");
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

        public bool validaPessoa(string Nome, string CPF, string NumeroEndereco,
                                 string Complemento, string CEP,
                                 string Logradouro, string Bairro,
                                 string Localidade, string UF)
        {

            if (!(verificaNull(Nome, CPF, NumeroEndereco,
                              Complemento, CEP,
                              Logradouro, Bairro,
                              Localidade, UF)))
            {
                Console.WriteLine("Contém dados Nulos");
                return false;
            }
            var pessoaNova = BuscaCpf(CPF);

            if (CPF.Length != 11)
            {
                Console.WriteLine("CPF INVÁLIDO");
                return false;
            }
            if (pessoaNova.Count > 0)
            {
                Console.WriteLine("CPF JA EXISTENTE");
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
        public List<Pessoa> Lista()
        {
            var repo = new RepositorioPessoa(_stringConexao);
            var pessoas = repo.Lista();
            return pessoas;
        }

        public List<Pessoa> BuscaCpf(string cpf)
        {
            try
            {
                new CPFValidator().AssertValid(cpf);
            }

            catch (Exception ex)
            {
                Debug.WriteLine("CPF inválido!" + ex.Message);
            }
            var repo = new RepositorioPessoa(_stringConexao);
            var pessoas = repo.BuscaCpf(cpf);
            return pessoas;
        }

        public List<Pessoa> BuscaNome(string nome)
        {
            var repo = new RepositorioPessoa(_stringConexao);
            var pessoas = repo.BuscaNome(nome);
            return pessoas;
        }

        public void Adicionar(string Nome, string CPF,
           string NumeroEndereco, string Complemento, string CEP
           , string Logradouro, string Bairro, string Localidade, string UF)
        {

            if (validaPessoa(Nome, CPF, NumeroEndereco,
                              Complemento, CEP,
                              Logradouro, Bairro,
                              Localidade, UF))
            {
                var repositorio = new RepositorioPessoa(_stringConexao);
                repositorio.Adicionar(Nome, CPF, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
            }
            else
            {
                Console.WriteLine("Falha ao adicionar, dados inválidos");
            }
        }
        public void Atualizar(string CpfAtual, string Nome, string Cpf,
                              string NumeroEndereco, string Complemento,
                              string CEP, string Logradouro, string Bairro,
                              string Localidade, string UF)
        {

            //estrutura para não sobrescrever os dados antigos com null
            var dadosAntigos = BuscaCpf(CpfAtual);
            if (Nome == null)
            {
                Nome = dadosAntigos[0].Nome;
            }
            if (Cpf == null)
            {
                Cpf = dadosAntigos[0].CPF;
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

                var repositorio = new RepositorioPessoa(_stringConexao);
                repositorio.Atualizar(CpfAtual, Nome, Cpf, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
        }
        public void Deletar(string cpf)
        {
            var repositorio = new RepositorioPessoa(_stringConexao);
            repositorio.Deletar(cpf);
        }
    }
}