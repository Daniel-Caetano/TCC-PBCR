using System;

namespace ERP.View.Dominio.Negocio
{
    public class Recibo
    {

        public int Numero { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string ValorExtenso { get; set; }
        public string Observacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime Data { get; set; }

    }

}
