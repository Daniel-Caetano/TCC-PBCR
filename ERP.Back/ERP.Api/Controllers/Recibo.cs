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
        }

        [HttpGet]
        [Route("Recibo/{id}json")]
        public IActionResult BuscaRecibo(int id)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaRecibo(id);

            return Ok(recibo.BuscaRecibo(id));
        }

        //[HttpGet]
        //[Route("ReciboReceber/{id}json")]
        //public IActionResult ReceberRecibo(int id)
        //{
        //    var recibo = new ServicoRecibo(_connectionString);
        //    recibo.ReceberRecibo(id);

        //    return Ok(recibo.ReceberRecibo(id));
        //}
    }

}
