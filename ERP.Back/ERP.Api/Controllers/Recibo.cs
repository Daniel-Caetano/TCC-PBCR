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
        [Route("Numero/{id}/json")]
        public IActionResult BuscaRecibo(int id)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboCompleto(id);

            return Ok(recibo.BuscaReciboCompleto(id));
        }

        [HttpGet]
        [Route("Numero/Completo/{id}/json")]
        public IActionResult BuscaReciboCompleto(int id)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboCompleto(id);

            return Ok(recibo.BuscaReciboCompleto(id));
        }

        [HttpGet]
        [Route("CPFs/Pagar/{cpf}/json")]
        public IActionResult BuscaRecibosPagarCpf(string cpf)
        {
            var recibo = new ServicoRecibo(_connectionString);
            _ = recibo.BuscaRecibosPagarCpf(cpf);

            return Ok(recibo.BuscaRecibosPagarCpf(cpf));
        }

        [HttpGet]
        [Route("CPF/Pagar/{cpf}/json")]
        public IActionResult BuscaReciboPagarCpf(string cpf)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboPagarCpf(cpf);

            return Ok(recibo.BuscaReciboPagarCpf(cpf));
        }

        [HttpGet]
        [Route("CPF/Receber/{cpf}/json")]
        public IActionResult BuscaReciboReceberCpf(string cpf)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboReceberCpf(cpf);

            return Ok(recibo.BuscaReciboReceberCpf(cpf));

        }

        [HttpGet]
        [Route("CNPJ/{cnpj}/json")]
        public IActionResult BuscaReciboCnpj(string cnpj)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboCnpj(cnpj);

            return Ok(recibo.BuscaReciboCnpj(cnpj));
        }

    }
}
