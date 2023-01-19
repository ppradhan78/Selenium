namespace Selenium.MVC.SeleniumUITest.Utlity
{
    public class PageObjectModels
    {
        private readonly IWebDriver Driver;
        private const string url = "http://localhost:88/";
        private const string title = "Title";
        public PageObjectModels(IWebDriver driver)
        {
            Driver=driver;
        }
       
        public ReadOnlyCollection<IWebElement> CellReference 
        {
            get 
            {
                return Driver.FindElements(By.TagName("td"));
            }
        }
        public void NaigateTo()
        {
            Driver.Navigate().GoToUrl(url);
            EnsurePageLoaded();
        }
        public void EnsurePageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == url) && (Driver.Title == title);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL ='{Driver.Url}' Page Source : \r\n {Driver.PageSource}");
            }
        }
    }
}
