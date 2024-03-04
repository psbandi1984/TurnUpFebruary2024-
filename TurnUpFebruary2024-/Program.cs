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

//Identify password textbox and enter valid password
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
//=======================================================================================//

//Create a new Time record in Time and Material module//

//Navigate to Time and Material module (click on Administration dropdown menu button)//
IWebElement AdministrationDropdown = driver.FindElement(By.XPath("//*[contains(text(),'Administration')]"));
AdministrationDropdown.Click();
IWebElement TimeAndMaterialOption = driver.FindElement(By.XPath("//*[contains(text(),'Time & Materials')]"));
TimeAndMaterialOption.Click();

//Click on create New button//
IWebElement CreateNewbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
CreateNewbutton.Click();


//Select Typecode and Enter data in all the fields(Code, Description, Price per Unit)//
IWebElement TypeCodeMainDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
TypeCodeMainDropdown.Click();

//Just to wait for 2 seconds doing nothing//
Thread.Sleep(2000);

IWebElement TypeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
TypeCodeDropdown.Click();

IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
CodeTextbox.SendKeys("TimeCode");  

IWebElement DescriptionTextbox = driver.FindElement(By.Id("Description"));
DescriptionTextbox.SendKeys("TimeDescription"); 

IWebElement PriceperUnitTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
PriceperUnitTextbox.SendKeys("20000");

//click on save button//
IWebElement SaveButton = driver.FindElement(By.Id("SaveButton"));
SaveButton.Click();

Thread.Sleep(2000);

//check if a new record has been created successfully//
IWebElement gotoLastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
gotoLastpageButton.Click();

Thread.Sleep(3000);

IWebElement newRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
IWebElement newRecordTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
IWebElement newRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
IWebElement newRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

if ((newRecordCode.Text == "TimeCode") && (newRecordTypeCode.Text == "T") && (newRecordDescription.Text == "TimeDescription") && (newRecordPrice.Text == "$20,000.00"))
{
    Console.WriteLine("New Material/Time record has been created successfully");
}
else
{
    Console.WriteLine("New Material/Time record has not been created successfully :(:( ");

}

//=======================================================================================//

//Edit a new Time record in Time and Material module//

IWebElement newgotoLastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
newgotoLastpageButton.Click();

Thread.Sleep(2000);

//Click on Edit button of a new time record in the last page//
IWebElement EditButton = driver.FindElement(By.XPath("//tr[last()]/td[5]/a[1]"));
EditButton.Click();

Thread.Sleep(2000);

//Edit data in all the fields(Code, Description, Price per Unit)//
IWebElement EditCodeTextbox = driver.FindElement(By.Id("Code"));
EditCodeTextbox.Clear();
EditCodeTextbox.SendKeys("TimeCodeEdited");

IWebElement EditDescriptionTextbox = driver.FindElement(By.Id("Description"));
EditDescriptionTextbox.Clear();
EditDescriptionTextbox.SendKeys("TimeDescriptionEdited");

Thread.Sleep(5000);

IWebElement EditPriceperUnitTextbox = driver.FindElement(By.Id("Price"));
EditPriceperUnitTextbox.Clear();
EditPriceperUnitTextbox.SendKeys("1000");

Thread.Sleep(5000);

//click on save button//
IWebElement EditSaveButton = driver.FindElement(By.Id("SaveButton"));
EditSaveButton.Click();

Thread.Sleep(3000);

//check if a new record has been edited successfully//
IWebElement editedgotoLastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
editedgotoLastpageButton.Click();

Thread.Sleep(3000);

IWebElement editedRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
IWebElement editedRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
IWebElement editedRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

if ((editedRecordCode.Text == "TimeCodeedited") && (editedRecordDescription.Text == "TimeDescriptionedited") && (editedRecordPrice.Text == "$1,000.00"))
{
    Console.WriteLine("New Material/Time record has been edited successfully");
}
else
{
    Console.WriteLine("New Material/Time record has not been edited successfully :(:( ");

}


//=======================================================================================//

//Delete a new Time record in Time and Material module//
IWebElement deletegotoLastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
deletegotoLastpageButton.Click();

Thread.Sleep(2000);

//Click on Delete button of a new time record in the last page//
IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
DeleteButton.Click();

Thread.Sleep(3000);

//Switch to Alert Delete message //
IAlert DeleteAlert = driver.SwitchTo().Alert();
DeleteAlert.Accept();

//check if a new record has been deleted successfully//

Thread.Sleep(3000);

IWebElement DeletedRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
IWebElement DeletedRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

if((DeletedRecordCode.Text == "TimeCodeedited") && (DeletedRecordDescription.Text == "TimeDescriptionedited"))
{
    Console.WriteLine("New Material/Time record has been Deleted successfully");
}
else
{
    Console.WriteLine("New Material/Time record has not been Deleted successfully :(:( ");

}
















