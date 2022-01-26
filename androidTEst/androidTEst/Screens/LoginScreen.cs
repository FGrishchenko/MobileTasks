using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class LoginScreen : Screen
    {
        private ITextBox PassOrLoginTextBox(string resourceId) => ElementFactory.GetTextBox(By.XPath($"//android.widget.EditText[@resource-id= '{resourceId}']"), "PassOrLoginTextBox");
        private readonly IButton SubmitButt = ElementFactory.GetButton(By.XPath("//android.widget.Button[@resource-id= 'submit-form']"), "SubmitButt");

        public LoginScreen() : base(By.XPath("//android.widget.Button[@resource-id= 'submit-form']"), "submitButt")
        {

        }

        public void SetLoginOrPassword(string resourceId, string login)
        {
            PassOrLoginTextBox(resourceId).ClearAndType(login);
        }

        public void Submit()
        {
            SubmitButt.Click();
        }
    }
}