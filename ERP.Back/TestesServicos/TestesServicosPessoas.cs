using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ERP.Servico.Servicos.Repositorio;
using ERP.Servico.Negocio;

namespace TestesServicos
{
    public class TestesServicosPessoas
    {
        protected const string _connectionString = "Server=localhost,1401;Database=ERP;User Id = sa; Password=Tccpbcr123@";

        [Fact]
        public void TestaListadePessoas()
        {
            // Arrange
            var pessoas = new RepositorioPessoa(_connectionString);

            // Act
            List<Pessoa> lista = pessoas.Lista();

            // Assert
            Assert.NotNull(lista);
        }
    }
}
