using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("Pessoa")]
    public class Pessoa : BaseController
    {

        [HttpGet]
        [Route("Lista/json")]
        public IActionResult Lista()
        {
            var pessoas = new ServicoPessoa(_connectionString);
            return Ok(pessoas.Lista());
        }

        [HttpGet]
        [Route("Cpf/{cpf}/json")]
        public IActionResult BuscaPorCpf(string cpf)
        {
            var pessoa = new ServicoPessoa(_connectionString);
            return Ok(pessoa.BuscaCpf(cpf));
        }

        [HttpGet]
        [Route("Nome/{nome}/json")]
        public IActionResult BuscaPorNome(string nome)
        {
            var pessoa = new ServicoPessoa(_connectionString);
            pessoa.BuscaNome(nome);

            return Ok(pessoa.BuscaNome(nome));
        }

        [HttpPost]
        [Route("Adicionar/json")]
        public IActionResult Adicionar(string Nome, string CPF, string NumeroEndereco, string Complemento, string CEP, string Logradouro, string Bairro, string Localidade, string UF)
        {

            var repo = new ServicoPessoa(_connectionString);
            repo.Adicionar(Nome, CPF, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);

            return Ok(repo);
        }

        [HttpPut]
        [Route("Atualizar/{cpfatual}/json")]
        public IActionResult Atualizar(string cpfatual, string Nome, string CPF,
         string NumeroEndereco, string Complemento, string CEP
         , string Logradouro, string Bairro, string Localidade, string UF)
        {

            var repo = new ServicoPessoa(_connectionString);
            repo.Atualizar(cpfatual, Nome, CPF,
                NumeroEndereco, Complemento, CEP, Logradouro, Bairro,
                Localidade, UF);

            return Ok(repo);
        }

        [HttpDelete]
        [Route("Deletar/cpf/json")]
        public IActionResult Deletar(string cpf)
        {

            var repo = new ServicoPessoa(_connectionString);
            repo.Deletar(cpf);

            return Ok(repo);
        }
    }
}