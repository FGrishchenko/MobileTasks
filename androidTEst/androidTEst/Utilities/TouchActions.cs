using Aquality.Appium.Mobile.Elements.Interfaces;
using System.Drawing;

namespace androidTEst.Utilities
{
    public static class TouchActions
    {
        public static void SwipeActions(IElement startElement, Point endPoint)
        {
            startElement.TouchActions.Swipe(endPoint);
        }
    }
}
