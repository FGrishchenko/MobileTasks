using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace KickstarterTests.Screens
{
    public class MainScreen : Screen
    {
        private readonly ILabel Percent = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/percent"), "Percent");

        private readonly ILabel DeadlineCountdown = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/deadline_countdown"), "DeadlineCountdown");

        private readonly ILabel TestTexView = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/pwl_text_view"), "DeadlineCountdown");

        private readonly ILabel log = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/login_tout_button"), "DeadlineCountdown");

        private readonly ILabel Popular = ElementFactory.GetLabel(By.XPath("//android.widget.LinearLayout[@content-desc= 'Popular' and @selected= 'true']"), "DeadlineCountdown");



        public MainScreen() : base(By.Id("com.kickstarter.kickstarter:id/login_tout_button"), "LogButton")
        {

        }

        public void SwipeRight()
        {
            TestTexView.TouchActions.ScrollToElement(Aquality.Appium.Mobile.Actions.SwipeDirection.Left);

            var test = Percent.GetElement().Location;

            int atte = 20;
            while (atte != 0)
            {
                if (log.State.IsDisplayed)
                {
                    DeadlineCountdown.TouchActions.Swipe(test);
                    atte--;
                }
                else
                {
                    break;
                }
            }
        }

        public bool testMethod()
        {
            return Popular.State.WaitForDisplayed();
        }
    }
}
