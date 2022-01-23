﻿using Caelum.Stella.CSharp.Validation;
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
        public Recibo ReciboReceberCPF(int id)
        {
            var reci = new RepositorioRecibo(_stringConexao);
            var receberCPF = reci.ReciboReceberCPF(id);
            return receberCPF;
        }
        public Recibo ReciboReceberCNPJ(int id)
        {
            var reci = new RepositorioRecibo(_stringConexao);
            var receberCNPJ = reci.ReciboReceberCNPJ(id);
            return receberCNPJ;
        }
        public Recibo ReciboPagarCNPJ(int id)
        {
            var reci = new RepositorioRecibo(_stringConexao);
            var pagarCNPJ = reci.ReciboPagarCNPJ(id);
            return pagarCNPJ;
        }
        public Recibo ReciboPagarCPF(int id)
        {
            var reci = new RepositorioRecibo (_stringConexao);
            var pagarCPF = reci.ReciboPagarCPF(id);
            return pagarCPF;
        }
    }
}