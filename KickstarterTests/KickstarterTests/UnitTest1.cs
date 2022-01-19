using androidTEst.Bases;
using NUnit.Framework;

namespace KickstarterTests
{
    public class Tests : BaseTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(MainScreen.State.IsDisplayed, "Wrong page is opened");

            MainScreen.SwipeRight();

            Assert.IsTrue(MainScreen.testMethod());
        }
    }
}