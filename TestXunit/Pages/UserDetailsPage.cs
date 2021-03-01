using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Selenium.POM.Modals;
using OpenQA.Selenium.Chrome;
using TestXunit.Modals;
using System.Collections.Generic;
using System;

namespace Selenium.POM.Pages
{
    public class UserDetailsPage : Page
    {
        public string Gender => genderRow.Text;
        public string TelephoneNumber => editTelephoneNumberInfoButton.Text;

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        [FindsBy(How = How.XPath, Using = UserDetailsPageXPaths.GenderRow)]
        private IWebElement genderRow;

        [FindsBy(How = How.XPath, Using = UserDetailsPageXPaths.EditPersonalInfoButton)]
        private IWebElement editPersonalInfoButton;

        [FindsBy(How = How.XPath, Using = UserDetailsPageXPaths.EditTelephoneNumberInfoButton)]
        private IWebElement editTelephoneNumberInfoButton;

        [FindsBy(How = How.XPath, Using = UserDetailsPageXPaths.EditLocationInfoButton)]
        private IWebElement editLocationInfoButton;

        public UserDetailsPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }


        public T GotToEditPersonalInfo<T> (string modalName) 
        {     
            switch (modalName)
            {
                case "profileInfo":
                    editPersonalInfoButton.Click();
                    break;

                case "locationInfo":
                    editLocationInfoButton.Click();
                    break;
            }      
            
              switch (modalName)
              {
                  case "profileInfo":
                    var  editPersonalInfoModal =  new EditPersonalInfoModal(driver, wait);
                    PageFactory.InitElements(GetSearchContext(driver, wait), editPersonalInfoModal);
                    return (T)Convert.ChangeType(editPersonalInfoModal, typeof(T));


                  case "locationInfo":
                     var editlocationInfoModal =  new EditLocationInfoModal(driver, wait);
                     PageFactory.InitElements(GetSearchContext(driver, wait), editlocationInfoModal);
                     return (T)Convert.ChangeType(editlocationInfoModal, typeof(T));
              }
            return (T)Convert.ChangeType("", typeof(T));
        }

        private static class UserDetailsPageXPaths
        {
            public const string GenderRow = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[1]/div/div[2]/table/tbody/tr[5]/td[2]";
            public const string EditPersonalInfoButton = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[1]/div/div[3]/button[1]";
            public const string EditLocationInfoButton = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[2]/div/div[3]/button";
            public const string EditTelephoneNumberInfoButton = "/html/body/div[7]/div[3]/form/div/div/div[1]/div/div[6]/div/div/input";
        }

    }
}