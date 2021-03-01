using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestXunit.Modals
{
    public  class EditLocationInfoModal: Page
    {
        private IWebElement saveButton;

        private IWebElement maleRadioButton;

        private IWebElement femaleRadioButton;

        public EditLocationInfoModal(IWebDriver driver, WebDriverWait wait)
        {
            /*
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
            */
        }
        public void SaveChanges()
        {
           // saveButton.Click();
        }
    }
}
