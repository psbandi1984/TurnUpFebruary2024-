using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TurnUpFebruary2024_.Utilities;

namespace TurnUpFebruary2024_.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            try
            {

                //Navigate to Time and Material module (click on Administration dropdown menu button)//
                IWebElement AdministrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                AdministrationDropdown.Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")));

                WaitUtils.WaitToBeVisible(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

                IWebElement TimeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                TimeAndMaterialOption.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal dashboard tab is not clickable");
            }

        }

        public void NavigateToEmployeePage(IWebDriver driver)
        {
            try
            {

                //Navigate to Employee module (click on Administration dropdown menu button)//
                IWebElement AdministrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                AdministrationDropdown.Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")));

                WaitUtils.WaitToBeVisible(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 3);

                IWebElement EmployeeOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
                EmployeeOption.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal dashboard tab is not clickable");
            }

        }



        public void VerifyLoggedInUser(IWebDriver driver)
        {
            //Check if the user has logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("user has logged in successfully");
            }
            else
            {
                Console.WriteLine("user has not been logged in successfully :(:( ");

            }

        }

    }
}
