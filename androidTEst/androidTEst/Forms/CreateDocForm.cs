using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace androidTEst.Forms
{
    public class CreateDocForm : Form
    {
        // regardless of the language of the system/application, the text "текстовый документ" doesn't change. (see ./Screenshots)
        private readonly IButton CreateDocButton = (IButton)ElementFactory.GetButton(By.XPath("//android.widget.TextView[@resource-id= 'com.nextcloud.client:id/creator_name' and contains(@text, 'текстовый документ')]"), "Create Document");

        public CreateDocForm() : base(By.XPath("//android.widget.TextView[@resource-id= 'com.nextcloud.client:id/creator_name' and contains(@text, 'текстовый документ')]"), "Create Document")
        {

        }

        public void ClickToCreateDoc()
        {
            CreateDocButton.Click();    
        }
    }
}
