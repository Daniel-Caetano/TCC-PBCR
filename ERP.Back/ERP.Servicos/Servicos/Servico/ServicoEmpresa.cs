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

            var repo = new RepositorioEmpresa(_stringConexao);
            var listEmpresa = repo.BuscaCnpj(cnpj);
            return listEmpresa;
        }

        public void Adicionar(string razao, string cnpj)
        {
            var repo = new RepositorioEmpresa(_stringConexao);
            repo.Adicionar(razao,cnpj);
           // return listEmpresa;
        }
    }
}