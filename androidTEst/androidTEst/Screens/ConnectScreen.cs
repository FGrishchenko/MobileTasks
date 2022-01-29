using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class ConnectScreen : Screen
    {
        private readonly IButton LoginButton = ElementFactory.GetButton(By.XPath("//android.widget.Button"), "Login");
        private readonly IButton SubmitWrapperButton = ElementFactory.GetButton(By.XPath("//android.view.View[@resource-id= 'submit-wrapper' and @index= 0]"), "Submit Wrapper");

        public ConnectScreen() : base(By.XPath("//android.view.View[@resource-id= 'redirect-link']"), "ConnectScreen")
        {

        }

        public void Login()
        {
            LoginButton.Click();
        }

        public void LoginWithWait()
        {
            SubmitWrapperButton.State.WaitForDisplayed();
            LoginButton.Click();
        }
    }
}