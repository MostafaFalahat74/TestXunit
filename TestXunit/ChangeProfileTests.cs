
using Selenium.POM.Pages;
using System;
using Xunit;

namespace Selenium.POM
{
    public class ChangeProfileTests : ChangeProfileTestsFixture
    {
        public override string WebSiteUrl => "http://myholoo.ir/";

        [Fact]
        public void Change_User_Gender()
        {
            var fromGender = "مرد";
            var toGender = "زن";

             Mafruz_Ast_Karbar_username_Va_password_Ba_Jensiateh_gender(username: "09122436777", password: "n123456789", fromGender);

             Zamani_Keh_Karbar_Darkhasteh_Taghireh_Jenseiat_Az_fromGender_Beh_toGender(fromGender, toGender );

            Angah_Jenseiateh_Karbar_Beh_toGender_Taghir_Mikonad(toGender );
        }

        private void Mafruz_Ast_Karbar_username_Va_password_Ba_Jensiateh_gender(string username, string password, string gender)
        {
            var indexPage = GetIndexPage();

            var loginPage = indexPage.GoToLoginPage();

            loginPage.EnterUsername("09122436777");
            loginPage.EnterPassowrd("n123456789");

            var dashboard = loginPage.LogInToDashboard();
            SetObjectToScenarioContext("pages-dashboard", dashboard);
        }

        private void Zamani_Keh_Karbar_Darkhasteh_Taghireh_Jenseiat_Az_fromGender_Beh_toGender(string fromGender, string toGender )
        {          
            var dashboard = GetObjectToScenarioContext<DashboardPage>("pages-dashboard");

            var userDetails = dashboard.GoToUserDetails();

            var editPersonalInfoModal = userDetails.GotToEditPersonalInfo("profileInfo");

            var choice = string.Empty;

            if (userDetails.Gender == "زن")
            {
                editPersonalInfoModal.ChooseMale();

                choice = "مرد";
            }
            else if (userDetails.Gender == "مرد")
            {
                editPersonalInfoModal.ChooseFemale();

                choice = "زن";
            }

            editPersonalInfoModal.SaveChanges();
            SetObjectToScenarioContext("pages-userDetails", userDetails);
        }

        private void Angah_Jenseiateh_Karbar_Beh_toGender_Taghir_Mikonad(string toGender )
        {
            var userDetails = GetObjectToScenarioContext<UserDetailsPage>("pages-userDetails");
            var gender = userDetails.Gender;
            Assert.Equal(toGender, userDetails.Gender);
        }


    }
}
