using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("Empresa")]
    public class Empresa : BaseController
    {
        [HttpGet]
        [Route("CNPJ/{cnpj}/json")]
        public IActionResult BuscaCnpj(string cnpj)
        {
            var servico = new ServicoEmpresa(_connectionString);

            return Ok(servico.BuscaCnpj(cnpj));
        }
    }
}