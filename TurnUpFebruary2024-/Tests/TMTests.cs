using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TurnUpFebruary2024_.Pages;
using TurnUpFebruary2024_.Utilities;

namespace TurnUpFebruary2024_.Tests
{
    [Parallelizable]
    [TestFixture]
    public class TMTests : CommonDriver
    {
        [SetUp]
        public void SetUpTimeAndMaterial()
        {
            //Open Chrome/Firefox browser
            driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");
            HomePage homePageObj = new HomePage();
            homePageObj.VerifyLoggedInUser(driver);
            homePageObj.NavigateToTMPage(driver);

        }

        [Test, Order(1), Description("This is create a new Employee record with valid details")]
        public void TestCreateEmployeeRecord()
        {
            
            TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
            timeMaterialPageObj.CreateTimeMaterialRecord(driver);

        }

        [Test, Order(2), Description("This is Edit the new Time/Material record with valid data")]
        public void TestEditTimeMaterialRecord()
        {
           
            TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
            timeMaterialPageObj.EditTimeMaterialRecord(driver);

        }

        [Test, Order(3), Description("This is Delete the last Time/Material record")]
        public void TestDeleteTimeMaterialRecord()
        {
            
            TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
            timeMaterialPageObj.DeleteTimeMaterialRecord(driver);

        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();

        }


    }
}

