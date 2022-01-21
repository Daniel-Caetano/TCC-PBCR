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
    public class Pessoa : BaseController
    {
        [HttpGet]
        [Route("Cpf/{cpf}/json")]
        public IActionResult BuscaPorCpf(string cpf)
        {
            var pessoa = new ServicoPessoa(_connectionString);
            return Ok(pessoa.BuscaCpf(cpf));
            // 97608972025
            // 14120490084
        }

        [HttpGet]
        [Route("Nome/{nome}/json")]
        public IActionResult BuscaPorNome(string nome)
        {
            var pessoa = new ServicoPessoa(_connectionString);
            pessoa.BuscaNome(nome);

            return Ok(pessoa.BuscaNome(nome));

        }

        [HttpGet]
        [Route("Endereco/{cpf}/json")]
        public IActionResult BuscaPessoaEndereco(string cpf)
        {
            var repo = new ServicoPessoa(_connectionString);
            return Ok(repo.BuscaPessoaEndereco(cpf));
        }
    }
}
