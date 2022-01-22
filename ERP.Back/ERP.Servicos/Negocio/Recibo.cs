using System;

namespace ERP.Servico.Negocio
{
    public class Recibo
    {
        // Recebedor
        public int NumeroRecibo { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string ValorExtenso { get; set; }
        public string Observacao { get; set; }
        public DateTime Data { get; set; }
        public string NomeRecebedor { get; set; }
        public string CPF_CNPJRecebedor { get; set; }
        public string LogradouroRecebedor { get; set; }
        public string NumeroEnderecoRecebedor { get; set; }
        public string ComplementoRecebedor { get; set; }
        public string CEPRecebedor { get; set; }
        public string BairroRecebedor { get; set; }
        public string CidadeRecebedor { get; set; }
        public string UFRecebedor { get; set; }

        //Pagador
        public string NomePagador { get; set; }
        public string CPF_CNPJPagador { get; set; }

    }
}