using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
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
    public class CategoryUnitTestNavigation : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public CategoryUnitTestNavigation(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }


        [Fact]
        public void CategoryPageNavigate()
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            driver.FindElement(By.LinkText("Privacy")).Click();
            driver.FindElement(By.LinkText("Category")).Click();
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("btnSave")).Click();
            driver.FindElement(By.LinkText("building Web apps with ASP.NET Core")).Click();
        }

        [Fact]
        public void CategoryPageNavigateAnchorCount()
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            var anchor = driver.FindElements(By.TagName("a"));
            anchor.Should().HaveCount(6);
        }
    }
}