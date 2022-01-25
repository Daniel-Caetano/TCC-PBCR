using ERP.ViewApi.Negocio;
using ERP.ViewApi.Servicos.Interface;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Servico
{
    public class ReciboService
    {

        private readonly IReciboService _customerService;
        private readonly string _apiUrl;

        public ReciboService()
        {
            _apiUrl = "http://localhost:50663";
            _customerService = RestService.For<IReciboService>(_apiUrl);
        }

        public async Task<IList<ReciboResponse>> GetAsyncAll()
        {
            return await _customerService.GetAsyncAll();
        }

        public async Task<IList<ReciboResponse>> GetAsyncID(int id)
        {
            return await _customerService.GetAsyncID(id);
        }
        public async Task<IList<ReciboResponse>> GetAsyncApagar()
        {
            return await _customerService.GetAsyncApagar();
        }
        public async Task<IList<ReciboResponse>> GetAsyncAreceber()
        {
            return await _customerService.GetAsyncAreceber();
        }
        public async Task<IList<ReciboResponse>> GetAsyncDocumento(string documento)
        {
            return await _customerService.GetAsyncDocumento(documento);
        }

        public async Task<IList<ReciboResponse>> GetAsyncNome(string nome)
        {
            return await _customerService.GetAsyncNome(nome);
        }

        public async Task<IList<ReciboResponse>> InsertAsync(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, 
                                                             string NumeroEndRec,string ComplementoRec, string CEPrec, string BairroRec, 
                                                             string CidadeRec, string UFrec, string Pagador, string DocumentoPag,
                                                             decimal Valor, string ValorExtenso, string Observacao, 
                                                             string CidadeRecibo, string UFrecibo)
        {
            return await _customerService.InsertAsync(Tipo, Recebedor, DocumentoRec, EnderecoRec, NumeroEndRec, ComplementoRec, CEPrec, BairroRec, CidadeRec,
                UFrec, Pagador, DocumentoPag, Valor, ValorExtenso, Observacao, CidadeRecibo, UFrecibo);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerService.DeleteAsync(id);
        }

        public async Task<IList<ReciboResponse>> UpdateAsync(int id, string Tipo, decimal Valor, string ValorExtenso,
                              string Observacao, string NomeRecebedor, string CPF_CNPJRecebedor,
                              string LogradouroRecebedor, string NumeroEnderecoRecebedor,
                              string ComplementoRecebedor, string CEPRecebedor,
                              string BairroRecebedor, string CidadeRecebedor,
                              string UFRecebedor, string NomePagador, string CPF_CNPJPagador)
        {
            return await _customerService.UpdateAsync(id, Tipo, Valor, ValorExtenso, Observacao, 
                                                     NomeRecebedor,CPF_CNPJRecebedor, LogradouroRecebedor, 
                                                     NumeroEnderecoRecebedor, ComplementoRecebedor,
                                                     CEPRecebedor, BairroRecebedor, CidadeRecebedor, 
                                                     UFRecebedor, NomePagador, CPF_CNPJPagador);
        }

    }
}
