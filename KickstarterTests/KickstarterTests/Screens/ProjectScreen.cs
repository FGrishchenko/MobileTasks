using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace KickstarterTests.Screens
{
    public class ProjectScreen : Screen
    {
        private readonly IButton BackButton = ElementFactory.GetButton(By.XPath("//android.widget.Button[@resource-id= 'com.kickstarter.kickstarter:id/back_icon']"), "Back");

        private readonly ILabel ProjectDisclaimerLabel = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/project_disclaimer_text_view"), "Project Disclaimer");

        public ProjectScreen() : base(By.XPath("//android.widget.ImageButton[@resource-id= 'com.kickstarter.kickstarter:id/heart_icon']"), "Project Screen")
        {

        }

        public void ClickBackButton()
        {
            BackButton.Click();
        }

        public string GetProjectDisclaimer()
        {
            ProjectDisclaimerLabel.TouchActions.ScrollToElement(SwipeDirection.Down);
            return ProjectDisclaimerLabel.Text;
        }
    }
}
