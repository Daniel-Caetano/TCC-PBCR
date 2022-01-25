using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    // Rotas Para acesso da API
    [ApiController]
    [Route("Recibo")]
    public class Recibo : BaseController
    {
        [HttpGet]
        [Route("Lista/json")]
        public IActionResult ListaRecibos() // Lista todos os Recibos
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.ListaRecibos();
            return Ok(servico.ListaRecibos());
        }

        [HttpGet]
        [Route("Completo/{id}/json")]
        public IActionResult BuscaReciboCompleto(int id) // Busca um Recibo Pelo Id
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.BuscaReciboCompleto(id);
            return Ok(servico.BuscaReciboCompleto(id));
        }

        [HttpGet]
        [Route("Completo/Apagar/json")]
        public IActionResult BuscaReciboCompletoApagar() // Lista os recibos do tipo A Pagar
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboCompletoApagar();

            return Ok(recibo.BuscaReciboCompletoApagar());
        }

        [HttpGet]
        [Route("Completo/AReceber/json")]
        public IActionResult BuscaReciboCompletoAreceber() // Lista os recibos do tipo A Receber
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboCompletoAreceber();

            return Ok(recibo.BuscaReciboCompletoAreceber());
        }

        [HttpGet]
        [Route("Completo/CPF_CNPJ/{documento}json")]
        public IActionResult BuscaReciboPorCPF_CNPJ(string documento) // Busca um Recibo Pelo Id
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.BuscaReciboPorCPF_CNPJ(documento);
            return Ok(servico.BuscaReciboPorCPF_CNPJ(documento));
        }

    }
}
