namespace ERP.Servico.Negocio
{
    public class Pessoa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Endereco { get; set; }
        public int ID_Endereco { get; set; }
        public int ID_CEP { get; set; }
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
    }
}
