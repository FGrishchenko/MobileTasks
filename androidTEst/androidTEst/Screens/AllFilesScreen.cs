using androidTEst.Extension;
using androidTEst.Forms;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;
using System.Linq;

namespace Aquality.Appium.Mobile.Template.Screens.Login
{
    public class AllFilesScreen : Screen
    {
        MenuForm MenuForm;
        CreateDocForm CreateDocForm;
        CreateFileForm CreateFileForm;


        private readonly IButton AddNewFileButton = ElementFactory.GetButton(By.Id("com.nextcloud.client:id/fab_main"), "Add New File");
        private readonly IButton MenuButton = ElementFactory.GetButton(By.Id("com.nextcloud.client:id/menu_button"), "Menu");
        private readonly IButton AllFilesButton = ElementFactory.GetButton(By.Id("com.nextcloud.client:id/sort_list_button_group"), "All Files");

        private ILabel MyFile(string fileName) => ElementFactory.GetLabel(By.XPath($"//android.widget.TextView[@resource-id = 'com.nextcloud.client:id/Filename' and contains(@text, '{fileName}')]"), "My File");

        private readonly IButton DeleteButton = ElementFactory.GetButton(By.XPath("(//android.widget.LinearLayout[@resource-id='android:id/content'])[8]"), "Delete");
        private readonly IButton NextDeleteButton = ElementFactory.GetButton(By.Id("android:id/button1"), "Delete");
        private readonly ITextBox SearchTextBox = ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/search_text"), "Search");
        private readonly ITextBox ActivatedSearchTextBox = ElementFactory.GetTextBox(By.Id("com.nextcloud.client:id/search_src_text"), "Activated Search");
        private ILabel FileTitle(string fileName) => ElementFactory.GetLabel(By.XPath($"//android.widget.TextView[@resource-id= 'com.nextcloud.client:id/title' and contains(@text, '{fileName}')]"), "File Title");

        private By ListOfFilesWtihFormatLocator(string format) => By.XPath($"//android.widget.TextView[@resource-id= 'com.nextcloud.client:id/title' and contains(@text, '{format}')]");
        private readonly By ListOfFilesLocator = By.XPath("//android.widget.TextView[@resource-id='com.nextcloud.client:id/Filename']");

        public AllFilesScreen() : base(By.Id("com.nextcloud.client:id/fab_main"), "AddNewFileButt")
        {
            MenuForm = new MenuForm();
            CreateDocForm = new CreateDocForm();
            CreateFileForm = new CreateFileForm();
        }

        public void AddNewFile()
        {
            if (AddNewFileButton.State.IsClickable)
            {
                AddNewFileButton.Click();
            }
            else
            {
                MenuButton.Click();
                AllFilesButton.Click();
                AddNewFileButton.State.WaitForClickable();
                AddNewFile();
            }
        }

        public void CreateTextDocument()
        {
            CreateDocForm.ClickToCreateDoc();
        }

        public void SetFileName(string textFileName)
        {
            CreateFileForm.SetFileNameAndCreateFile(textFileName);
        }

        public string GetFileName()
        {
            return CreateFileForm.GetFileName();
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
            var files = ElementFactory.FindElements<ILabel>(ListOfFilesLocator);
            var file = files.First(fileLabel => fileLabel.Text == MyFile(fileName).Text);
            return files.IndexOf(file) + 1;
        }

        public void DelFile(int index)
        {
            MenuForm.ClickToMoreMenu(index);
            DeleteButton.Click();
            NextDeleteButton.Click();
        }

        public void Swipe()
        {
            MenuForm.SwipeToAddNewFileButton(AddNewFileButton.GetElement().Location);
        }

        public void TypeAndSearchText(string someText)
        {
            SearchTextBox.Click();
            ActivatedSearchTextBox.TypeAndSearch(someText);
        }

        public bool IsMyFileExists(string format, string fileName, int expectedNumberOfFiles = 1)
        {
            FileTitle(fileName).State.WaitForDisplayed();
            var test = ElementFactory.FindElements<ILabel>(ListOfFilesWtihFormatLocator(format));
            return test.Count == expectedNumberOfFiles;
        }
    }
}