using OpenQA.Selenium;

namespace cmsshop.Pages
{
    public class BasePage : IPage
    {
        public IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
