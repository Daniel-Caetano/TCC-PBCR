using ERP.ViewApi.Negocio;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Interface
{

    public interface IReciboService
    {
        [Get("/Recibo/Imprimir/json")]
        Task<IList<ReciboResponse>> GetAsync();
    }

}
