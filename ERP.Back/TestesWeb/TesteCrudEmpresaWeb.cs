using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesWeb.Fixtures;
using Xunit;

namespace TestesWeb
{
    [Collection("Edge")]
    public class TesteCrudEmpresaWeb
    {
        //private IWebDriver driver;

        //public TesteCrudEmpresaWeb(TestesFixture fixture)
        //{
        //    driver = fixture.Driver;
        //}

        //private void NavegarURL()
        //{
        //    driver.Navigate().GoToUrl("http://localhost:50663/swagger/index.html");
        //}

        //[Fact]
        //public void AoPesquisarEmpresaporCNPJ()
        //{
        //    // Arrange - Dado Navegador Aberto
        //    NavegarURL();

        //    // Act
        //    // Clicar em GET - Empresa/CNPJ,
        //    var classGetCNPJ = driver.FindElements(By.Id("operations-Empresa-get_Empresa_Lista_json"));            

        //    // depois clicar em Try it Out,
        //    var butaoTry = driver.FindElements(By.ClassName("btn try-out__btn"));
        //    butaoTry.Click();

        //    // inserir CNPJ para Busca e


        //    // clicar em "Execute"


        //    // Assert - O retorno deve ser Code 200 - Description "Success"

        //}

        //[Fact]
        //public void AoAdicionarEmpresa()
        //{
        //    // Arrange - Dado Navegador aberto
        //    NavegarURL();
        //    // id="operations-Empresa-post_Empresa_Adicionar_json"
        //    var classAdicionar = driver.FindElements(By.Id("operations-Empresa-post_Empresa_Adicionar_json"));

        //    // Act - Selecionar POST-Empresa/Adicionar , Clicar em Try it Out e informar
        //    // Razao

        //    // CNPJ
        //    // NumeroEndereco
        //    // Complemento
        //    // CEP
        //    // Logradouro
        //    // Bairro
        //    // Localidade
        //    // UF

        //    // Assert

        //}
    }
}
