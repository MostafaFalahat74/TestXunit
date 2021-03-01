
using Selenium.POM;
using Selenium.POM.Pages;
using System;
using TestXunit.Modals;
using Xunit;
namespace TestXunit
{
    public class ChangeUserLocationInfo : ChangeProfileTestsFixture
    {
        public override string WebSiteUrl => "http://myholoo.ir/";
        [Fact]
        public void Change_User_TelephoneNumber()
        {
            var fromTelephoneNumber = "02122300837";
            var toTelephoneNumber   = "02122300000";

            Mafruz_Ast_Karbar_username_Va_password_Ba_Telephone_Number(username: "09122436777", password: "n123456789", fromTelephoneNumber);

            Zamani_Keh_Karbar_Darkhasteh_Taghireh_TelephoneNumber_Az_fromTelephoneNumber_Beh_toTelephoneNumber(fromTelephoneNumber, toTelephoneNumber);

            Angah_Telephone_Karbar_Beh_toTelephoneNumber_Taghir_Mikonad(toTelephoneNumber);
        }

       

        private void Mafruz_Ast_Karbar_username_Va_password_Ba_Telephone_Number(string username, string password, string fromTelephoneNumber)
        {
            var indexPage = GetIndexPage();

            var loginPage = indexPage.GoToLoginPage();

            loginPage.EnterUsername("09122436777");
            loginPage.EnterPassowrd("n123456789");

            var dashboard = loginPage.LogInToDashboard();
            SetObjectToScenarioContext("pages-dashboard", dashboard);
        }

        private void Zamani_Keh_Karbar_Darkhasteh_Taghireh_TelephoneNumber_Az_fromTelephoneNumber_Beh_toTelephoneNumber(string fromTelephoneNumber, string toTelephoneNumber)
        {
            var dashboard = GetObjectToScenarioContext<DashboardPage>("pages-dashboard");

            var userDetails = dashboard.GoToUserDetails();
            var editLocationInfoModal = userDetails.GotToEditPersonalInfo<EditLocationInfoModal>("locationInfoo");
            editLocationInfoModal.ChangeTelephoneNumber(toTelephoneNumber);
            SetObjectToScenarioContext("pages-userDetails", userDetails);
        }

        private void Angah_Telephone_Karbar_Beh_toTelephoneNumber_Taghir_Mikonad(string toTelephoneNumber)
        {
            var userDetails = GetObjectToScenarioContext<UserDetailsPage>("pages-userDetails");
            Assert.Equal(toTelephoneNumber, userDetails.TelephoneNumber);
        }
    }
}
