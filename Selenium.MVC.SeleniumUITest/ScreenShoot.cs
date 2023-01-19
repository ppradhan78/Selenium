namespace Selenium.MVC.SeleniumUITest
{
   
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