using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

//Open Chrome/Firefox browser
IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

//Launch TurnUp portal and navigate to website login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

//Identify username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//Identify password textbox and enter valid passwordI
IWebElement PasswordTextbox = driver.FindElement(By.Id("Password"));
PasswordTextbox.SendKeys("123123");

//Identify login button and click on Login button
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click( );

//Check if the user has logged in successfully
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
if(helloHari.Text == "Hello hari!")
        {
    Console.WriteLine("user has logged in successfully");
}
else
{
    Console.WriteLine("user has not been logged in successfully :(:( ");

}