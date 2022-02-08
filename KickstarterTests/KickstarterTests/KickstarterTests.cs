using androidTEst.Bases;
using KickstarterTests.Utilities;
using NUnit.Framework;

namespace KickstarterTests
{
    public class KickstarterTests : BaseTest
    {
        [Test]
        [TestCase(2)]
        public void TestCase1(int projectPosition)
        {
            MainScreen.State.WaitForDisplayed();
            MainScreen.SwipeLeft();
            MainScreen.IsPopularTab();

            MainScreen.SearchSecondProject(projectPosition);
            var Percent = MainScreen.GetPercent(projectPosition);
            var DaysToGo = MainScreen.GetDaysToGo(projectPosition);
            string ProjectName = MainScreen.GetProjectName(projectPosition);
            ProjectScreen.State.WaitForDisplayed();
            ProjectScreen.ClickBackButton();

            MainScreen.Search(ProjectName);

            Assert.AreEqual(ProjectName, MainScreen.GetProjectNameAfterSearch(), "Wrong project name");
            Assert.AreEqual(DaysToGo, MainScreen.GetDaysToGoAfterSearch(), "Wrong days to go");
            Assert.AreEqual(Percent, MainScreen.GetPercentAfterSearch(), "Wrong percent");

            MainScreen.GoToPrScreenAfterSearch();

            Assert.IsTrue(StringUtils.IsTextContains(ProjectScreen.GetProjectDisclaimer(), DateUtils.AddDaysAndReturnValidFormat(TodayDate, DaysToGo)), "Invalid number of days");
        }
    }
}