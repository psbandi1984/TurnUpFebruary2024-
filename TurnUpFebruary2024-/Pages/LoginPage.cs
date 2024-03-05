using OpenQA.Selenium;

namespace TurnUpFebruary2024_.Pages
{
    public class LoginPage
    {
        public readonly By usernameTextboxLocator = By.Id("UserName");
        IWebElement usernameTextbox;
        public readonly By passwordTextboxLocator = By.Id("Password");
        IWebElement passwordTextbox;
        public readonly By loginButtonLocator = By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]");
        IWebElement loginButton;


        public void LoginActions(IWebDriver driver, string username, string password)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                  
            //Launch TurnUp portal and navigate to website login page
            string baseURL = "http://horse.industryconnect.io/";
            driver.Navigate().GoToUrl(baseURL);

            //Identify username textbox and enter valid username
            usernameTextbox = driver.FindElement(usernameTextboxLocator);
            usernameTextbox.SendKeys(username);

            //Identify password textbox and enter valid password
            passwordTextbox = driver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);

            //Identify login button and click on Login button
            loginButton = driver.FindElement(loginButtonLocator);
            loginButton.Click();

        }
    }
}
