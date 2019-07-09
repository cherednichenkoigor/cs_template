using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace template
{
    public class ApplicationManager
    {
        private static readonly ThreadLocal<ApplicationManager> ThreadApp = new ThreadLocal<ApplicationManager>();
        private string browser;
        private IWebDriver driver;
        public IWebDriver Driver { get => driver ?? (driver = GetDriver()); }
        private NavigationHelper navigationHelper;
        public NavigationHelper Navigation { get => navigationHelper ?? (navigationHelper = new NavigationHelper(this)); }
        private LoginHelper LoginHelper;
        public LoginHelper Auth { get => LoginHelper ?? (LoginHelper = new LoginHelper(this)); }
        private ApplicationManager(string browser)
        {
            this.browser = browser;
        }

        ~ApplicationManager()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        internal static ApplicationManager GetInstance(string browser)
        {
            return ThreadApp.IsValueCreated ? ThreadApp.Value : ThreadApp.Value = new ApplicationManager(browser);

        }

        private IWebDriver GetDriver()
        {
            switch (this.browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Properties.Settings.Default.implicitWaitInSecond);
            return driver;
        }
    }
}
