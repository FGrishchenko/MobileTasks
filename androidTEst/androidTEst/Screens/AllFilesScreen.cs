using androidTEst.Extension;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Template.Screens.Login
{
    public class AllFilesScreen : Screen
    {
        private readonly IButton AddNewFileButt = ElementFactory.GetButton(By.Id("com.nextcloud.client:id/fab_main"), "AddNewFileButt");
        private readonly IButton MenuButt = ElementFactory.GetButton(By.Id("com.nextcloud.client:id/menu_button"), "MenuButt");
        private readonly IButton AllFilesButt = ElementFactory.GetButton(By.Id("com.nextcloud.client:id/sort_list_button_group"), "AllFilesButt");

        // regardless of the language of the system/application, the text "текстовый документ" doesn't change. (see ./Screenshots)
        private readonly IButton CreateDoc = ElementFactory.GetButton(By.XPath("//android.widget.TextView[@resource-id= 'com.nextcloud.client:id/creator_name' and contains(@text, 'текстовый документ')]"), "CreateDoc");
        private readonly ITextBox TextFileName = ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/filename"), "TextFileName");
        private readonly IButton CreateButton = ElementFactory.GetButton(By.Id("android:id/button1"), "CreateButton");
        private ILabel MyFile(string fileName) => ElementFactory.GetLabel(By.XPath($"//android.widget.TextView[@resource-id = 'com.nextcloud.client:id/Filename' and contains(@text, '{fileName}')]"), "MyFile");
        private readonly By ListOfFiles = By.XPath("//android.widget.TextView[@resource-id='com.nextcloud.client:id/Filename']");
        private IButton MoreMemu(int index) => ElementFactory.GetButton(By.XPath($"(//android.widget.ImageView[@resource-id='com.nextcloud.client:id/overflow_menu'])[{index}]"), "MoreMemu");
        private IButton MoreMemuButt = ElementFactory.GetButton(By.XPath("//android.widget.ImageView[@resource-id='com.nextcloud.client:id/overflow_menu']"), "MoreMemuButt");
        private readonly IButton DelButton = ElementFactory.GetButton(By.XPath("(//android.widget.LinearLayout[@resource-id='android:id/content'])[8]"), "DelButton");
        private readonly IButton SecondDelButton = ElementFactory.GetButton(By.Id("android:id/button1"), "SecondDelButton");
        private readonly ITextBox Search = ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/search_text"), "Search");
        private readonly ITextBox SearchTextBox = ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/search_src_text"), "SearchTextBox");
        private ILabel FileTitle(string fileName) => ElementFactory.GetLabel(By.XPath($"//android.widget.TextView[@resource-id= 'com.nextcloud.client:id/title' and contains(@text, '{fileName}')]"), "FileTitle");
        private By ListOfFilesWtihFormat(string format) => By.XPath($"//android.widget.TextView[@resource-id= 'com.nextcloud.client:id/title' and contains(@text, '{format}')]");

        public AllFilesScreen() : base(By.Id("com.nextcloud.client:id/fab_main"), "AddNewFileButt")
        {

        }

        public void GetAllFiles()
        {
            MenuButt.Click();
            AllFilesButt.Click();
        }

        public void AddNewFile()
        {
            AddNewFileButt.State.WaitForClickable();
            AddNewFileButt.Click();
        }

        public void CreateTextDocument()
        {
            CreateDoc.Click();
        }

        public void SetFileName(string textFileName)
        {
            TextFileName.ClearAndType(textFileName);
            CreateButton.Click();
        }

        public string GetFileName()
        {
            return TextFileName.Text;
        }

        public bool WaitForFileDisplayed(string fileName)
        {
            return MyFile(fileName).State.WaitForDisplayed();
        }

        public void OpenFile(string fileName)
        {
            MyFile(fileName).Click();
        }

        public bool IsFileExists(string fileName)
        {
            return MyFile(fileName).State.IsDisplayed;
        }

        public int GetPositionOfMyFile(string fileName)
        {
            var files = ElementFactory.FindElements<ILabel>(ListOfFiles);
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].Text == MyFile(fileName).Text)
                {
                    return files.IndexOf(files[i]) + 1;
                }
            }
            return -1;
        }

        public void DelFile(int index)
        {
            MoreMemu(index).Click();
            DelButton.Click();
            SecondDelButton.Click();
        }

        public void Swipe()
        {
            var locationAddNewFileButt = AddNewFileButt.GetElement().Location;
            MoreMemuButt.TouchActions.Swipe(locationAddNewFileButt);
        }

        public void TypeAndSearchText(string someText)
        {
            Search.Click();
            SearchTextBox.TypeAndSearch(someText);
        }

        public bool IsMyFileExists(string format, string fileName, int expectedNumberOfFiles = 1)
        {
            FileTitle(fileName).State.WaitForDisplayed();
            var test = ElementFactory.FindElements<ILabel>(ListOfFilesWtihFormat(format));
            return test.Count == expectedNumberOfFiles;
        }
    }
}