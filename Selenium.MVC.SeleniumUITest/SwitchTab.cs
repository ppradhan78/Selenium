using Selenium.MVC.SeleniumUITest.Utlity;
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
    public class SwitchTab : IClassFixture<WebDriverFixture>
    {
        WebDriverFixture _webDriverFixture;
        public SwitchTab(WebDriverFixture webDriverFixture)
        {
            _webDriverFixture = webDriverFixture;
        }

        [Fact]
        public void Category_Tab()
        {
            string Home = "http://localhost:88/";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(Home);
            new PageObjectModels(driver).NaigateTo();
            driver.FindElement(By.Id("Category")).Click();

            ReadOnlyCollection<string> allTab = driver.WindowHandles;
            string homeTab = allTab[0];
            Thread.Sleep(5000);
            driver.SwitchTo().Window(homeTab);
        }

        [Fact]
        public void Category_Alert()
        {
            string Home = "http://localhost:88/Category";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(Home);
            driver.FindElement(By.Id("myModalContent")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            Assert.Equal("Sample alter message", alert.Text);
            Thread.Sleep(5000);
            alert.Accept();
        }
        [Fact]
        public void Category_Conform()
        {
            string Home = "http://localhost:88/Category";
            var driver = _webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(Home);
            driver.FindElement(By.Id("btnConform")).Click();

            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IAlert alert = driver.SwitchTo().Alert();
            //alert.Dismiss();
            alert.Accept();
        }
    }
}