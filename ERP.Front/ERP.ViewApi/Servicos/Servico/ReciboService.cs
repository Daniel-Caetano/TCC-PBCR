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
    }
}