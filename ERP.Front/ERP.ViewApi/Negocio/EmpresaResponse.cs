using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewApi.Negocio
{
    public class EmpresaResponse
    {
        [JsonProperty("iD_Empresa")]
        public int ID_Empresa { get; set; }

        [JsonProperty("iD_Endereco")]
        public int ID_Endereco { get; set; }

        [JsonProperty("iD_CEP")]
        public int ID_CEP { get; set; }

        [JsonProperty("razao")]
        public string Razao { get; set; }

        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("numeroEndereco")]
        public string NumeroEndereco { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }
    }
}
