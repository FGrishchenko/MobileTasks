using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using KickstarterTests.Utilities;
using OpenQA.Selenium;

namespace KickstarterTests.Screens
{
    public class MainScreen : Screen
    {
        private readonly ILabel PercentLabel = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/percent"), "Percent");

        private readonly ILabel DeadlineCountdownLabel = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/deadline_countdown"), "Deadline Countdown");

        private readonly ILabel SubcategoryIcon = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/subcategory_icon"), "Subcategory Icon");

        private readonly ILabel PopularTabLabel = ElementFactory.GetLabel(By.XPath("//android.widget.LinearLayout[@content-desc= 'Popular' and @selected= 'true']"), "Deadline Countdown");

        private ILabel SecondPopularProjectLabel(int position) => ElementFactory.GetLabel(By.XPath($"(//android.widget.TextView[@resource-id= 'com.kickstarter.kickstarter:id/percent'])[{position}]"), "Second Popular Project");

        private ILabel DaysToGoLabel(int position) => ElementFactory.GetLabel(By.XPath($"(//android.widget.TextView[@resource-id= 'com.kickstarter.kickstarter:id/deadline_countdown'])[{position}]"), "Days To Go");

        private readonly ILabel ProjectNameLabel = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/project_name"), "Project Name");

        private readonly IButton SearchButton = ElementFactory.GetButton(By.Id("com.kickstarter.kickstarter:id/search_button"), "Search");

        private readonly ITextBox SearchTextBox = ElementFactory.GetTextBox(By.Id("com.kickstarter.kickstarter:id/search_edit_text"), "Search field");

        private readonly ILabel ProjectNameAfterSearchLabel = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/project_name_text_view"), "Project Name After Search");
        private readonly ILabel PercentAfterSearchLabel = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/search_result_percent_funded_text_view"), "Percent After Search");
        private readonly ILabel DaysToGoSearchLabel = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/search_result_deadline_countdown_text_view"), "Deadline Countdown After Search");

        public MainScreen() : base(By.Id("com.kickstarter.kickstarter:id/login_tout_button"), "Login Button")
        {

        }

        public void SwipeLeft()
        {
            try
            {
                ScrollAndSwipeUtils.SwipeWithAttemptsToTheDisplayedElement(PopularTabLabel, DeadlineCountdownLabel, PointUtils.FromPointToEdge(PercentLabel));
            }
            catch
            {
                SubcategoryIcon.TouchActions.ScrollToElement(SwipeDirection.Down);
                SwipeLeft();
            }
        }

        public bool IsPopularTab()
        {
            return PopularTabLabel.State.WaitForDisplayed();
        }

        public void SearchSecondProject(int position)
        {
            SecondPopularProjectLabel(position).TouchActions.ScrollToElement(SwipeDirection.Left);
        }

        public string GetDaysToGo(int position)
        {
            return DaysToGoLabel(position).Text;
        }

        public string GetPercent(int position)
        {
            return SecondPopularProjectLabel(position).Text;
        }

        public string GetProjectName(int position)
        {
            SecondPopularProjectLabel(position).Click();
            return ProjectNameLabel.Text;
        }

        public void Search(string prName)
        {
            SearchButton.TouchActions.ScrollToElement(SwipeDirection.Up);
            SearchButton.Click();
            SearchTextBox.ClearAndType($"{prName}\\n");
        }

        public string GetDaysToGoAfterSearch()
        {
            return DaysToGoSearchLabel.Text;
        }

        public string GetPercentAfterSearch()
        {
            return PercentAfterSearchLabel.Text;
        }

        public string GetProjectNameAfterSearch()
        {
            return ProjectNameAfterSearchLabel.Text;
        }

        public void GoToPrScreenAfterSearch()
        {
            ProjectNameAfterSearchLabel.Click();
        }
    }
}
