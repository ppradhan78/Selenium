namespace Selenium.MVC.SeleniumUITest
{
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