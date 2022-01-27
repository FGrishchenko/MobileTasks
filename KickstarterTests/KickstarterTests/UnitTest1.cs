using androidTEst.Bases;
using KickstarterTests.Utilities;
using NUnit.Framework;

namespace KickstarterTests
{
    public class Tests : BaseTest
    {
        [Test]
        [TestCase(2)]
        public void Test1(int projectPosition)
        {
            MainScreen.State.WaitForDisplayed();
            MainScreen.SwipeLeft();
            MainScreen.IsPopularTab();

            MainScreen.SearchSecondProject(projectPosition);
            var Percent = MainScreen.GetPercent(projectPosition);
            var DaysToGo = MainScreen.GetDaysToGo(projectPosition);
            string projectName = MainScreen.GetProjectName(projectPosition);
            ProjectScreen.State.WaitForDisplayed();
            ProjectScreen.ClickBackButton();

            MainScreen.Search(projectName);

            Assert.AreEqual(projectName, MainScreen.GetProjectNameAfterSearch());
            Assert.AreEqual(DaysToGo, MainScreen.GetDaysToGoAfterSearch());
            Assert.AreEqual(Percent, MainScreen.GetPercentAfterSearch());

            MainScreen.GoToPrScreenAfterSearch();

            Assert.IsTrue(StringUtils.IsTextContains(ProjectScreen.GetProjectDisclaimer(), DateUtils.AddDaysAndReturnValidFormat(TodayDate, DaysToGo)), "");
        }
    }
}