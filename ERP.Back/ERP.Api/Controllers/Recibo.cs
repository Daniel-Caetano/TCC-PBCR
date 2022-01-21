using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("Recibo")]
    public class Recibo : BaseController
    {
        [HttpGet]
        [Route("Lista/json")]
        public IActionResult ListaRecibos()
        {
            var servico = new ServicoRecibo(_connectionString);
            var recibo = servico.ListaRecibos();
            return Ok(recibo);
            //.FirstOrDefault()
        }
    }
}
