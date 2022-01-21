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
        [Route("BuscaPorCNPJ/{cnpj}/json")]
        public IActionResult BuscaCnpj(string cnpj)
        {
            var servico = new ServicoEmpresa(_connectionString);
            var empresa = servico.BuscaCnpj(cnpj);

            return Ok(empresa.FirstOrDefault());
        }
    }
}