using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.POM.Helpers
{

    using Conditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

    public sealed class SearchContext : ISearchContext
    {
        private readonly WebDriverWait wait;
        private readonly IWebDriver driver;

        public SearchContext(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement FindElement(By by) => GetWebElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => driver.FindElements(by);

        private IWebElement GetWebElement(By ElementBy)
        {
            wait.Until(Conditions.ElementExists(ElementBy));
            wait.Until(Conditions.ElementIsVisible(ElementBy));

            return wait.Until(Conditions.ElementToBeClickable(ElementBy));
        }
    }
}