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
        public List<Recibo> ListaRecibos()
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var listaRecibos = repo.ListaRecibos();

            return listaRecibos;
        }
        public Recibo BuscaRecibo(int id)
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaRecibo(id);
            return recibo;
        }

        public List<Recibo> BuscaRecibosReceberCpf(string cpf)
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaRecibosReceberCpf(cpf);
            return recibo;

        }

        public Recibo BuscaReciboReceberCpf(string cpf)
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaReciboReceberCpf(cpf);
            return recibo;

        }

        public List<Recibo> BuscaReciboCnpj(string cnpj)
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaReciboCnpj(cnpj);
            return recibo;
        }
    }
}