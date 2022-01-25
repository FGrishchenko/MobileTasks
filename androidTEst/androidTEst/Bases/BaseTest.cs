using androidTEst.Screens;
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
        protected static StartScreen StartScreen = new StartScreen();
        protected static ServerAdressScreen ServerAdressScreen = new ServerAdressScreen();
        protected static ConnectScreen ConnectScreen = new ConnectScreen();
        protected static LoginScreen LoginScreen = new LoginScreen();
        protected static AlertScreen AlertScreen = new AlertScreen();
        protected static SettingsScreen SettingsScreen = new SettingsScreen();

        protected string TextFileName = $"{StringUtil.GetRandomString()}.md";

        [SetUp]
        public void Setup()
        {
            App = AqualityServices.Application;
        }

        [OneTimeSetUp]
        public void Test()
        {
            StartScreen.State.WaitForDisplayed();
            StartScreen.ClickToLogButt();
            ServerAdressScreen.State.WaitForDisplayed();
            ServerAdressScreen.EnterServerAdress("https://sam.nl.tab.digital/");
            ConnectScreen.State.WaitForDisplayed();
            ConnectScreen.Login();
            LoginScreen.State.WaitForDisplayed();
            LoginScreen.SetLoginOrPassword("user", "testzxc993@gmail.com");
            LoginScreen.SetLoginOrPassword("password", "993322qwezxc");
            LoginScreen.Submit();
            ConnectScreen.LoginWithWait();
            AlertScreen.State.WaitForDisplayed();
            AlertScreen.GoToSettings();
            SettingsScreen.State.WaitForDisplayed();
            SettingsScreen.AllowAccessAndClose();
        }

        [TearDown]
        public void TearDown()
        {
           // App.Quit();
        }
    }
}
