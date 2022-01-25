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
    public class PessoaService
    {
        private readonly IPessoaService _customerService;
        private readonly string _apiUrl;

        public PessoaService()
        {
            _apiUrl = "http://localhost:50663";
            _customerService = RestService.For<IPessoaService>(_apiUrl);
        }

        public async Task<IList<PessoaResponse>> GetAsync(string cpf)
        {
            return await _customerService.GetAsync(cpf);
        }
        public async Task<IList<PessoaResponse>> GetAsyncNome(string nome)
        {
            return await _customerService.GetAsync(nome);
        }
        public async Task<IList<PessoaResponse>> InsertAsync(string Nome, string CPF, string NumeroEndereco, string Complemento, string CEP, string Logradouro, string Bairro, string Localidade, string UF)
        {
            return await _customerService.InsertAsync(Nome, CPF, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
        }
        public async Task<IList<PessoaResponse>> UpdateAsync(string CpfAtual, string Nome, string CPF,
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {
            return await _customerService.UpdateAsync(CpfAtual, Nome, CPF, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
        }
        public async Task DeleteAsync(string cpf)
        {
            await _customerService.DeleteAsync(cpf);
        }
    }
}
