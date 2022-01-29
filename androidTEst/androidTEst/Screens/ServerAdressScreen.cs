using androidTEst.Extension;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class ServerAdressScreen : Screen
    {
        private readonly ITextBox ServerAdressTextBox = ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/host_url_input"), "Server Adress");

        public ServerAdressScreen() : base(By.Id("com.nextcloud.client:id/scan_qr"), "LoginQRCode")
        {

        }

        public void EnterServerAdress(string serverAdress)
        {
            ServerAdressTextBox.TypeAndSearch(serverAdress);
        }
    }
}
