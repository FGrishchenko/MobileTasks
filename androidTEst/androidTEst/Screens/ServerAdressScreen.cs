using androidTEst.Extension;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace androidTEst.Screens
{
    public class ServerAdressScreen : Screen
    {
        private readonly ITextBox ServerAdress = ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/host_url_input"), "ServerAdress");
        public ServerAdressScreen() : base(By.Id("com.nextcloud.client:id/scan_qr"), "LoginQRCode")
        {

        }

        public void EnterServerAdress(string serverAdress)
        {
            ServerAdress.TypeAndSearch(serverAdress);
        }

    }
}
