using System.Collections.Generic;
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

        [Fact]
        public void TestaBuscaCPF()
        {
            // Arrange
            var pessoas = new RepositorioPessoa(_connectionString);

            // Act
            List<Pessoa> pessoa = pessoas.BuscaCpf("");

            // Assert
            Assert.NotNull(pessoa);
        }

        [Fact]
        public void TestaBuscaNome()
        {
            // Arrange
            var pessoas = new RepositorioPessoa(_connectionString);

            // Act
            List<Pessoa> pessoa = pessoas.BuscaNome("");

            // Assert
            Assert.NotNull(pessoa);
        }

        [Fact]
        public void TestaAdicionarPessoa()
        {
            // Arrange
            var pessoas = new RepositorioPessoa(_connectionString);

            // Act
            var adiciona = pessoas.Adicionar("", "", "", "", "", "", "", "", "");

            // Assert
            Assert.True(adiciona);
        }

        [Fact]
        public void TestaAtualizarPessoa()
        {
            // Arrange
            var pessoas = new RepositorioPessoa(_connectionString);

            // Act
            var atualiza = pessoas.Atualizar("", "", "", "", "", "", "", "", "", "");

            // Assert
            Assert.True(atualiza);
        }

        [Fact]
        public void TestaDeletarPessoa()
        {
            // Arrange
            var pessoas = new RepositorioPessoa(_connectionString);

            // Act
            var deletar = pessoas.Deletar("");

            // Assert
            Assert.True(deletar);
        }
    }
}