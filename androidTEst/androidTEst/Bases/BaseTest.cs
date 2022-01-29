using androidTEst.Models;
using androidTEst.Screens;
using androidTEst.Utilities;
using androidTEst.Utils;
using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Template.Screens.Login;
using NUnit.Framework;

namespace androidTEst.Bases
{
    public abstract class BaseTest
    {
        protected static IMobileApplication? App;

        protected static TestData ReadData = DeserializationData.ReadDataFromFile<TestData>(ConfigManager.GetSetting("AccountDataFile"));

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
        public void OneTimeSetUp()
        {
            if (StartScreen.State.WaitForDisplayed())
            {
                StartScreen.ClickToLoginButton();
                ServerAdressScreen.State.WaitForDisplayed();
                ServerAdressScreen.EnterServerAdress(ReadData.AccountData.ServerAdress);
                ConnectScreen.State.WaitForDisplayed();
                ConnectScreen.Login();
                LoginScreen.State.WaitForDisplayed();
                LoginScreen.SetLogin(ReadData.AccountData.Login);
                LoginScreen.SetPassword(ReadData.AccountData.Password);
                LoginScreen.ClickSubmitButton();
                ConnectScreen.LoginWithWait();
                AlertScreen.State.WaitForDisplayed();
                AlertScreen.ClickOkButton();
                SettingsScreen.State.WaitForDisplayed();
                SettingsScreen.AllowAccessAndClose();
            }
        }

        [TearDown]
        public void TearDown()
        {
            App?.Quit();
        }
    }
}
