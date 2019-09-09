using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DoctorWeb.Utility;
using NUnit.Framework;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class AdditinalFields_Page
    {
        
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.CssSelector, Using = "#generalTabstrip > ul > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement AdditionalFieldsScreen { get; set; }

        public static By aditionalFields = By.CssSelector("#generalTabstrip > ul > li:nth-child(2)");

        [FindsBy(How = How.Id, Using = "btnMoreFieldsManagerCreateNew")]
        [CacheLookup]
        public IWebElement CreateNewField { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement FieldName { get; set; }

        [FindsBy(How = How.Id, Using = "FieldValues_0_")]
        public IWebElement DropdownValue { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveMoreField")]
        [CacheLookup]
        public IWebElement FieldSave { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"addMoreFieldsForm\"]/table/tbody/tr[2]/td[2]/div/span")]
        [CacheLookup]
        public IWebElement SelectFieldType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.k-widget.k-window.k-rtl.k-window-titleless.blue-border > span")]
        [CacheLookup]
        public IWebElement CloseFieldWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"moreFieldsManagmentGrid2\"]/div[2]/table/tbody/tr[11]/td[3]/a[2]/span")]
        [CacheLookup]
        public IWebElement DeleteIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"moreFieldsManagmentGrid2\"]/div[2]/table/tbody/tr[11]/td[3]/a[2]/span")]
        [CacheLookup]
        public IWebElement CapacityText { get; set; }


        public static By OpenFieldManager = By.Id("btnManageMoreFields");
        public string addFieldsableCount = "//*[@id='moreFieldsManagmentGrid2']/div[2]/table/tbody";
        public string AdditionalFieldScreen = "#generalTabstrip > ul > li:nth-child(2)";

        //create new additional Field application

        public void EnterAdditionalFieldsScreen() {
            //call home page to enter general setting
            Pages.Home_Page.SettingScreenProd.ClickWait();
            Pages.Home_Page.GeneralScreen.ClickWait();
            Thread.Sleep(1500);
            AdditionalFieldsScreen.ClickWait();
        }

        public void DevEnterAdditionalFieldsScreen()
        {
            Pages.Home_Page.EnterGeneralScreen();
            Browser.chromebDriver.FindElement(aditionalFields, 1000).ClickOn();
        }

        public void OpenFieldsManager()
        {
            Browser.chromebDriver.FindElement(OpenFieldManager).ClickOn();
            softAssert.VerifyElementPresentInsideWindow(CreateNewField, CloseFieldWindow);
            Constant.tmpTableCount = utility.TableCount(addFieldsableCount);
        }

        public void AdditionalFieldApplication()
        {
            Pages.AdditinalFields_Page.DevEnterAdditionalFieldsScreen();
            Pages.AdditinalFields_Page.OpenFieldsManager();
            CreateNewField.ClickOn();
            FieldSave.ClickOn();
            softAssert.VerifyErrorMsg();
            FieldName.EnterClearText("Field"  + RandomNumber.smallNumber());
            FieldSave.ClickWait();
            softAssert.VerifyElementHasEqual(utility.TableCount(addFieldsableCount), Constant.tmpTableCount + 1);
            CloseFieldWindow.ClickOn();
        }
    }
}
