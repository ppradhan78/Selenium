using FluentAssertions;

namespace Selenium.MVC.SeleniumUITest
{
    [Collection("Sequence")]
    public class CategoryUnitTestNavigation : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public CategoryUnitTestNavigation(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }

        [Fact]
        public void CategoryPageNavigate_Title()
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/");

            string PageTitle = driver.Title;

            Assert.Equal("Home Page - Selenium.MVC", PageTitle);
        }
        [Fact]
        public void CategoryPageNavigate_Url()
        {
            string url = "http://localhost:88/";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(url);
            string Pageurl = driver.Url;
            Assert.Equal(url, Pageurl);
        }

        [Fact]
        public void CategoryPageNavigate_Back()
        {
            string HomeUrl = "http://localhost:88/";
            string Catgeory = "http://localhost:88/Category";

            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(HomeUrl);
            driver.Navigate().GoToUrl(Catgeory);
            driver.Navigate().Back();
            string PageTitle = driver.Title;
            Assert.Equal("Home Page - Selenium.MVC", PageTitle);
        }

        [Fact]
        public void CategoryPageNavigate_Xpath()
        {
            string HomeUrl = "http://localhost:88/";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(HomeUrl);

            IWebElement element = driver.FindElement(By.XPath("/html/body/footer/div/a"));
            element.Click();

            Assert.Equal(driver.Url, "http://localhost:88/Home/Privacy");

        }
        [Fact]
        public void CategoryPageNavigate_CSSSelector()
        {
            string HomeUrl = "http://localhost:88/";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(HomeUrl);

            IWebElement element = driver.FindElement(By.CssSelector("navbar-brand"));
            element.Click();

            Assert.Equal(driver.Url, "http://localhost:88");

        }
        [Fact]
        public void CategoryPageNavigate_LinkText()
        {
            string HomeUrl = "http://localhost:88/";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(HomeUrl);

            IWebElement element = driver.FindElement(By.LinkText("Home"));
            element.Click();

            Assert.Equal(driver.Url, "http://localhost:88");

        }
        [Fact]
        public void CategoryPageNavigate_Element ()
        {
            string HomeUrl = "http://localhost:88/Category";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(HomeUrl);

            ReadOnlyCollection<IWebElement> element = driver.FindElements(By.TagName("td"));

            Assert.Equal("1", element[0].Text);

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
        [Fact]
        public void Category_Fill_Form()
        {
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("http://localhost:88/Category/Create");
            IWebElement CategoryID = driver.FindElement(By.Id("CategoryID"));
            Random rnd = new Random();
            int num = rnd.Next(1, 13);
            CategoryID.SendKeys(num.ToString());

            IWebElement CategoryName = driver.FindElement(By.Id("CategoryName"));
            CategoryName.SendKeys(Guid.NewGuid().ToString());

            IWebElement Description = driver.FindElement(By.Id("Description"));
            Description.SendKeys(Guid.NewGuid().ToString());

            IWebElement rbRequired = driver.FindElement(By.Id("rbRequired"));
            rbRequired.Click();

            IWebElement cbRequired = driver.FindElement(By.Id("cbRequired"));
            cbRequired.Click();

            IWebElement ddRequired = driver.FindElement(By.Id("ddRequired"));
            SelectElement elelemnt =new SelectElement(ddRequired);

            Assert.Equal("Required", elelemnt.SelectedOption.Text);

            //IWebElement dtRequired = driver.FindElement(By.Id("dtRequired"));
            //CategoryName.SendKeys(Guid.NewGuid().ToString());


        }
    }
}