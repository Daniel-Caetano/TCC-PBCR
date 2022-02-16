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

            // Arrange: Dada Conexão com o banco de dados
            var conexao = new ERP.Api.Controllers.TesteConexao();

            // Act Verificar se a conexão com o banco de dados foi realizada
            try
            {
                conexao.ConectarAoBanco();
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Conexão com o Banco de Dados Falhou: {ex.Message}");
            }
            
            // Assert
            Assert.NotNull(conexao);
        }
    }
}
