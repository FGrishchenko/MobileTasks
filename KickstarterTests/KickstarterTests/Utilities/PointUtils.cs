using Aquality.Appium.Mobile.Elements.Interfaces;
using System.Drawing;

namespace KickstarterTests.Utilities
{
    public static class PointUtils
    {
        public static Point FromPointToEdge(ILabel label)
        {
            return new Point(label.GetElement().Location.X - label.GetElement().Location.X, label.GetElement().Location.Y);
        }
    }
}
