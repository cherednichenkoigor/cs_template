using OpenQA.Selenium;

namespace template
{
    public class HelperBase
    {
        protected string BaseUrl = Properties.Settings.Default.baseUrl;
        protected ApplicationManager Manager;
        protected IWebDriver Driver;

        public HelperBase(ApplicationManager manager)
        {
            Manager = manager;
            Driver = manager.Driver;
        }
    }
}
