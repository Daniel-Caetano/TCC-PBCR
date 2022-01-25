using ERP.ViewApi.Negocio;
using ERP.ViewApi.Servicos.Interface;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Servico
{
    public class EmpresaService
    {
        private readonly IEmpresaService _customerService;
        private readonly string _apiUrl;

        public EmpresaService()
        {
            _apiUrl = "http://localhost:50663";
            _customerService = RestService.For<IEmpresaService>(_apiUrl);
        }

        public async Task<IList<EmpresaResponse>> GetAsync(string cnpj)
        {
            return await _customerService.GetAsync(cnpj);
        }
    }
}
