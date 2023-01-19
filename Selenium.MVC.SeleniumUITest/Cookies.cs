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
    public class Cookies : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public Cookies(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }


        [Fact]
        public void Category_Tab()
        {
            string Home = "http://localhost:88/";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(Home);

            driver.Manage().Cookies.AddCookie(new Cookie("acceptCookies", "true"));
            driver.Navigate().Refresh();
            ReadOnlyCollection<IWebElement> element = driver.FindElements(By.Id("cookesUsed"));

            Assert.Empty(element);

            Cookie cookiesvalue = driver.Manage().Cookies.GetCookieNamed("acceptCookies");
            Assert.Equal("true",cookiesvalue.Value);

        }


    }
}