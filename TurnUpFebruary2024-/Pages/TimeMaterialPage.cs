using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpFebruary2024_.Utilities;

namespace TurnUpFebruary2024_.Pages
{
    public class TimeMaterialPage
    {
        public void CreateTimeMaterialRecord(IWebDriver driver) 
        {

            //Create a new Time record in Time and Material module//
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

            WaitUtils.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 1);

            IWebElement PriceperUnitTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            PriceperUnitTextbox.SendKeys("20000");

            //click on save button//
            WaitUtils.WaitToBeVisible(driver, "Id", "SaveButton", 2);

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

            if (newRecordCode.Text == "TimeCode" && newRecordTypeCode.Text == "T" && newRecordDescription.Text == "TimeDescription" && newRecordPrice.Text == "$20,000.00")
            {
                Console.WriteLine("New Material/Time record has been created successfully");
            }
            else
            {
                Console.WriteLine("New Material/Time record has not been created successfully :(:( ");

            }

        }
        public void EditTimeMaterialRecord(IWebDriver driver) 
        {
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
            IWebElement EditPriceperUnitOverlappingTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement EditPriceperUnitTextBox = driver.FindElement(By.Id("Price"));
            EditPriceperUnitOverlappingTag.Click();
            EditPriceperUnitTextBox.Clear();
            EditPriceperUnitOverlappingTag.Click();
            EditPriceperUnitTextBox.SendKeys("1000");

            Thread.Sleep(5000);

            //click on save button//
            WaitUtils.WaitToBeVisible(driver, "Id", "SaveButton", 2);

            IWebElement EditSaveButton = driver.FindElement(By.Id("SaveButton"));
            EditSaveButton.Click();

            Thread.Sleep(3000);

            //check if a new record has been edited successfully//
            IWebElement editedgotoLastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editedgotoLastpageButton.Click();

            Thread.Sleep(3000);

            IWebElement editedRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));


            if (editedRecordCode.Text == "TimeCodeedited" && editedRecordDescription.Text == "TimeDescriptionedited")
            {
                Console.WriteLine("New Material/Time record has been edited successfully");
            }
            else
            {
                Console.WriteLine("New Material/Time record has not been edited successfully :(:( ");

            }

        }
        public void DeleteTimeMaterialRecord(IWebDriver driver) 
        {
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

            if (DeletedRecordCode.Text == "TimeCodeedited" && DeletedRecordDescription.Text == "TimeDescriptionedited")
            {
                Console.WriteLine("New Material/Time record has been Deleted successfully");
            }
            else
            {
                Console.WriteLine("New Material/Time record has not been Deleted successfully :(:( ");

            }

        }

    }
}
