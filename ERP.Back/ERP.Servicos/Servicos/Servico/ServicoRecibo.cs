using ERP.Servico.Negocio;
using ERP.Servicos;
using System;
using System.Collections.Generic;

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
            var repositorioRecibo = new RepositorioRecibo(_stringConexao);
            if (repositorioRecibo.BuscaReciboCompleto(id).Count > 0)
            {
                var repositorio = new RepositorioRecibo(_stringConexao);
                repositorio.Deletar(id);
            }
            else
            {
                Console.WriteLine("Recibo não encontrado!");
            }
        }

        public void Atualizar(int id, string Tipo, decimal Valor, string ValorExtenso,
                              string Observacao, string NomeRecebedor, string CPF_CNPJRecebedor,
                              string LogradouroRecebedor, string NumeroEnderecoRecebedor,
                              string ComplementoRecebedor, string CEPRecebedor,
                              string BairroRecebedor, string CidadeRecebedor,
                              string UFRecebedor, string NomePagador, string CPF_CNPJPagador)
        {
            var dadosAntigos = BuscaReciboCompleto(id);

            if (Tipo == null)
            {
                Tipo = dadosAntigos[0].Tipo;
            }
            if (Valor == 0)
            {
                Valor = dadosAntigos[0].Valor;
            }
            if (ValorExtenso == null)
            {
                ValorExtenso = dadosAntigos[0].ValorExtenso;
            }
            if (Observacao == null)
            {
                Observacao = dadosAntigos[0].Observacao;
            }
            if (NomeRecebedor == null)
            {
                NomeRecebedor = dadosAntigos[0].NomeRecebedor;
            }
            if (CPF_CNPJRecebedor == null)
            {
                CPF_CNPJRecebedor = dadosAntigos[0].CPF_CNPJRecebedor;
            }
            if (LogradouroRecebedor == null)
            {
                LogradouroRecebedor = dadosAntigos[0].LogradouroRecebedor;
            }
            if (NumeroEnderecoRecebedor == null)
            {
                NumeroEnderecoRecebedor = dadosAntigos[0].NumeroEnderecoRecebedor;
            }
            if (ComplementoRecebedor == null)
            {
                ComplementoRecebedor = dadosAntigos[0].ComplementoRecebedor;
            }
            if (CEPRecebedor == null)
            {
                CEPRecebedor = dadosAntigos[0].CEPRecebedor;
            }
            if (BairroRecebedor == null)
            {
                BairroRecebedor = dadosAntigos[0].BairroRecebedor;
            }
            if (CidadeRecebedor == null)
            {
                CidadeRecebedor = dadosAntigos[0].CidadeRecebedor;
            }
            if (UFRecebedor == null)
            {
                UFRecebedor = dadosAntigos[0].UFRecebedor;
            }
            if (NomePagador == null)
            {
                NomePagador = dadosAntigos[0].NomePagador;
            }
            if (CPF_CNPJPagador == null)
            {
                CPF_CNPJPagador = dadosAntigos[0].CPF_CNPJPagador;
            }

            var repositorio = new RepositorioRecibo(_stringConexao);
            repositorio.Atualizar(id, Tipo, Valor, ValorExtenso, Observacao, NomeRecebedor,
                                  CPF_CNPJRecebedor, LogradouroRecebedor, NumeroEnderecoRecebedor, ComplementoRecebedor,
                                  CEPRecebedor, BairroRecebedor, CidadeRecebedor, UFRecebedor, NomePagador, CPF_CNPJPagador);
        }
    }
}