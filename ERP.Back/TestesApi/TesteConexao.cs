using Xunit;
using System;

namespace TestesApi
{
    public class TesteConexao
    {
        //private readonly string _stringConexao;

        [Fact]
        public void VerificarConexaoBancoDados()
        {

            // Arrange: Dada Conex�o com o banco de dados
            var conexao = new ERP.Api.Controllers.TesteConexao();

            // Act Verificar se a conex�o com o banco de dados foi realizada
            try
            {
                conexao.ConectarAoBanco();
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Conex�o com o Banco de Dados Falhou: {ex.Message}");
            }
            
            // Assert
            Assert.NotNull(conexao);
        }
    }
}
