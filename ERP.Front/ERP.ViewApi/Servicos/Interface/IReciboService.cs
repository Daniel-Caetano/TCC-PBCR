using ERP.ViewApi.Negocio;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Interface
{
    public interface IReciboService
    {
        [Get("/Recibo/Lista/json")]
        Task<IList<ReciboResponse>> GetAsync();


        [Get("/Recibo/Numero/{id}/json")]
        Task<IList<ReciboBuscaResponse>> GetAsyncID(int id);
    }
}

//Recibo/Numero/{id}/json
//[Get("/Recibo/Lista/json")]
//Task<IList<ReciboResponse>> GetAsync();

/*[Get("/Recibo/{cnpj}/json")]
Task<ReciboResponse> GetAsyncBuca(string cnpj);*/