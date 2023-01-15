using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.MVC.SeleniumUITest
{
    public class WebDriverFixture : IDisposable
    {
        public  ChromeDriver ChromeDriver { get; private set; }
        public WebDriverFixture()
        {
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver = new ChromeDriver();
        }
        public void Dispose()
        {
           // ChromeDriver.Quit();
           // ChromeDriver.Dispose();
        }
    }
}
