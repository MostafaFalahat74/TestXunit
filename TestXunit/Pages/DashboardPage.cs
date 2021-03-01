using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium.POM.Pages
{
    public class DashboardPage : Page
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = DashboardPageXPaths.ProfileDropDown)]
        private IWebElement profileDropDown;

        public DashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public UserDetailsPage GoToUserDetails()
        {
            profileDropDown.Click();

            var dropDownBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(DashboardPageXPaths.DropDownBox)));

            IWebElement editLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(DashboardPageXPaths.EditProfileLink)));


            editLink.Click();

            var userDetailsPage = new UserDetailsPage(driver, wait);

            PageFactory.InitElements(GetSearchContext(driver, wait), userDetailsPage);

            return userDetailsPage;
        }

        private static class DashboardPageXPaths
        {
            public const string ProfileDropDown = "/html/body/div[1]/div/div/div/main/header/div/div/div[1]/div/div/div[2]/button";
            public const string DropDownBox = "/html/body/div[3]";
            public const string EditProfileLink = "//*[@id=\"customized-menu\"]/div[3]/ul/li[1]/a";
            public const string EditLocationLink = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[2]/div/div[3]/button";
        }
    }
}