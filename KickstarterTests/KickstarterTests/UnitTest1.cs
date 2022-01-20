using androidTEst.Bases;
using NUnit.Framework;

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
            string projectName = MainScreen.GetProjectName(projectPosition);

        }
    }
}