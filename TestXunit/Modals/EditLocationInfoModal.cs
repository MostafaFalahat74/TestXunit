using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.POM;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestXunit.Modals
{
    public  class EditLocationInfoModal: Page
    {
        private IWebElement saveButton;
        private IWebDriver driver;

        public EditLocationInfoModal(IWebDriver driver, WebDriverWait wait)
        {
           this.driver = driver;
            var searchContext = GetSearchContext(driver, wait);


            saveButton = searchContext.FindElements(By.TagName("button")).Single(e => e.GetAttribute("type") == "submit");
            wait.Until(ExpectedConditions.ElementToBeClickable(saveButton));
            
        }
        public void ChangeTelephoneNumber( string phoneNumber)
        {
          
            var telephoneNumber = driver.FindElement(By.XPath(EditLocationInfoModalXPath.TelephoneNumber));
            telephoneNumber.Clear();
            telephoneNumber.SendKeys(phoneNumber);
        }
        public void SaveChanges()
        {
            saveButton.Click();
            //
        }
        private static class EditLocationInfoModalXPath
        {
            public const string TelephoneNumber = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[2]/div/div[2]/table/tbody/tr[7]/td[2]";
        }
    }
}
