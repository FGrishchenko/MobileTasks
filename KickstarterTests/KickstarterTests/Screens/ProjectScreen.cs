using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace KickstarterTests.Screens
{
    public class ProjectScreen : Screen
    {
        private readonly IButton BackButt = ElementFactory.GetButton(By.XPath("//android.widget.Button[@resource-id= 'com.kickstarter.kickstarter:id/back_icon']"), "BackButt");

        private readonly ILabel ProjectDisclaimer = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/project_disclaimer_text_view"), "ProjectDisclaimer");

        public ProjectScreen() : base(By.XPath("//android.widget.ImageButton[@resource-id= 'com.kickstarter.kickstarter:id/heart_icon']"), "ProjectScreen")
        {

        }

        public void BackToMainScreen()
        {
            BackButt.Click();
        }

        public string GetProjectDisclaimer()
        {
            ProjectDisclaimer.TouchActions.ScrollToElement(SwipeDirection.Down);
            return ProjectDisclaimer.Text;
        }
    }
}
