using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Api.Negocio;

namespace View.Api.Servicos.Interface
{
    public interface IReciboService
    {
        [Get("/Recibo/Imprimir/json")]
        Task<IList<ReciboResponse>> GetAsync();
    }
}
