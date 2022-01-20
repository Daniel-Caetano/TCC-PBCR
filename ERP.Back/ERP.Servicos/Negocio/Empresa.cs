using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Servico.Negocio
{
    public class Empresa
    {
        public int Numero { get; set; }
        public string Razao { get; set; }
        public string CNPJ { get; set; }
        public int Endereco { get; set; }
    }
}
