using Newtonsoft.Json;
using System;

namespace ERP.ViewApi.Negocio
{
    public class ReciboResponse
    {

        [JsonProperty("numero")]
        public int Numero { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("valorExtenso")]
        public string ValorExtenso { get; set; }

        [JsonProperty("observacao")]
        public string Observacao { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

    }
}
