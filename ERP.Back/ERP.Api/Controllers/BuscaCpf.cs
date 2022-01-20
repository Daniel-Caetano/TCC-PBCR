using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("Pessoa")]
    public class BuscaCpf : BaseController
    {
        [HttpGet]
        [Route("CPF/{cpf}/json")]
        public IActionResult BuscaPorNome(string cpf)
        {
            var servico = new ServicoRecibo(_connectionString);
            var pessoas = servico.ConsultaDados(cpf);

            return Ok(pessoas.FirstOrDefault());
            // 97608972025
            // 14120490084
        }
    }
}
