using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium.POM.Pages
{
    public sealed class IndexPage : Page
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = IndexPageXPaths.LoginButton)]
        private IWebElement loginButton;

        public IndexPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public LoginPage GoToLoginPage()
        {
            loginButton.Click();

            var loginPage = new LoginPage(driver, wait);

            PageFactory.InitElements(GetSearchContext(driver, wait), loginPage);

            return loginPage;
        }

        private static class IndexPageXPaths
        {
            public const string LoginButton = "/html/body/header/div/div/div/div/nav/div[2]/ul/li[4]/div/div[2]/a[1]";
        }
    }
}