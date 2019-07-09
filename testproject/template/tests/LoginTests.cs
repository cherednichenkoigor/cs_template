using NUnit.Framework;

namespace template
{
    public class LoginTests : TestBase
    {
        [Test, Category("LoginTests")]
        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData(Properties.Settings.Default.username, Properties.Settings.Default.password);

            app.Navigation.OpenHomePage();
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test, Category("LoginTests")]
        public void LoginWithInInValidCredentials()
        {
            AccountData account = new AccountData(Properties.Settings.Default.username, "invalid password");

            app.Navigation.OpenHomePage();
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn());
            StringAssert.AreEqualIgnoringCase("This account doesn’t exist, try a different email/password or use ‘forgotten password’", app.Auth.LoginWarningMessage());
        }
    }
}
