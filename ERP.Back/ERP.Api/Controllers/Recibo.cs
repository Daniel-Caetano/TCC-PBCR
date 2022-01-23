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

        [HttpGet]
        [Route("ReciboReceberCNPJ/{id}/json")]
        public IActionResult ReciboReceberCnpj(int id)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.ReciboReceberCNPJ(id);

            return Ok(recibo.ReciboReceberCNPJ(id));
        }

        [HttpGet]
        [Route("ReciboReceberCPF/{id}/json")]
        public IActionResult ReciboReceberCPF(int id)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.ReciboReceberCPF(id);

            return Ok(recibo.ReciboReceberCPF(id));
        }

        [HttpGet]
        [Route("ReciboPagarCPNJ/{id}/jnson")]
        public IActionResult ReciboPagarCNPJ(int id)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.ReciboPagarCNPJ(id);

            return Ok(recibo.ReciboPagarCNPJ(id));
        }

        [HttpGet]
        [Route("ReciboPagarCPF/{id}/json")]
        public IActionResult ReciboPagarCPF(int id)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.ReciboPagarCPF(id);

            return Ok(recibo.ReciboPagarCPF(id));
        }
    }
}
