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
    public class TakeScreenShoot : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public TakeScreenShoot(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }


        [Fact]
        public void Category_Screen()
        {
            string Home = "http://localhost:88/Category";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(Home);
            driver.FindElement(By.Id("Category")).Click();

            ITakesScreenshot screenshootDriver = (ITakesScreenshot)driver;

            Screenshot screenShoot = screenshootDriver.GetScreenshot();
            screenShoot.SaveAsFile("Category",ScreenshotImageFormat.Png);


        }

   
    }
}