using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class AlertScreen : Screen
    {
        private readonly IButton OKButton = ElementFactory.GetButton(By.XPath("//android.widget.Button[@resource-id= 'android:id/button1']"), "OKButton");

        public AlertScreen() : base(By.XPath("//android.widget.Button[@resource-id= 'android:id/button1']"), "OK butt")
        {

        }

        public void GoToSettings()
        {
            OKButton.Click();
        }
    }
}
