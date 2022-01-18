using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst
{
    public class EditingScreen : Screen
    {
        private readonly ITextBox EditTextField = ElementFactory.GetTextBox(By.XPath("//android.widget.EditText"), "editTextField");

        private readonly IButton CloseButt = ElementFactory.GetButton(By.XPath("//android.widget.Button[@index= 3]"), "closeButton");

        private ILabel TextFieldWithSomeText(string text) => ElementFactory.GetLabel(By.XPath($"//android.widget.EditText[contains(@text, '{text}')]"), "TextFieldWithSomeText");

        public EditingScreen() : base(By.XPath("//android.widget.Spinner"), "editTextField")
        {

        }

        public void SetRandomText(string rndStr)
        {
            EditTextField.ClearAndType(rndStr);
        }

        public void CloseTextEditor()
        {
            CloseButt.Click();
        }

        public bool IsTextFieldWithSomeTextDisplayed(string text)
        {
            return TextFieldWithSomeText(text).State.IsDisplayed;
        }
    }
}
