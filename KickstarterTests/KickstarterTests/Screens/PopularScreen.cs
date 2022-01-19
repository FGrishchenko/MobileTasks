using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace KickstarterTests.Screens
{
    public class PopularScreen : Screen
    {

        public PopularScreen() : base(By.XPath("//android.widget.LinearLayout[@content-desc= 'Popular' and @selected= 'true']"), "PopularScreen")
        {

        }
    }
}
