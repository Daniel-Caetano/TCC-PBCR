using ERP.ViewApi.Negocio;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Interface
{
    public interface IEmpresaService
    {

        [Get("/Empresa/Lista/json")]
        Task<IList<EmpresaResponse>> GetAllAsync();

        [Get("/Empresa/CNPJ/{cnpj}/json")]
        Task<IList<EmpresaResponse>> GetAsync(string cnpj);


        [Post("/Empresa/Adicionar/json")]
        Task<IList<EmpresaResponse>> InsertAsync(string razao, string cnpj, string NumeroEndereco, 
                                                 string Complemento, string CEP, string Logradouro, 
                                                 string Bairro, string Localidade, string UF);


        [Put("/Atualizar/{cnpjAtual}/json")]
        Task<IList<EmpresaResponse>> UpdateAsync(string cnpjAtual, string novaRazao, string novoCnpj,
                                                 string NumeroEndereco, string Complemento, string CEP, 
                                                 string Logradouro, string Bairro, string Localidade, string UF);


        [Delete("/Empresa/Deletar/cnpj/json")]
        Task DeleteAsync(string cnpj);
    }
}
