using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.POM.Helpers;

namespace Selenium.POM
{
    public abstract class Page
    {
        protected SearchContext GetSearchContext(IWebDriver driver, WebDriverWait wait)
            => new SearchContext(driver, wait);
    }
}