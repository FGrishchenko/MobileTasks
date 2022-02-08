namespace KickstarterTests.Utilities
{
    public static class StringUtils
    {
        public static bool IsTextContains(string mainText, string myText)
        {
            return mainText.Contains(myText);
        }
    }
}