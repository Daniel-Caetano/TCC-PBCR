using ERP.ViewApi.Negocio;
using ERP.ViewApi.Servicos.Interface;
using Refit;
using System.Collections.Generic;
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
        public async Task<IList<EmpresaResponse>> GetAllAsync()
        {
            return await _customerService.GetAllAsync();
        }
        public async Task<IList<EmpresaResponse>> GetAsync(string cnpj)
        {
            return await _customerService.GetAsync(cnpj);
        }
        public async Task<IList<EmpresaResponse>> InsertAsync(string razao, string cnpj, string NumeroEndereco, string Complemento, string CEP, string Logradouro, string Bairro, string Localidade, string UF)
        {
            return await _customerService.InsertAsync(razao, cnpj, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
        }
        public async Task<IList<EmpresaResponse>> UpdateAsync(string cnpjAtual, string Razao, string Cnpj, string NumeroEndereco, string Complemento, string CEP, string Logradouro, string Bairro, string Localidade, string UF)
        {
            return await _customerService.UpdateAsync(cnpjAtual, Razao, Cnpj, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
        }
        public async Task DeleteAsync(string cnpj)
        {
            await _customerService.DeleteAsync(cnpj);
        }
    }
}
