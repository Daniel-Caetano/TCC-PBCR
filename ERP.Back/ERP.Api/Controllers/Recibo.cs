using ERP.Servico.Servicos.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    // Rotas Para acesso da API
    [ApiController]
    [Route("Recibo")]
    public class Recibo : BaseController
    {
        [HttpGet]
        [Route("Lista/json")]
        public IActionResult ListaRecibos() // Lista todos os recibos
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.ListaRecibos();

            return Ok(servico.ListaRecibos());
        }

        [HttpGet]
        [Route("Completo/{id}/json")]
        public IActionResult BuscaReciboCompleto(int id) // Busca um recibo Pelo Id
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.BuscaReciboCompleto(id);

            return Ok(servico.BuscaReciboCompleto(id));
        }

        [HttpGet]
        [Route("Completo/Apagar/json")]
        public IActionResult BuscaReciboCompletoApagar() // Lista os recibos do tipo A Pagar
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboCompletoApagar();

            return Ok(recibo.BuscaReciboCompletoApagar());
        }

        [HttpGet]
        [Route("Completo/AReceber/json")]
        public IActionResult BuscaReciboCompletoAreceber() // Lista os recibos do tipo A Receber
        {
            var recibo = new ServicoRecibo(_connectionString);
            recibo.BuscaReciboCompletoAreceber();

            return Ok(recibo.BuscaReciboCompletoAreceber());
        }

        [HttpGet]
        [Route("Completo/CPF_CNPJ/{documento}/json")]
        public IActionResult BuscaReciboCPF_CNPJ(string documento) // Busca recibos pelo CPF/CNPJ
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.BuscaReciboCPF_CNPJ(documento);

            return Ok(servico.BuscaReciboCPF_CNPJ(documento));
        }

        [HttpGet]
        [Route("Completo/Nome/{nome}/json")]
        public IActionResult BuscaReciboNome(string nome) // Busca recibos pelo Nome/RazãoSocial
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.BuscaReciboNome(nome);

            return Ok(servico.BuscaReciboNome(nome));
        }

        [HttpPost]
        [Route("Adicionar/json")]
        public IActionResult Adicionar(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, string NumeroEndRec,
                                       string ComplementoRec, string CEPrec, string BairroRec, string CidadeRec, string UFrec, string Pagador, string DocumentoPag,
                                       decimal Valor, string ValorExtenso, string Observacao, string CidadeRecibo, string UFrecibo)
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.Adicionar(Tipo, Recebedor, DocumentoRec, EnderecoRec, NumeroEndRec, ComplementoRec,
                              CEPrec, BairroRec, CidadeRec, UFrec, Pagador, DocumentoPag, Valor,
                              ValorExtenso, Observacao, CidadeRecibo, UFrecibo);

            return Ok(servico);
        }

        [HttpDelete]
        [Route("Delete/id/json")]
        public IActionResult Deletar(int id)
        {
            var servico = new ServicoRecibo(_connectionString);
            servico.Deletar(id);

            return Ok(servico);
        }

        [HttpPut]
        [Route("Atualizar/{id}/json")]
        public IActionResult Atualizar(int id, string Tipo, decimal Valor, string ValorExtenso,
                                       string Observacao, string NomeRecebedor, string CPF_CNPJRecebedor,
                                       string LogradouroRecebedor, string NumeroEnderecoRecebedor,
                                       string ComplementoRecebedor, string CEPRecebedor,
                                       string BairroRecebedor, string CidadeRecebedor,
                                       string UFRecebedor, string NomePagador, string CPF_CNPJPagador)
        {
            var repo = new ServicoRecibo(_connectionString);
            repo.Atualizar(id, Tipo, Valor, ValorExtenso, Observacao, NomeRecebedor,
                           CPF_CNPJRecebedor, LogradouroRecebedor, NumeroEnderecoRecebedor, ComplementoRecebedor,
                           CEPRecebedor, BairroRecebedor, CidadeRecebedor, UFRecebedor, NomePagador, CPF_CNPJPagador);

            return Ok(repo);
        }
    }
}
