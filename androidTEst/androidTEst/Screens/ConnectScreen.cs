using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class ConnectScreen : Screen
    {
        private readonly IButton LogButt = ElementFactory.GetButton(By.XPath("//android.widget.Button"), "LogButt");
        private readonly IButton SubmitWrapper = ElementFactory.GetButton(By.XPath("//android.view.View[@resource-id= 'submit-wrapper' and @index= 0]"), "SubmitWrapper");

        public ConnectScreen() : base(By.XPath("//android.view.View[@resource-id= 'redirect-link']"), "ConnectScreen")
        {

        }

        public void Login()
        {
            LogButt.Click();
        }

        public void LoginWithWait()
        {
            SubmitWrapper.State.WaitForDisplayed();
            LogButt.Click();
        }
    }
}