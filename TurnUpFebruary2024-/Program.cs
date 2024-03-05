using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpFebruary2024_.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome/Firefox browser
        IWebDriver driver = new ChromeDriver();

        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver, "hari", "123123");

        HomePage homePageObj = new HomePage();
        homePageObj.VerifyLoggedInUser(driver);
        homePageObj.NavigateToTMPage(driver);

        TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
        timeMaterialPageObj.CreateTimeMaterialRecord(driver);
        timeMaterialPageObj.EditTimeMaterialRecord(driver);
        timeMaterialPageObj.DeleteTimeMaterialRecord(driver);

    }

}