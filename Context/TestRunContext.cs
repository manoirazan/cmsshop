using System.Drawing;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace cmsshop.Context
{
    [Binding]
    public class TestRunContext
    {
        private string CMS_URL = "https://cms.demo.katalon.com/";

        public IWebDriver Driver { get; private set; }

        public TestRunContext()
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            GetWebDriver();
        }

        [AfterScenario]
        public void TearDown()
        {
            ShutdownDriver();
        }

        private void GetWebDriver()
        {
            Size _desktopWindowSize = new(1920, 1080);

            if (Driver == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                var options = GetChromeOptions();
                var service = ChromeDriverService.CreateDefaultService();
                Driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
                Driver.Manage().Window.Size = _desktopWindowSize;
            }
        }

        private ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            return options;
        }

        public void NavigateToPage(string page)
        {
            Driver.Navigate().GoToUrl(CMS_URL + page);
        }

        public void NavigateToHome()
        {
            Driver.Navigate().GoToUrl(CMS_URL);
        }

        private void ShutdownDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                Driver = null;
            }
        }
    }
}
