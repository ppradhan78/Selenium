using AutoFixture;
using AutoFixture.Xunit2;

namespace Selenium.MVC.SeleniumUITest
{

    [Collection("Sequence")]
    public class CategoryUnitTestAutoFixture : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public CategoryUnitTestAutoFixture(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }

        [Fact]
        public void CreateCategoryFillData()
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            var CategoryName = new Fixture().Create<string>();
            var Description = new Fixture().Create<string>();

            driver.FindElement(By.LinkText("Category")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("CategoryName")).SendKeys(CategoryName);
            driver.FindElement(By.Id("Description")).SendKeys(Description);
            //driver.FindElement(By.Id("btnSave")).Click();
            var exception = Assert.Throws<NoSuchElementException>(
                () => driver.FindElement(By.Id("btnSave")).Click());
            Assert.Contains("no such element", exception.Message);
        }
        [Theory,AutoData]
        public void CreateCategoryFillDataAutoData(string CategoryName,string Description)
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            driver.FindElement(By.LinkText("Category")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("CategoryName")).SendKeys(CategoryName);
            driver.FindElement(By.Id("Description")).SendKeys(Description);
            //driver.FindElement(By.Id("btnSave")).Click();
            var exception = Assert.Throws<NoSuchElementException>(
                () => driver.FindElement(By.Id("btnSave")).Click());
            Assert.Contains("no such element", exception.Message);
        }
    }
}