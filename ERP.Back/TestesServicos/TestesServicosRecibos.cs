using ERP.Servico.Negocio;
using ERP.Servicos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestesServicos
{
    public class TestesServicosRecibos
    {
        protected const string _connectionString = "Server=localhost,1401;Database=ERP;User Id = sa; Password=Tccpbcr123@";
        private readonly RepositorioRecibo recibos;

        public TestesServicosRecibos()
        {
            recibos = new RepositorioRecibo(_connectionString);
        }

        [Fact]
        public void TestaListaRecibo()
        {
            // Arrange

            // Act
            List<Recibo> lista = recibos.ListaRecibos();

            // Assert
            Assert.NotNull(lista);
        }

        [Theory]
        [InlineData(new int[] { 2, 3, 4 })]
        public void TestaBuscaReciboID(int[] ids)
        {
            // Arrange
            List<Recibo> recibo;

            // Act
            foreach (var id in ids)
            {
                recibo = recibos.BuscaReciboCompleto(id);
                // Assert
                Assert.NotNull(recibo);
            }
        }

        [Fact]
        public void TestaBuscaRecibosPagar()
        {
            // Arrange

            // Act
            List<Recibo> reciboapagar = recibos.BuscaReciboCompletoApagar();

            // Assert
            Assert.NotNull(reciboapagar);
        }

        [Fact]
        public void TestaBuscaRecibosReceber()
        {
            // Arrange

            // Act
            List<Recibo> reciboareceber = recibos.BuscaReciboCompletoAreceber();

            // Assert
            Assert.NotNull(reciboareceber);
        }

        [Fact]
        public void TestaBuscaReciboCPF_CNPJ()
        {
            // Arrange

            // Act
            List<Recibo> recibo = recibos.BuscaReciboCPF_CNPJ("");

            // Assert
            Assert.NotNull(recibo);
        }

        [Fact]
        public void TestaBuscaReciboNome()
        {
            // Arrange

            // Act
            List<Recibo> recibo = recibos.BuscaReciboNome("");

            // Assert
            Assert.NotNull(recibo);
        }

        [Fact]
        public void TestaAdicionarRecibo()
        {
            // Arrange

            // Act
            var recibo = recibos.Adicionar("", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "");

            // Assert
            Assert.True(recibo);
        }

        [Fact]
        public void TestaDeletarRecibo()
        {
            // Arrange
            var idMAX = recibos.ConexaoIDMAX() - 1;

            // Act
            var deletar = recibos.Deletar(idMAX);

            // Assert
            Assert.True(deletar);
        }

        [Fact]
        public void TestaAtualizarRecibo()
        {
            // Arrange
            var idMAX = recibos.ConexaoIDMAX() - 1;

            // Act
            var atualizar = recibos.Atualizar(idMAX, "", 0, "ABC", "", "", "", "", "", "", "", "", "", "", "", "");

            // Assert
            Assert.True(atualizar);
        }
    }
}
