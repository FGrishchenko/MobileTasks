using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class StartScreen : Screen
    {
        private readonly IButton LoginButton = ElementFactory.GetButton(By.Id("com.nextcloud.client:id/login"), "Login");

        public StartScreen() : base(By.Id("com.nextcloud.client:id/login"), "Login")
        {

        }

        public void ClickToLoginButton()
        {
            LoginButton.Click();
        }
    }
}