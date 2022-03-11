using System.Collections.Generic;
using Xunit;
using ERP.Servico.Servicos.Repositorio;
using ERP.Servico.Negocio;

namespace TestesServicos
{
    public class TestesServicoEmpresa
    {
        protected const string _connectionString = "Server=localhost,1401;Database=ERP;User Id = sa; Password=Tccpbcr123@";
        private RepositorioEmpresa empresas;

        public TestesServicoEmpresa()
        {
            empresas = new RepositorioEmpresa(_connectionString);
        }

        [Fact]
        public void TestaListarTodasEmpresas()
        {
            // Arrange
            
            // Act
            List<Empresa> lista = empresas.Lista();

            // Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestarPesquisaporCNPJ()
        {
            // Arrange

            // Act
            List<Empresa> empresa = empresas.BuscaCnpj("");

            // Assert
            Assert.NotNull(empresa);
        }

        [Fact]
        public void TestaAdicionarEmpresa()
        {
            // Arrange

            // Act
            var adiciona = empresas.Adicionar("", "", "", "", "", "", "", "", "");

            // Assert
            Assert.True(adiciona);

        }

        [Fact]
        public void TestaAtualizarEmpresa()
        {
            // Arrange

            // Act
            var atualizar = empresas.Atualizar(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ");

            // Assert
            Assert.True(atualizar);
        }

        [Fact]
        public void TestaDeletarEmpresa()
        {
            // Arrange

            // Act
            var deletar = empresas.Deletar(" ");

            // Assert
            Assert.True(deletar);
        }
    }
}
