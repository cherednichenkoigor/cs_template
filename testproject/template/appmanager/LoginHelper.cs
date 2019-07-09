using OpenQA.Selenium;

namespace template
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)  { }

        public LoginHelper Login(AccountData account)
        {
            By userInput = By.CssSelector("input[name=email]");
            Driver.FindElement(userInput).Clear();
            Driver.FindElement(userInput).SendKeys(account.Username);

            By passwordInput = By.CssSelector("input[name=password]");
            Driver.FindElement(passwordInput).Clear();
            Driver.FindElement(passwordInput).SendKeys(account.Password);

            By loginButton = By.CssSelector("button.ladda-button");
            Driver.FindElement(loginButton).Click();   

            return this;
        }

        public bool IsLoggedIn()
        {
            By accountDropdown = By.CssSelector("#account-dropdown");
            return Driver.FindElements(accountDropdown).Count > 0;
        }

        public string LoginWarningMessage()
        {
            By loginWarning = By.CssSelector(".text-danger");
            if (Driver.FindElements(loginWarning).Count > 0)
            {
                return Driver.FindElement(loginWarning).Text;
            }
            return null;
        }
    }
}