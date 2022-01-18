using androidTEst.Utils;
using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Template.Screens.Login;
using NUnit.Framework;

namespace androidTEst.Bases
{
    public abstract class BaseTest
    {
        protected static IMobileApplication App;

        protected static AllFilesScreen AllFilesScreen = new AllFilesScreen();
        protected static EditingScreen EditingScreen = new EditingScreen();

        protected string TextFileName = $"{StringUtil.GetRandomString()}.md";

        [SetUp]
        public void Setup()
        {
            App = AqualityServices.Application;
        }

        [TearDown]
        public void TearDown()
        {
            App.Quit();
        }
    }
}
