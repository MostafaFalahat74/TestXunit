using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using SeleniumExtras.PageObjects;
using Xunit;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using System;

namespace Selenium.POM.Modals
{
    public class EditPersonalInfoModal : Page
    {
        private IWebElement saveButton;

        private IWebElement maleRadioButton;

        private IWebElement femaleRadioButton;

        public EditPersonalInfoModal(IWebDriver driver, WebDriverWait wait)
        {
            var searchContext = GetSearchContext(driver, wait);

            var genders = searchContext.FindElements(By.Name("gender"));

            maleRadioButton = genders.Single(e => e.GetAttribute("value") == "male");
            femaleRadioButton = genders.Single(e => e.GetAttribute("value") == "female");
            saveButton = searchContext
                .FindElements(By.TagName("button"))
                .Single(e => e.GetAttribute("type") == "submit");

            wait.Until(ExpectedConditions.ElementToBeClickable(maleRadioButton));
            wait.Until(ExpectedConditions.ElementToBeClickable(femaleRadioButton));
            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton));
        }

        public void ChooseMale()
        {
            maleRadioButton.Click();

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void ChooseFemale()
        {
            femaleRadioButton.Click();

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void SaveChanges()
        {
            saveButton.Click();
        }
    }
}