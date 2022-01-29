using androidTEst.Utilities;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Drawing;

namespace androidTEst.Forms
{
    public class MenuForm : Form
    {
        private IButton MoreMemuButtonWithIndex(int index) => (IButton)ElementFactory.GetButton(By.XPath($"(//android.widget.ImageView[@resource-id='com.nextcloud.client:id/overflow_menu'])[{index}]"), "More Memu");
        private IElement MoreMemuButton = (IButton)ElementFactory.GetButton(By.XPath("//android.widget.ImageView[@resource-id='com.nextcloud.client:id/overflow_menu']"), "More Memu");

        public MenuForm() : base(By.XPath("//android.widget.ImageView[@resource-id='com.nextcloud.client:id/overflow_menu']"), "More Memu")
        {

        }

        public void ClickToMoreMenu(int index)
        {
            MoreMemuButtonWithIndex(index).Click();
        }

        public void SwipeToAddNewFileButton(Point locationAddNewFileButt)
        {
            TouchActions.SwipeActions(MoreMemuButton, locationAddNewFileButt);
        }
    }
}
