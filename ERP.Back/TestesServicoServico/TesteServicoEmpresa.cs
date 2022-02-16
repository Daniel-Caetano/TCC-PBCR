using System;
using Xunit;
using System.Collections.Generic;
using ERP.Servico.Negocio;
using ERP.Servico.Servicos.Servico;

namespace TestesServicoServico
{
    public class TesteServicoEmpresa
    {
        private readonly string _stringConexao;
        [Fact]
        public void Test1()
        {
            // Arrange
            var empresa = new ServicoEmpresa(_stringConexao);

            // Act
            empresa.Lista();

            // Assert
            Assert.NotNull(empresa.Lista());
        }
    }
}
