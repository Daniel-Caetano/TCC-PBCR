using ERP.Servico.Negocio;
using ERP.Servicos;
using System;
using System.Collections.Generic;
using System.Data;

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

        public List<Recibo> BuscaReciboCompleto(int id)
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var listaRecibos = repo.BuscaReciboCompleto(id);

            return listaRecibos;
        }

        public List<Recibo> BuscaReciboCompletoApagar()
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaReciboCompletoApagar();

            return recibo;
        }

        public List<Recibo> BuscaReciboCompletoAreceber()
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaReciboCompletoAreceber();

            return recibo;

        }

        public List<Recibo> BuscaReciboCPF_CNPJ(string documento)
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaReciboCPF_CNPJ(documento);

            return recibo;
        }

        public List<Recibo> BuscaReciboNome(string nome)
        {
            var repo = new RepositorioRecibo(_stringConexao);
            var recibo = repo.BuscaReciboNome(nome);

            return recibo;
        }

        public void Adicionar(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, string NumeroEndRec,
            string ComplementoRec, string CEPrec, string BairroRec, string CidadeRec, string UFrec, string Pagador, string DocumentoPag,
            decimal Valor, string ValorExtenso, string Observacao, string CidadeRecibo, string UFrecibo)
        {
            var repositorio = new RepositorioRecibo(_stringConexao);
            repositorio.Adicionar(Tipo, Recebedor, DocumentoRec, EnderecoRec, NumeroEndRec, ComplementoRec, CEPrec, BairroRec, CidadeRec, UFrec, Pagador, DocumentoPag,
                Valor, ValorExtenso, Observacao, CidadeRecibo, UFrecibo);
        }

        public void Deletar(int id)
        {
            var repositorio = new RepositorioRecibo(_stringConexao);
            repositorio.Deletar(id);
        }
    }
}