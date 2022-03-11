using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using TestesWeb.Helpers;

namespace TestesWeb.Fixtures
{
    public class TestesFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public TestesFixture()
        {
            Driver = new EdgeDriver(TestesHelpers.Executavel);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
