using androidTEst.Bases;
using androidTEst.Utilities;
using androidTEst.Utils;
using NUnit.Framework;

namespace androidTEst
{
    public class Tests : BaseTest
    {
        [Test]
        public void TestCase1()
        {
            Assert.IsTrue(AllFilesScreen.State.IsExist, "Wrong screen is opened");

            AllFilesScreen.GetAllFiles();
            AllFilesScreen.AddNewFile();

            AllFilesScreen.CreateTextDocument();
            AllFilesScreen.SetFileName(TextFileName);

            Assert.AreEqual(TextFileName, AllFilesScreen.GetFileName(), "Wrong file");
            Assert.IsTrue(EditingScreen.State.WaitForDisplayed(), "Wrong screen is opened");

            EditingScreen.SetRandomText(StringUtil.GetRandomString());
            EditingScreen.CloseTextEditor();

            Assert.IsTrue(AllFilesScreen.WaitForFileDisplayed(TextFileName), "File doesn't exist");

            AllFilesScreen.DelFile(AllFilesScreen.GetPositionOfMyFile(TextFileName));
        }

        [Test]
        public void TestCase2()
        {
            Assert.IsTrue(AllFilesScreen.State.IsExist, "Wrong screen is opened");

            AllFilesScreen.GetAllFiles();
            AllFilesScreen.AddNewFile();

            AllFilesScreen.CreateTextDocument();
            AllFilesScreen.SetFileName(TextFileName);

            Assert.AreEqual(TextFileName, AllFilesScreen.GetFileName(), "Wrong file");
            Assert.IsTrue(EditingScreen.State.WaitForDisplayed(), "Wrong screen is opened");

            EditingScreen.SetRandomText(StringUtil.GetRandomString());
            EditingScreen.CloseTextEditor();

            Assert.IsTrue(AllFilesScreen.WaitForFileDisplayed(TextFileName), "File doesn't exist");

            AllFilesScreen.DelFile(AllFilesScreen.GetPositionOfMyFile(TextFileName));

            Assert.IsFalse(AllFilesScreen.IsFileExists(TextFileName), "File not deleted");

            AllFilesScreen.Swipe();

            Assert.IsFalse(AllFilesScreen.WaitForFileDisplayed(TextFileName), "File not deleted");
        }

        [Test]
        public void TestCase3()
        {
            Assert.IsTrue(AllFilesScreen.State.IsExist, "Wrong screen is opened");

            AllFilesScreen.GetAllFiles();

            Assert.IsTrue(AllFilesScreen.WaitForFileDisplayed(ConfigManager.GetSetting("FileName")), "File doesn't exist");

            AllFilesScreen.OpenFile(ConfigManager.GetSetting("FileName"));

            Assert.IsTrue(EditingScreen.State.WaitForDisplayed(), "Wrong screen is opened");
            Assert.IsTrue(EditingScreen.IsTextFieldWithSomeTextDisplayed(ConfigManager.GetSetting("SomeText")), "Invalid text in file");

            EditingScreen.CloseTextEditor();
        }

        [Test]
        public void TestCase4()
        {
            Assert.IsTrue(AllFilesScreen.State.IsExist, "Wrong screen is opened");

            AllFilesScreen.TypeAndSearchText(ConfigManager.GetSetting("SearchText"));

            Assert.IsTrue(AllFilesScreen.IsMyFileExists(ConfigManager.GetSetting("FileName"), ConfigManager.GetSetting("Format")), "File doesn't exist");
        }
    }
}