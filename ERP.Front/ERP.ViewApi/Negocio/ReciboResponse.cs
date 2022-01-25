using Newtonsoft.Json;
using System;

namespace ERP.ViewApi.Negocio
{
    public class ReciboResponse
    {
        [JsonProperty("numeroRecibo")]
        public int NumeroRecibo { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("valorExtenso")]
        public string ValorExtenso { get; set; }

        [JsonProperty("observacao")]
        public string Observacao { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        // Recebedor
        [JsonProperty("nomeRecebedor")]
        public string NomeRecebedor { get; set; }

        [JsonProperty("cpF_CNPJRecebedor")]
        public string CPF_CNPJRecebedor { get; set; }

        [JsonProperty("logradouroRecebedor")]
        public string LogradouroRecebedor { get; set; }

        [JsonProperty("numeroEnderecoRecebedor")]
        public string NumeroEnderecoRecebedor { get; set; }

        [JsonProperty("complementoRecebedor")]
        public string ComplementoRecebedor { get; set; }

        [JsonProperty("cepRecebedor")]
        public string CEPRecebedor { get; set; }

        [JsonProperty("bairroRecebedor")]
        public string BairroRecebedor { get; set; }

        [JsonProperty("cidadeRecebedor")]
        public string CidadeRecebedor { get; set; }

        [JsonProperty("ufRecebedor")]
        public string UFRecebedor { get; set; }

        // Pagador
        [JsonProperty("nomePagador")]
        public string NomePagador { get; set; }

        [JsonProperty("cpF_CNPJPagador")]
        public string CpF_CNPJPagador { get; set; }

    }
}
