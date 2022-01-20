using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Api.Servico
{
    public class CpfService
    {
        private readonly ICpfService _customerService;
        private readonly string _apiUrl;

        public CpfService()
        {
            _apiUrl = "http://localhost:50663";
            _customerService = RestService.For<ICpfService>(_apiUrl);
        }

        public async Task<CpfResponse> GetAsync(string cpf)
        {
            return await _customerService.GetAsync(cpf);
        }

    }
}
