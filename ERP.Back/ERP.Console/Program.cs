﻿using Caelum.Stella.CSharp.Validation;
using ERP.Servico.Negocio;
using ERP.Servico.Servicos.Repositorio;
using ERP.Servicos;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ERP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            var novaEmpresa = new Empresa();
            //var repo = new RepositorioEmpresa();

           // repo.Adicionar(novaEmpresa);
=======
            /*while (true)
            {
                var cpf = System.Console.ReadLine();
                string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ERP;Trusted_Connection=True";
                var repo = new RepositorioRecibo(connectionString);
                var listaPessoas = repo.BuscaCpf(cpf);

                listaPessoas.ForEach(Pessoa => System.Console.WriteLine(Pessoa.Nome));

                System.Console.WriteLine();
            }*/
>>>>>>> c04639bc01de0a91e53176a19eb66bb95afb7697
        }
    }
}
