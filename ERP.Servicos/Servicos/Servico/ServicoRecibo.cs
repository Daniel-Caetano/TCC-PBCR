using Caelum.Stella.CSharp.Validation;
using ERP.Servico.Negocio;
using ERP.Servicos;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ERP.Servico.Servicos.Servico
{
    public class ServicoRecibo
    {
        private readonly string _stringConexao;
        public ServicoRecibo(string stringConexao)
        {
            _stringConexao = stringConexao;
        }
        public List<Pessoa> ConsultaDados(string cpf)
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

            var repo = new RepositorioRecibo(_stringConexao);
            var listaPessoas = repo.ConsultaDados(cpf);
            return listaPessoas;
        }

        public List<Recibo> GeraRecibo()
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var listaRecibos = repo.GeraRecibo();

            return listaRecibos;
        }

    }
}
