namespace template
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }

        public NavigationHelper OpenHomePage()
        {
            Driver.Url = BaseUrl;
            return this;
        }
    }
}