using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace Selenium.MVC.SeleniumUITest
{
    //public class UnitTest1
    //{
    //    private ChromeDriver chromeDriver;

    //    public UnitTest1()
    //    {
    //        //driver
    //        var driver = new DriverManager().SetUpDriver(new ChromeConfig());
    //        chromeDriver = new ChromeDriver();
    //    }
    //    [Fact]
    //    public void Test1()
    //    {
    //        chromeDriver.Navigate().GoToUrl("http://localhost:88/");

    //    }
    //}
    [Collection("Sequence")]
    public class BrowserSizeAndPosition : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public BrowserSizeAndPosition(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }

      
        [Fact]
        public void Category_Fill_Form()
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/Category/Create");

            driver.Manage().Window.Maximize();
            Thread.Sleep(500);
            driver.Manage().Window.Minimize();
            Thread.Sleep(500);
            driver.Manage().Window.Size = new System.Drawing.Size(300, 400);
            Thread.Sleep(500);

            driver.Manage().Window.Position = new System.Drawing.Point(1,1);
            Thread.Sleep(500);
            driver.Manage().Window.Position = new System.Drawing.Point(50, 50);
            Thread.Sleep(500);
            driver.Manage().Window.Position = new System.Drawing.Point(150, 150);
            Thread.Sleep(500);
            driver.Manage().Window.FullScreen();


            //IWebElement CategoryID = driver.FindElement(By.Id("CategoryID"));
            //Random rnd = new Random();
            //int num = rnd.Next(1, 13);
            //CategoryID.SendKeys(num.ToString());

            //IWebElement CategoryName = driver.FindElement(By.Id("CategoryName"));
            //CategoryName.SendKeys(Guid.NewGuid().ToString());

            //IWebElement Description = driver.FindElement(By.Id("Description"));
            //Description.SendKeys(Guid.NewGuid().ToString());

            //IWebElement rbRequired = driver.FindElement(By.Id("rbRequired"));
            //rbRequired.Click();

            //IWebElement cbRequired = driver.FindElement(By.Id("cbRequired"));
            //cbRequired.Click();

            //IWebElement ddRequired = driver.FindElement(By.Id("ddRequired"));
            //SelectElement elelemnt =new SelectElement(ddRequired);

            //Assert.Equal("Required", elelemnt.SelectedOption.Text);

            ////IWebElement dtRequired = driver.FindElement(By.Id("dtRequired"));
            ////CategoryName.SendKeys(Guid.NewGuid().ToString());


        }
    }
}