using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class LoginScreen : Screen
    {
        private ITextBox LoginTextBox = ElementFactory.GetTextBox(By.XPath($"//android.widget.EditText[@resource-id= 'user']"), "Login");
        private ITextBox PasswordTextBox = ElementFactory.GetTextBox(By.XPath($"//android.widget.EditText[@resource-id= 'password']"), "Password");
        private readonly IButton SubmitButton = ElementFactory.GetButton(By.XPath("//android.widget.Button[@resource-id= 'submit-form']"), "Submit");

        public LoginScreen() : base(By.XPath("//android.widget.Button[@resource-id= 'submit-form']"), "Submit Button")
        {

        }

        public void SetLogin(string login)
        {
            LoginTextBox.ClearAndType(login);
        }

        public void SetPassword(string password)
        {
            PasswordTextBox.ClearAndType(password);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }
    }
}