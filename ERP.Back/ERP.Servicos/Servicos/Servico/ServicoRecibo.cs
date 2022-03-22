using ERP.Servico.Negocio;
using ERP.Servicos;
using System;
using System.Collections.Generic;

namespace ERP.Servico.Servicos.Servico
{
    public class ServicoRecibo
    {
        private readonly string _stringConexao;

        private bool VerificaNulos(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, string NumeroEndRec, 
                                   string ComplementoRec, string CEPrec, string BairroRec, string CidadeRec, 
                                   string UFrec, string Pagador, string DocumentoPag, decimal Valor, 
                                   string ValorExtenso, string Observacao, string CidadeRecibo, string UFrecibo)
        {
            if(Tipo == null)
            {
                Console.WriteLine("Tipo INVÁLIDO");
                return false;
            }
            if (Recebedor == null)
            {
                Console.WriteLine("Receber INVÁLIDO");
                return false;
            }
            if (DocumentoRec == null)
            {
                Console.WriteLine("Documento do Recebedor é Invalido");
                return false;
            }
            if (EnderecoRec == null)
            {
                Console.WriteLine("Endereço do Recebedor é invalido");
                return false;
            }
            if (NumeroEndRec == null)
            {
                Console.WriteLine("Numero do Endereço é Invalido");
                return false;
            }
            if (ComplementoRec == null)
            {
                Console.WriteLine("Complento Invalido");
                return false;
            }
            if (CEPrec == null)
            {
                Console.WriteLine("CEP informado é Invaldio");
                return false;
            }
            if (BairroRec == null)
            {
                Console.WriteLine("Bairro Invalido");
                return false;
            }
            if (CidadeRec == null)
            {
                Console.WriteLine("Cidade Invalida");
                return false;
            }
            if(UFrec == null)
            {
                Console.WriteLine("Estado Invalida");
                return false;
            }
            if(Pagador == null)
            {
                Console.WriteLine("Pagador Invalida");
                return false;
            }
            if(DocumentoPag == null)
            {
                Console.WriteLine("Documento Invalida");
                return false;
            }
            if(Valor == 0)
            {
                Console.WriteLine("Valor Invalido");
                return false;
            }
            if(ValorExtenso == null)
            {
                Console.WriteLine("Valor por Extenso Invalido");
                return false;
            }
            if(Observacao == null)
            {
                Console.WriteLine("Observação Invalido");
                return false;

            }
            if(CidadeRecibo == null)
            {
                Console.WriteLine("Cidade Invalida");
                return false;
            }
            if(UFrecibo == null)
            {
                Console.WriteLine("Estado Invalido");
                return false;
            }
            return true;
        }

        private bool ValidaRecibo(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, string NumeroEndRec,
                                   string ComplementoRec, string CEPrec, string BairroRec, string CidadeRec,
                                   string UFrec, string Pagador, string DocumentoPag, decimal Valor,
                                   string ValorExtenso, string Observacao, string CidadeRecibo, string UFrecibo)
        {
            if(!VerificaNulos(Tipo, Recebedor, DocumentoRec, EnderecoRec, NumeroEndRec, ComplementoRec, CEPrec, BairroRec,
                CidadeRec, UFrec, Pagador, DocumentoPag, Valor, ValorExtenso, Observacao, CidadeRecibo, UFrecibo))
            {
                Console.WriteLine("Os dados informados possuem valores nulos");
                return false;
            }

            return true;
        }

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

        public void Adicionar(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, string NumeroEndRec, string ComplementoRec, 
                              string CEPrec, string BairroRec, string CidadeRec, string UFrec, string Pagador, string DocumentoPag,
                              decimal Valor, string ValorExtenso, string Observacao, string CidadeRecibo, string UFrecibo)
        {
            if (ValidaRecibo(Tipo, Recebedor, DocumentoRec, EnderecoRec, NumeroEndRec, ComplementoRec, CEPrec, BairroRec,
                CidadeRec, UFrec, Pagador, DocumentoPag, Valor, ValorExtenso, Observacao, CidadeRecibo, UFrecibo))
            {
                var repositorio = new RepositorioRecibo(_stringConexao);
                repositorio.Adicionar(Tipo, Recebedor, DocumentoRec, EnderecoRec, NumeroEndRec, ComplementoRec, CEPrec, BairroRec, CidadeRec, UFrec, Pagador, DocumentoPag,
                                      Valor, ValorExtenso, Observacao, CidadeRecibo, UFrecibo);
            }
            else
            {
                Console.WriteLine("FALHA AO ADICIONAR, CONTÉM DADOS INVÁLIDOS!");
            }
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