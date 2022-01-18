using ERP.Servico.Negocio;
using ERP.Servicos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ERP.Servico.Servicos.Servico
{
    public class ServicoRecibo
    {
        private string _stringConexao;
        public ServicoRecibo(string stringConexao)
        {
            _stringConexao = stringConexao;
        }
        public List<Pessoa> ConsultaDados(string cpf)
        {
            try 
            {
                _ = cpf.Length != 11;
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
            /*if (cpf.Length != 11)
            {
                throw new Exception("CPF inválido");
            }*/

            var repo = new RepositorioRecibo(_stringConexao);
            var listaRecibos = repo.GeraRecibo();

            return listaRecibos;

        }

    }
}
