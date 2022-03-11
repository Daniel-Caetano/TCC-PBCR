using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using System.Reflection;
using TestesWeb.Fixtures;
using TestesWeb.Helpers;
using Xunit;

namespace TestesWeb
{
    [Collection("Edge")]
    public class AoNavegarParaPagina
    {
        private readonly IWebDriver driver;

        public AoNavegarParaPagina(TestesFixture fixture)
        {
            driver = fixture.Driver;
        }

        private void NavegarURL()
        {
            driver.Navigate().GoToUrl("http://localhost:50663/swagger/index.html");
        }

        [Fact]
        public void EdgeAbertoVerificarNomeNaPagina()
        {
            // Arrange

            // Act - Navegar para a URL
            NavegarURL();

            // Assert - espera-se que a pagina aberta contenha a palavra ERP.Api
            Assert.Contains("ERP.Api", driver.PageSource);
        }
    }
}