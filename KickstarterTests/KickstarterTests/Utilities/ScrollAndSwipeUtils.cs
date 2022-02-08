using Aquality.Appium.Mobile.Elements.Interfaces;
using System.Drawing;

namespace KickstarterTests.Utilities
{
    public static class ScrollAndSwipeUtils
    {
        public static void SwipeWithAttemptsToTheDisplayedElement(ILabel label1, ILabel labelForSwipe, Point endPoint, int attempts = 15)
        {
            while (attempts != 0)
            {
                if (label1.State.IsDisplayed)
                {
                    break;
                }
                else
                {
                    labelForSwipe.TouchActions.Swipe(endPoint);
                    attempts--;
                }
            }
        }
    }
}
