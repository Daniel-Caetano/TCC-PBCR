using ERP.Servico.Negocio;

namespace ERP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var novaEmpresa = new Empresa();
            //var repo = new RepositorioEmpresa();

            // repo.Adicionar(novaEmpresa);

            /*while (true)
            {
                var cpf = System.Console.ReadLine();
                string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ERP;Trusted_Connection=True";
                var repo = new RepositorioRecibo(connectionString);
                var listaPessoas = repo.BuscaCpf(cpf);

                listaPessoas.ForEach(Pessoa => System.Console.WriteLine(Pessoa.Nome));

                System.Console.WriteLine();
            }*/
        }
    }
}
