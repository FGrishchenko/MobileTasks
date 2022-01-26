using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class SettingsScreen : Screen
    {
        private readonly IButton SwitchButt = ElementFactory.GetButton(By.XPath("//android.widget.Switch[@resource-id= 'android:id/switch_widget']"), "SwitchButt");
        private readonly IButton BackButt = ElementFactory.GetButton(By.XPath("//android.widget.ImageButton"), "BackButt");

        public SettingsScreen() : base(By.XPath("//android.widget.Switch[@resource-id= 'android:id/switch_widget']"), "SwitchButt")
        {

        }

        public void AllowAccessAndClose()
        {
            SwitchButt.Click();
            BackButt.Click();
        }
    }
}