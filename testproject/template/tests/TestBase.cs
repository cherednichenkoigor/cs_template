using NUnit.Framework;

namespace template
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance(TestContext.Parameters.Get("Browser") ?? "chrome");
        }
    }
}
