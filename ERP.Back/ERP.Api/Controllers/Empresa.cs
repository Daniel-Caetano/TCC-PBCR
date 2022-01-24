using ERP.Servico.Servicos.Repositorio;
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

        [HttpPost]
        [Route("Adicionar/{razao},{cnpj}/json")]
        public IActionResult Adicionar(string razao, string cnpj)
        {
            
            var repo = new ServicoEmpresa(_connectionString);
            repo.Adicionar(razao , cnpj);

            return Ok(repo);
        }

        [HttpPut]
        [Route("Atualizar/cnpjatual,novarazao,novocnpj/json")]
        public IActionResult Atualizar(string cnpjAtual, string novaRazao, string novoCnpj,
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {

            var repo = new ServicoEmpresa(_connectionString);
            repo.Atualizar(cnpjAtual, novaRazao, novoCnpj,
                NumeroEndereco, Complemento, CEP, Logradouro, Bairro,
                Localidade, UF);

            return Ok(repo);
        }

        [HttpDelete]
        [Route("Atualizar/cnpjatual,novarazao,novocnpj/json")]
        public IActionResult Deletar(string cnpj)
        {

            var repo = new ServicoEmpresa(_connectionString);
            repo.Deletar(cnpj);

            return Ok(repo);
        }
    }
}