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
        public List<Recibo> GeraRecibo()
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var listaRecibos = repo.GeraRecibo();

            return listaRecibos;
        }

    }
}