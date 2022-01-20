using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Api.Negocio;
using View.Api.Servicos.Interface;

namespace View.Api.Servico
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
