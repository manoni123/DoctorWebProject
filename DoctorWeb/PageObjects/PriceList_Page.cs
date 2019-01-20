using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Diagnostics;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class PriceList_Page
    {
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        [FindsBy(How = How.CssSelector, Using = "#generalTabstrip > ul > li:nth-child(5)")]
        [CacheLookup]
        public IWebElement PriceListScreen { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddPriceListCode")]
        [CacheLookup]
        public IWebElement PriceListCreateNew { get; set; }

        [FindsBy(How = How.Id, Using = "btnManageCategories")]
        [CacheLookup]
        public IWebElement CategoryManager { get; set; }

        [FindsBy(How = How.Id, Using = "btnPriceListCategoryManagerCreateNew")]
        [CacheLookup]
        public IWebElement CategoryCreateNew { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement CategoryName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#priceListTabStrip > ul > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement DevCategoryWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PriceListCategoryManagmentGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement CategoryApprove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PriceListCategoryManagmentGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement CategoryDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PriceListCategoryManagmentGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement CategoryEdit { get; set; }

        [FindsBy(How = How.Id, Using = "btnPriceListCategoryManagerCancel")]
        [CacheLookup]
        public IWebElement CategoryCloseWindow { get; set; }

        [FindsBy(How = How.Id, Using = "Code")]
        [CacheLookup]
        public IWebElement PriceListCode { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement PriceListName { get; set; }

        [FindsBy(How = How.Id, Using = "Price")]
        [CacheLookup]
        public IWebElement PriceListPrice { get; set; }

        [FindsBy(How = How.Id, Using = "btnSavePriceListCode_Cancel")]
        [CacheLookup]
        public IWebElement PriceListCancel { get; set; }

        [FindsBy(How = How.Id, Using = "btnEditPriceListCodeContinue")]
        [CacheLookup]
        public IWebElement PriceListSaveDev { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelCreateCode")]
        [CacheLookup]
        public IWebElement PriceListCancelDev { get; set; }

        [FindsBy(How = How.Id, Using = "btnEditPriceListCodePrev")]
        [CacheLookup]
        public IWebElement PriceListPrevDev { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frmEditPriceListCode_Step1']/div[1]/div[3]/div/span[1]")]
        [CacheLookup]
        public IWebElement PriceListType { get; set; }

        [FindsBy(How = How.Id, Using = "Type_listbox")]
        [CacheLookup]
        public IWebElement PriceListTypeBoxList { get; set; }
        
        [FindsBy(How = How.Id, Using = "SubItemCodeName")]
        [CacheLookup]
        public IWebElement PriceListSubCode { get; set; }

        [FindsBy(How = How.Id, Using = "CountSubItems")]
        [CacheLookup]
        public IWebElement PriceListSubCodeCount { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frmEditPriceListCode_Step1']/div[1]/div[6]/div[2]/span")]
        [CacheLookup]
        public IWebElement PriceListTaxSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"frmAddNewPriceListCode\"]/div[2]/div/div[1]/div/div/div/div[4]/div/span[1]")]
        [CacheLookup]
        public IWebElement PriceListCategorySelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"frmAddNewPriceListCode\"]/div[2]/div/div[1]/div/div/div/div[5]/div/span[1]")]
        [CacheLookup]
        public IWebElement PriceListDepartmentSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"frmAddNewPriceListCode\"]/div[2]/div/div[1]/div/div/div/div[6]/div/span[1]/span/span[2]/span[1]")]
        [CacheLookup]
        public IWebElement PriceListAddMeetingTime { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveNewPriceListCode")]
        [CacheLookup]
        public IWebElement CreateCodeConfirm { get; set; }

        [FindsBy(How = How.Id, Using = "btnSavePriceListCode_Cancel")]
        [CacheLookup]
        public IWebElement CreateCodeCancel { get; set; }

        [FindsBy(How = How.Id, Using = "Name_validationMessage")]
        [CacheLookup]
        public IWebElement CategoryNameValidation { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement PopUpButtonApprove { get; set; }

        [FindsBy(How = How.Id, Using = "Name_validationMessage")]
        [CacheLookup]
        public IWebElement ValidationError { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='findTimeSlotForm']/div/div[2]/div[1]/div[1]/div[8]/div/span[1]")]
        [CacheLookup]
        public IWebElement VisitReason { get; set; }

        public void EnterPriceListScreen() {
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreen.ClickWait("Setting");
            Pages.Home_Page.GeneralScreen.ClickWait("General");
            PriceListScreen.ClickWait("PriceList");
        }

        public void DevEnterCategoryWindow() {
            Pages.Home_Page.SettingScreen.ClickWait("Setting");
            Pages.Home_Page.DevPricelistScreen.ClickWait("PriceList");
            DevCategoryWindow.ClickWait("Category");
        }

        public void OpenCategoryManager()
        {
            CategoryManager.ClickOn("CategoryManager");
            softAssert.VerifyElementIsPresent(CategoryCloseWindow);
        }

        public void OpenPriceListAddWindow()
        {
            PriceListCreateNew.ClickOn("PricelistCreate");
            softAssert.VerifyElementIsPresent(PriceListCancel);
        }

        public void CountPriceListApplicaiton() {
            try
            {
                Pages.PriceList_Page.EnterPriceListScreen();
                int listCount = Browser.Driver.FindElements(By.XPath("//*[@id='gridAppointmentTypes']/div[2]/div[1]/table/tbody")).Count;
                Pages.Home_Page.EnterAvailbleTime();
                Pages.PriceList_Page.VisitReason.ClickOn("VisitReason");
                int visitCount = Browser.Driver.FindElements(By.XPath("//*[@id='findTimeSlotForm']/div/div[2]/div[1]/div[1]/div[8]/div/span[1]")).Count;
                Assert.AreEqual(visitCount, listCount);
                Pages.Home_Page.PopupClose.ClickOn("Popup Close");
            }
            catch (AssertionException e) {
                Pages.Home_Page.PopupClose.ClickOn("Popup Close");
                Debug.WriteLine(e);
            }
        }

        public void CreateCategoryApplication() {
            var listCount = utility.ListCount("//*[@id='PriceListCategoryManagmentGrid']/div[2]/table/tbody");
            CategoryCreateNew.ClickOn(Constant.Create);
            CategoryApprove.ClickOn("CategorySave");
            softAssert.VerifyElementIsPresent(CategoryNameValidation);
            CategoryName.EnterClearText(Constant.CategoryName + RandomNumber.smallNumber());
            CategoryApprove.ClickOn("CategorySave");
            var listCountAfter = utility.ListCount("//*[@id='PriceListCategoryManagmentGrid']/div[2]/table/tbody");
            softAssert.VerifyElementIsPresent(CategoryDelete);
            Assert.AreNotEqual(listCountAfter, listCount);
        }

        public void DeleteCategoryApplication() {

            CategoryDelete.ClickOn("CategoryDelete");
            softAssert.VerifyElementIsPresent(PopUpButtonApprove);
            PopUpButtonApprove.ClickOn(Constant.Approve);
        }

        public void DeleteActiveCategoryApplication()
        {
            CategoryManager.ClickOn("CategoryManager");
            if (CategoryDelete.IsDisplayed("if delete action is shown"))
            {
                Log.Error("Delete Icon Shown on Acitve category - Fail");
            }
            else {
                CategoryCloseWindow.ClickOn(Constant.CloseWindow);
            }

        }

        public void EditCategoryApplication() {
            CategoryEdit.ClickOn(Constant.Edit);
            CategoryName.Clear();
            CategoryApprove.ClickOn("CategorySave");
            softAssert.VerifyElementIsPresent(CategoryNameValidation);
            CategoryName.EnterClearText(Constant.CategoryName);
            CategoryApprove.ClickOn(Constant.Approve);
        }

        public void CreatePriceListApplication()
        {
            softAssert.VerifyElementPresentInsideWindow(CreateCodeCancel, CreateCodeCancel);
            PriceListCode.SendKeys(Constant.priceListCode);
            PriceListName.SendKeys(Constant.priceListName);
            Thread.Sleep(500);
            CreateCodeConfirm.ClickOn(Constant.Save);
        }

        public void DevCreatePriceListDevApplication() {
            var listCount = utility.ListCount("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody");
            PriceListCreateNew.ClickOn("PricelistCreate");
            PriceListSaveDev.ClickOn("PricelistSave");
            softAssert.VerifyElementPresentInsideWindow(ValidationError, PriceListCancelDev);
            PriceListName.EnterText(Constant.priceListName);
            PriceListCode.EnterText(Constant.priceListCode);
            PriceListPrice.EnterClearText("25");
            PriceListSaveDev.ClickOn("PricelistSave");
            PriceListSaveDev.ClickOn("PricelistSave");
            var listCountAfter = utility.ListCount("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody");
            Assert.AreEqual(listCountAfter, listCount+1);
        }

        public void DevCreatePriceListPackageApplicaiton() {
            try
            {
                var listCount = utility.ListCount("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody");
                var usedCode = utility.ElementText("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody/tr/td[1]");
                PriceListCreateNew.ClickOn("PricelistCreate");
                PriceListSaveDev.ClickOn("PricelistSave");
                softAssert.VerifyElementPresentInsideWindow(ValidationError, PriceListCancelDev);
                PriceListCode.EnterText(Constant.priceListCode);
                PriceListName.EnterText(Constant.priceListName);
                Thread.Sleep(500);
                PriceListType.ClickOn("PricelistType");
                PriceListType.ClickOn("PricelistType");
                PriceListType.SendKeys(Keys.ArrowDown);
                PriceListType.SendKeys(Keys.ArrowDown);
                PriceListType.ClickOn("PricelistType");
                PriceListSubCode.EnterText(usedCode);
                Thread.Sleep(500);
                PriceListSubCode.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                PriceListSubCode.SendKeys(Keys.Enter);
                PriceListSaveDev.ClickOn("PricelistSave");
                PriceListSaveDev.ClickOn("PricelistSave");
                var listCountAfter = utility.ListCount("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody");
                Assert.AreEqual(listCountAfter, listCount + 1);
            }
            catch (Exception) {
                PriceListCancelDev.ClickOn(Constant.PopupCancel);
                Assert.Fail();
            }
        }
    }
}
