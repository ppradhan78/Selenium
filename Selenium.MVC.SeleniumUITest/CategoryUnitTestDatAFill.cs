using FluentAssertions;
namespace Selenium.MVC.SeleniumUITest
{

    [Collection("Sequence")]
    public class CategoryUnitTestDatAFill : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public CategoryUnitTestDatAFill(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }
     
        //[Fact]
        [Theory]
        //[InlineData("Electronic", "Electronic & Home Applience")]
        //[InlineData("Dress", "Kides ware")]
        [InlineData("Office", "Office materials")]
        public void CreateCategory(string CategoryName, string Description)
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            driver.FindElement(By.LinkText("Category")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("CategoryName")).SendKeys(CategoryName);
            driver.FindElement(By.Id("Description")).SendKeys(Description);
            driver.FindElement(By.Id("btnSave")).Click();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CreateCategoryFillData(string CategoryName, string Description)
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            driver.FindElement(By.LinkText("Category")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("CategoryName")).SendKeys(CategoryName);
            driver.FindElement(By.Id("Description")).SendKeys(Description);
            //driver.FindElement(By.Id("btnSave")).Click();
            var exception=Assert.Throws<NoSuchElementException>(
                ()=> driver.FindElement(By.Id("btnSave")).Click());
            Assert.Contains("no such element", exception.Message);
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void CreateCategoryFillDataFluentAsset(string CategoryName, string Description)
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            driver.FindElement(By.LinkText("Category")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("CategoryName")).SendKeys(CategoryName);
            driver.FindElement(By.Id("Description")).SendKeys(Description);
            var exception = Assert.Throws<NoSuchElementException>(
                () => driver.FindElement(By.Id("btnSave")).Click());


            exception.Message.Should().Contain("no such element");
        }
        public static IEnumerable<object[]> Data = new List<object[]>
        {
            new object[]
            {
                "Electronic",
                "Electronic & Home Applience"
            },
             new object[]
            {
                "Dress",
                "Kides ware"
            },
              new object[]
            {
                "Office",
                "Office matterial"
            }
        };
    }
}