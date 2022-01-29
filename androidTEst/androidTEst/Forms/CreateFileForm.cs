using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace androidTEst.Forms
{
    public class CreateFileForm : Form
    {
        private readonly ITextBox FileNameTextBox = (ITextBox)ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/filename"), "File Name");
        private readonly IButton CreateButton = (IButton)ElementFactory.GetButton(By.Id("android:id/button1"), "Create");

        public CreateFileForm() : base(By.Id("android:id/button1"), "Create")
        {

        }

        public void SetFileNameAndCreateFile(string textFileName)
        {
            FileNameTextBox.ClearAndType(textFileName);
            CreateButton.Click();
        }

        public string GetFileName()
        {
            return FileNameTextBox.Text;
        }
    }
}
