using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class SettingsScreen : Screen
    {
        private readonly IButton SwitchButton = ElementFactory.GetButton(By.XPath("//android.widget.Switch[@resource-id= 'android:id/switch_widget']"), "Switch Butt");
        private readonly IButton BackButton = ElementFactory.GetButton(By.XPath("//android.widget.ImageButton"), "Back");

        public SettingsScreen() : base(By.XPath("//android.widget.Switch[@resource-id= 'android:id/switch_widget']"), "Switch")
        {

        }

        public void AllowAccessAndClose()
        {
            SwitchButton.Click();
            BackButton.Click();
        }
    }
}