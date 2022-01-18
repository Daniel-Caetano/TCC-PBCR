using ERP.Servicos;
using System;
using System.Linq;

namespace ERP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var cpf = System.Console.ReadLine();
                string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ERP;Trusted_Connection=True";
                var repo = new RepositorioRecibo(connectionString);
                var listaPessoas = repo.ConsultaDados(cpf);

                listaPessoas.ForEach(Pessoa => System.Console.WriteLine(Pessoa.Nome));

                System.Console.WriteLine();
            }
        }
    }
}
