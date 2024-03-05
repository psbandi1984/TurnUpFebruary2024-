using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpFebruary2024_.Utilities;

namespace TurnUpFebruary2024_.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //Navigate to Time and Material module (click on Administration dropdown menu button)//
            IWebElement AdministrationDropdown = driver.FindElement(By.XPath("//*[contains(text(),'Administration')]"));
            AdministrationDropdown.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Time & Materials')]")));

            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[contains(text(),'Time & Materials')]", 3);

            IWebElement TimeAndMaterialOption = driver.FindElement(By.XPath("//*[contains(text(),'Time & Materials')]"));
            TimeAndMaterialOption.Click();
            
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
