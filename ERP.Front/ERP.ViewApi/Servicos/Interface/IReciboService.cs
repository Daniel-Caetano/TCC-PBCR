﻿using ERP.ViewApi.Negocio;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Interface
{
    public interface IReciboService
    {
        [Get("/Recibo/Lista/json")]
        Task<IList<ReciboResponse>> GetAsyncAll();

        [Get("/Recibo/Completo/{id}/json")]
        Task<IList<ReciboResponse>> GetAsyncID(int id);

        [Get("/Recibo/Completo/Apagar/json")]
        Task<IList<ReciboResponse>> GetAsyncApagar();

        [Get("/Recibo/Completo/AReceber/json")]
        Task<IList<ReciboResponse>> GetAsyncAreceber();

        [Get("/Recibo/Completo/CPF_CNPJ/{documento}/json")]
        Task<IList<ReciboResponse>> GetAsyncDocumento(string documento);

        [Get("/Recibo/Completo/Nome/{nome}/json")]
        Task<IList<ReciboResponse>> GetAsyncNome(string nome);

        [Post("/Recibo/Adicionar/json")]
        Task<IList<ReciboResponse>> InsertAsync(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, string NumeroEndRec,
            string ComplementoRec, string CEPrec, string BairroRec, string CidadeRec, string UFrec, string Pagador, string DocumentoPag,
            decimal Valor, string ValorExtenso, string Observacao, string CidadeRecibo, string UFrecibo);

        [Delete("/Recibo/Delete/id/json")]
        Task DeleteAsync(int id);
    }
}

//Recibo/Numero/{id}/json
//[Get("/Recibo/Lista/json")]
//Task<IList<ReciboResponse>> GetAsync();

/*[Get("/Recibo/{cnpj}/json")]
Task<ReciboResponse> GetAsyncBuca(string cnpj);*/