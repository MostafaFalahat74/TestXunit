using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Selenium.POM.Modals;
using OpenQA.Selenium.Chrome;

namespace Selenium.POM.Pages
{
    public class UserDetailsPage : Page
    {
        public string Gender => genderRow.Text;

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        [FindsBy(How = How.XPath, Using = UserDetailsPageXPaths.GenderRow)]
        private IWebElement genderRow;

        [FindsBy(How = How.XPath, Using = UserDetailsPageXPaths.EditPersonalInfoButton)]
        private IWebElement editPersonalInfoButton;

        [FindsBy(How = How.XPath, Using = UserDetailsPageXPaths.EditLocationInfoButton)]
        private IWebElement editLocationInfoButton;

        public UserDetailsPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public EditPersonalInfoModal GotToEditPersonalInfo(string modalName)
        {
         //   IWebElement editPersonalInfoButton = null;
            switch (modalName)
            {
                case "profileInfo":
                    editPersonalInfoButton.Click();
                    break;

                case "locationInfo":
                    editLocationInfoButton.Click();
                    break;
            }


            editPersonalInfoButton.Click();

            var editPersonalInfoModal = new EditPersonalInfoModal(driver, wait);

            PageFactory.InitElements(GetSearchContext(driver, wait), editPersonalInfoModal);

            return editPersonalInfoModal;
        }

        private static class UserDetailsPageXPaths
        {
            public const string GenderRow = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[1]/div/div[2]/table/tbody/tr[5]/td[2]";
            public const string EditPersonalInfoButton = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[1]/div/div[3]/button[1]";
            public const string EditLocationInfoButton = "/html/body/div[1]/div/div/div/main/div/div/div[2]/div[2]/div/div[2]/div/div[3]/button";
        }

    }
}