using Aquality.Appium.Mobile.Applications;
using KickstarterTests.Screens;
using NUnit.Framework;

namespace androidTEst.Bases
{
    public abstract class BaseTest
    {
        private static IMobileApplication App;

        protected static MainScreen MainScreen = new MainScreen();

        [SetUp]
        public void Setup()
        {
            App = AqualityServices.Application;
        }

        [TearDown]
        public void TearDown()
        {
           // App.Quit();
        }
    }
}
