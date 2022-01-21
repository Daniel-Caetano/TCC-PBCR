using ERP.ViewApi.Negocio;
using ERP.ViewApi.Servicos.Interface;
using Refit;
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

        public async Task<IList<ReciboResponse>> GetAsync()
        {
            return await _customerService.GetAsync();
        }
    }
}
