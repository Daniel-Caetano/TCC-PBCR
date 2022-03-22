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
            var reciboAd = recibos.IDMAX();
            var reciboDados = recibos.BuscaReciboCompleto(reciboAd);

            // Act
            var adiciona = recibos.Adicionar("Teste", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "");

            // Assert
            Assert.Equal(reciboDados, adiciona);
        }

        [Fact]
        public void TestaDeletarRecibo()
        {
            // Arrange: dado ID do recibo existente


            // Act: deletar recibo pelo id informado

            // Assert: verificar que o id do recibo deletado não exista no banco de dados
        }

        [Fact]
        public void TestaAtualizarRecibo()
        {
            // Arrange: dado id do recibo

            // Act: atualizar os dados do recibo

            // Assert: verificar que os dados do recibo foram atualizados
        }
    }
}
