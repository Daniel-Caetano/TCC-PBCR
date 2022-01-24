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
            recibo.BuscaRecibo(id);

            return Ok(recibo.BuscaRecibo(id));
        }
        [HttpGet]
        [Route("CPFs/{cpf}/json")]
        public IActionResult BuscaRecibosReceberCpf(string cpf)
        {
            var recibo = new ServicoRecibo(_connectionString);
            _ = recibo.BuscaRecibosReceberCpf(cpf);

            return Ok(recibo.BuscaRecibosReceberCpf(cpf));
        }

        [HttpGet]
        [Route("CPF/{cpf}/json")]
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
