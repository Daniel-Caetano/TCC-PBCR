﻿using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("Recibo")]
    public class GeraRecibo : BaseController
    {
        [HttpGet]
        [Route("Imprimir/json")]
        public IActionResult ImprimirRecibo()
        {
            var servico = new ServicoRecibo(_connectionString);
            var recibo = servico.GeraRecibo();
            return Ok(recibo);
        }
    }
}
