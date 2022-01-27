using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using KickstarterTests.Utilities;
using OpenQA.Selenium;

namespace KickstarterTests.Screens
{
    public class MainScreen : Screen
    {
        private readonly ILabel Percent = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/percent"), "Percent");

        private readonly ILabel DeadlineCountdown = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/deadline_countdown"), "DeadlineCountdown");

        private readonly ILabel SubcategoryIcon = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/subcategory_icon"), "SubcategoryIcon");

        private readonly ILabel Popular = ElementFactory.GetLabel(By.XPath("//android.widget.LinearLayout[@content-desc= 'Popular' and @selected= 'true']"), "DeadlineCountdown");

        private ILabel SecondPopularProject(int position) => ElementFactory.GetLabel(By.XPath($"(//android.widget.TextView[@resource-id= 'com.kickstarter.kickstarter:id/percent'])[{position}]"), "SecondPopularProject");

        private ILabel DaysToGo(int position) => ElementFactory.GetLabel(By.XPath($"(//android.widget.TextView[@resource-id= 'com.kickstarter.kickstarter:id/deadline_countdown'])[{position}]"), "DaysToGo");

        private readonly ILabel ProjectName = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/project_name"), "ProjectName");

        private readonly IButton SearchButt = ElementFactory.GetButton(By.Id("com.kickstarter.kickstarter:id/search_button"), "SearchButt");

        private readonly ITextBox SearchTextBox = ElementFactory.GetTextBox(By.Id("com.kickstarter.kickstarter:id/search_edit_text"), "SearchTextBox");

        private readonly ILabel ProjectNameAfterSearch = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/project_name_text_view"), "ProjectNameAfterSearch");
        private readonly ILabel PercentAfterSearch = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/search_result_percent_funded_text_view"), "PercentAfterSearch");
        private readonly ILabel DaysToGoSearch = ElementFactory.GetLabel(By.Id("com.kickstarter.kickstarter:id/search_result_deadline_countdown_text_view"), "DeadlineCountdownAfterSearch");

        public MainScreen() : base(By.Id("com.kickstarter.kickstarter:id/login_tout_button"), "LogButton")
        {

        }

        public void SwipeLeft()
        {
            try
            {
                ScrollAndSwipeUtils.SwipeWithAttemptsToTheDisplayedElement(Popular, DeadlineCountdown, PointUtils.FromPointToEdge(Percent));
            }
            catch
            {
                SubcategoryIcon.TouchActions.ScrollToElement(SwipeDirection.Down);
                SwipeLeft();
            }
        }

        public bool IsPopularTab()
        {
            return Popular.State.WaitForDisplayed();
        }

        public void SearchSecondProject(int position)
        {
            SecondPopularProject(position).TouchActions.ScrollToElement(SwipeDirection.Left);
        }

        public string GetDaysToGo(int position)
        {
            return DaysToGo(position).Text;
        }

        public string GetPercent(int position)
        {
            return SecondPopularProject(position).Text;
        }

        public string GetProjectName(int position)
        {
            SecondPopularProject(position).Click();
            return ProjectName.Text;
        }

        public void Search(string prName)
        {
            SearchButt.TouchActions.ScrollToElement(SwipeDirection.Up);
            SearchButt.Click();
            SearchTextBox.ClearAndType($"{prName}\\n");
        }

        public string GetDaysToGoAfterSearch()
        {
            return DaysToGoSearch.Text;
        }

        public string GetPercentAfterSearch()
        {
            return PercentAfterSearch.Text;
        }

        public string GetProjectNameAfterSearch()
        {
            return ProjectNameAfterSearch.Text;
        }

        public void GoToPrScreenAfterSearch()
        {
            ProjectNameAfterSearch.Click();
        }
    }
}
