﻿using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("Recibo")]
    public class Recibo : BaseController
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
