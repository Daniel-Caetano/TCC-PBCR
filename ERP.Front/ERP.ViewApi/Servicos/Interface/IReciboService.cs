using ERP.ViewApi.Negocio;
using Refit;
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

        [Get("/Recibo/Completo/CPF_CNPJ/{documento}json")]
        Task<IList<ReciboResponse>> GetAsyncDocumento(string documento);

    }
}

//Recibo/Numero/{id}/json
//[Get("/Recibo/Lista/json")]
//Task<IList<ReciboResponse>> GetAsync();

/*[Get("/Recibo/{cnpj}/json")]
Task<ReciboResponse> GetAsyncBuca(string cnpj);*/