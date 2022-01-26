using ERP.ViewApi.Negocio;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Interface
{
    public interface IPessoaService
    {
        [Get("/Pessoa/Lista/json")]
        Task<IList<PessoaResponse>> GetAsyncAll();

        [Get("/Pessoa/Cpf/{cpf}/json")]
        Task<IList<PessoaResponse>> GetAsync(string cpf);


        [Get("/Pessoa/Nome/{nome}/json")]
        Task<IList<PessoaResponse>> GetAsyncNome(string nome);


        [Post("/Pessoa/Adicionar/json")]
        Task<IList<PessoaResponse>> InsertAsync(string Nome, string CPF, string NumeroEndereco, 
                                                string Complemento, string CEP, string Logradouro, 
                                                string Bairro, string Localidade, string UF);


        [Put("/Pessoa/Atualizar/{cpfatual}/json")]
        Task<IList<PessoaResponse>> UpdateAsync(string CpfAtual, string Nome, string CPF,
                                                string NumeroEndereco, string Complemento, string CEP , 
                                                string Logradouro, string Bairro, string Localidade, string UF);

        [Delete("/Pessoa/Deletar/cpf/json")]
        Task DeleteAsync(string cpf);
    }
}
