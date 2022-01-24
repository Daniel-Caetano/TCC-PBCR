﻿using ERP.Servico.Servicos.Servico;
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
        [Route("Numero/{cnpj}/json")]
        public IActionResult BuscaRecibo(string cnpj)
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaRecibo(cnpj);

            return Ok(recibo.BuscaRecibo(cnpj));
        }

        //[HttpGet]
        //[Route("CPF/{cpf}/json")]
        //public IActionResult BuscaReciboCpf(string cpf)
        //{
        //    var recibo = new ServicoRecibo(_connectionString);
        //    recibo.BuscaReciboCpf(cpf);

        //    return Ok(recibo.BuscaReciboCpf(cpf));
        //}

        //[HttpGet]
        //[Route("CNPJ/{cnpj}/json")]
        //public IActionResult BuscaReciboCnpj(string cnpj)
        //{
        //    var recibo = new ServicoRecibo(_connectionString);
        //    recibo.BuscaReciboCnpj(cnpj);

        //    return Ok(recibo.BuscaReciboCnpj(cnpj));
        //}
    }
}
