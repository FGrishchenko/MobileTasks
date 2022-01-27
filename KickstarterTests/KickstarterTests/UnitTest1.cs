using androidTEst.Bases;
using KickstarterTests.Utilities;
using NUnit.Framework;
using System;
using System.Globalization;

namespace KickstarterTests
{
    public class Tests : BaseTest
    {
        [Test]
        [TestCase(2)]
        public void Test1(int projectPosition)
        {
            Assert.IsTrue(MainScreen.State.IsDisplayed, "Wrong screen is opened");

            MainScreen.SwipeLeft();

            Assert.IsTrue(MainScreen.IsPopularTab(), "Wrong tab is opened");

            MainScreen.SearchSecondProject(projectPosition);
            var Percent = MainScreen.GetPercent(projectPosition);
            var DaysToGo = MainScreen.GetDaysToGo(projectPosition);
            string projectName = MainScreen.GetProjectName(projectPosition);
            ProjectScreen.State.WaitForDisplayed();
            ProjectScreen.BackToMainScreen();

            MainScreen.Search(projectName);

            Assert.AreEqual(projectName, MainScreen.GetProjectNameAfterSearch());
            Assert.AreEqual(Percent, MainScreen.GetPercentAfterSearch());
            Assert.AreEqual(DaysToGo, MainScreen.GetDaysToGoAfterSearch());

            MainScreen.GoToPrScreenAfterSearch();


            DateTime now = DateTime.Now;
            var erwuerer = now.AddDays(double.Parse(DaysToGo));
            var test = erwuerer.ToString("MMM dd, yyyy", CultureInfo.GetCultureInfo("en-en"));

            Assert.IsTrue(StringUtils.IsTextContains(ProjectScreen.GetProjectDisclaimer(), test), "");
        }
    }
}