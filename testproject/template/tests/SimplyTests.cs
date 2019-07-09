using NUnit.Framework;

namespace template
{
    class SimplyTests : TestBase
    {
        [Test, Category("SimplyTests")]
        public void OpenPageTest()
        {
            app.Navigation.OpenHomePage();
        }
    }
}
