using Aquality.Appium.Mobile.Elements.Interfaces;

namespace androidTEst.Extension
{
    public static class TextBoxExtension
    {
        public static void TypeAndSearch(this ITextBox textBox, string text)
        {
            textBox.ClearAndType($"{text}\\n");
        }
    }
}
