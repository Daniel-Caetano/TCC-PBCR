namespace ERP.Servico.Negocio
{
    public class Empresa
    {
        public int ID_Empresa { get; set; }
        public int ID_Endereco { get; set; }
        public int ID_CEP { get; set; }
        public string Razao { get; set; }
        public string CNPJ { get; set; }
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
    }
}