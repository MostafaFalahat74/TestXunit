using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium.POM.Pages
{
    public sealed class LoginPage : Page
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = LoginPageXPaths.Username)]
        private IWebElement username;


        [FindsBy(How = How.XPath, Using = LoginPageXPaths.Password)]
        private IWebElement password;


        [FindsBy(How = How.XPath, Using = LoginPageXPaths.LoginButton)]
        private IWebElement loginButton;

        private readonly WebDriverWait wait;
        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            this.wait = wait;
            this.driver = driver;
        }

        public void EnterUsername(string username)
        {
            this.username.Clear();
            this.username.SendKeys(username);
        }

        public void EnterPassowrd(string password)
        {
            this.password.Clear();
            this.password.SendKeys(password);
        }

        public DashboardPage LogInToDashboard()
        {
            this.loginButton.Click();

            var dashboardPage = new DashboardPage(driver, wait);

            PageFactory.InitElements(GetSearchContext(driver, wait), dashboardPage);

            return dashboardPage;
        }

        private static class LoginPageXPaths
        {
            public const string Username = "/html/body/div[1]/div/div/div/div/div/div/form/div[1]/div[1]/div/input";
            public const string Password = "/html/body/div[1]/div/div/div/div/div/div/form/div[1]/div[2]/div/input";
            public const string LoginButton = "/html/body/div[1]/div/div/div/div/div/div/form/div[2]/button";
        }
    }
}