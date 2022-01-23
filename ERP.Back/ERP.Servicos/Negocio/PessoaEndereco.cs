using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Servico.Negocio
{
    public class PessoaEndereco
    {
        // Pessoa
        public string Nome { get; set; }

        // Codigo Postal
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        // Endereco
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
    }
}