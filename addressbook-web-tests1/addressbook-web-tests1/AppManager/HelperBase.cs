using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        public IWebDriver driver;

        public HelperBase (IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}