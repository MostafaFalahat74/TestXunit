using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.POM.Pages;
using SeleniumExtras.PageObjects;
using TestXunit;

namespace Selenium.POM
{
    public abstract class ChangeProfileTestsFixture : TestsFixtureBase, IDisposable 
    {
        private readonly ChromeDriver driver;
        private readonly WebDriverWait wait;

        protected ChangeProfileTestsFixture()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver = new ChromeDriver(options);

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

            driver.Navigate().GoToUrl(WebSiteUrl);

            driver.ExecuteScript("window.localStorage.clear()");
            driver.ExecuteScript("window.sessionStorage.clear()");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
        }

        public abstract string WebSiteUrl { get; }

        protected IndexPage GetIndexPage()
        {
            var indexPage = new IndexPage(driver, wait);

            PageFactory.InitElements(driver, indexPage);

            return indexPage;
        }

        public void Dispose()
            {
            Thread.Sleep(TimeSpan.FromSeconds(3));

            driver.Dispose();
        }
    }
}