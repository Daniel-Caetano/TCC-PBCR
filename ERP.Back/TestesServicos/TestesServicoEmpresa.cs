using ERP.Servico.Negocio;
using ERP.Servico.Servicos.Repositorio;
using System.Collections.Generic;
using Xunit;

namespace TestesServicos
{
    public class TestesServicoEmpresa
    {
        protected const string _connectionString = "Server=localhost,1401;Database=ERP;User Id = sa; Password=Tccpbcr123@";

        [Fact]
        public void TestaListarTodasEmpresas()
        {
            // Arrange
            var empresas = new RepositorioEmpresa(_connectionString);
            
            // Act
            List<Empresa> lista = empresas.Lista();

            // Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestarPesquisaporCNPJ()
        {
            // Arrange
            var empresas = new RepositorioEmpresa(_connectionString);

            // Act
            List<Empresa> empresa = empresas.BuscaCnpj("");

            // Assert
            Assert.NotNull(empresa);
        }

        [Fact]
        public void TestaAdicionarEmpresa()
        {
            // Arrange
            var empresas = new RepositorioEmpresa(_connectionString);

            // Act
            var adiciona = empresas.Adicionar("", "", "", "", "", "", "", "", "");

            // Assert
            Assert.True(adiciona);
        }
    }
}
