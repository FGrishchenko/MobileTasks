using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst
{
    public class EditingScreen : Screen
    {
        private readonly ITextBox EditTextBox = ElementFactory.GetTextBox(By.XPath("//android.widget.EditText"), "Edit Text");
        private readonly IButton CloseButton = ElementFactory.GetButton(By.XPath("//android.widget.Button[@index= 3]"), "Close");
        private ILabel TextFieldWithSomeText(string text) => ElementFactory.GetLabel(By.XPath($"//android.widget.EditText[contains(@text, '{text}')]"), "Text");

        public EditingScreen() : base(By.XPath("//android.widget.Spinner"), "editTextField")
        {

        }

        public void SetRandomText(string rndStr)
        {
            EditTextBox.ClearAndType(rndStr);
        }

        public void CloseTextEditor()
        {
            CloseButton.Click();
        }

        public bool IsTextFieldWithSomeTextDisplayed(string text)
        {
            return TextFieldWithSomeText(text).State.IsDisplayed;
        }
    }
}
