using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        [FindsBy(How = How.CssSelector, Using = "#priceListTabStrip > ul > li:nth-child(1)")]
        [CacheLookup]
        public IWebElement PriceListWindow { get; set; }

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

        [FindsBy(How = How.Id, Using = "Code-error")]
        [CacheLookup]
        public IWebElement ValidationError { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='findTimeSlotForm']/div/div[2]/div[1]/div[1]/div[8]/div/span[1]")]
        [CacheLookup]
        public IWebElement VisitReason { get; set; }

        public string priceListTableCount = "//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody";
        public string priceListFirstCode = "//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody/tr/td[1]";
        public string categoryTableCount = "//*[@id='PriceListCategoryManagmentGrid']/div[2]/table/tbody";

        public void GoToProd() {
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreenProd.ClickWait();
            Pages.Home_Page.GeneralScreen.ClickWait();
            Thread.Sleep(500);
            PriceListScreen.ClickWait();
            Constant.priceListExistCode = Browser.Driver.FindElement(By.XPath("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody/tr[1]/td[1]")).Text;
        }

        public void GoTo() {
            Pages.Home_Page.EnterSettingScreen();
            Browser.chromebDriver.FindElement(By.CssSelector("#settingsTabstrip > ul > li:nth-child(4)")).ClickOn();
          //  Pages.Home_Page.DevPricelistScreen.ClickWait();
            Constant.priceListExistCode = Browser.Driver.FindElement(By.XPath("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody/tr[1]/td[1]")).Text;
            Constant.tmpTableCount = utility.TableCount(priceListTableCount);
        }

        public void EnterCategoryWindow() {
            DevCategoryWindow.ClickOn();
            softAssert.VerifyElementIsPresent(CategoryCreateNew);
            Constant.tmpTableCount = utility.TableCount(categoryTableCount);
        }

        public void OpenCategoryManager()
        {
            CategoryManager.ClickOn();
            softAssert.VerifyElementIsPresent(CategoryCloseWindow);
        }

        public void OpenPriceListAddWindow()
        {
            PriceListCreateNew.ClickOn();
            softAssert.VerifyElementIsPresent(PriceListCancel);
        }

        public void CountPriceListApplication() {
            Pages.PriceList_Page.GoTo();
            Pages.AvailbleTime_Page.GoTo();
            Pages.PriceList_Page.VisitReason.ClickOn();
            softAssert.VerifyElementHasEqual(utility.TableCount(priceListTableCount), Constant.tmpTableCount);
            Pages.Home_Page.PopupClose.ClickOn();
        }

        public void CreateCategoryApplication() {
            EnterCategoryWindow();
            CategoryCreateNew.ClickOn();
            CategoryApprove.ClickOn();
            softAssert.VerifyElementIsPresent(CategoryNameValidation);
            CategoryName.EnterClearText(Constant.CategoryName + RandomNumber.smallNumber());
            CategoryApprove.ClickOn();
            softAssert.VerifyElementHasEqual(utility.TableCount(categoryTableCount), Constant.tmpTableCount + 1);
        }

        public void DeleteCategoryApplication() {
            CategoryDelete.ClickOn();
            PopUpButtonApprove.ClickOn();
            Thread.Sleep(500);
            softAssert.VerifyElementHasEqual(utility.TableCount(categoryTableCount), Constant.tmpTableCount);
        }

        public void EditCategoryApplication() {
            CategoryEdit.ClickOn();
            CategoryName.Clear();
            CategoryApprove.ClickOn();
            softAssert.VerifyElementIsPresent(CategoryNameValidation);
            CategoryName.EnterClearText(Constant.CategoryName + RandomNumber.smallNumber());
            CategoryApprove.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void DeleteActiveCategoryApplication()
        {
            Pages.PriceList_Page.CreateCategoryApplication();
            CategoryManager.ClickOn();
            if (CategoryDelete.IsDisplayed("if delete action is shown"))
            {
                Log.Error("Delete Icon Shown on Acitve category - Fail");
            }
            else
            {
                CategoryCloseWindow.ClickOn();
            }
        }


        public void CreatePriceListApplication()
        {
            Pages.PriceList_Page.OpenPriceListAddWindow();
            softAssert.VerifyElementPresentInsideWindow(CreateCodeCancel, CreateCodeCancel);
            PriceListCode.SendKeys(Constant.priceListCode);
            PriceListName.SendKeys(Constant.priceListName);
            Thread.Sleep(500);
            CreateCodeConfirm.ClickWait();
            softAssert.VerifyElemenNotHaveEqual(utility.TableCount(priceListTableCount), Constant.tmpTableCount);
        }

        public void DevCreatePriceListApplication() {
            Pages.Home_Page.EntePriceListTab();
            PriceListCreateNew.ClickOn();
            PriceListSaveDev.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(ValidationError, PriceListCancelDev);
            PriceListName.EnterText(Constant.priceListName + RandomNumber.smallNumber());
            PriceListCode.EnterText(Constant.priceListCode + RandomNumber.smallNumber());
            PriceListPrice.EnterClearText("25");
            PriceListSaveDev.ClickOn();
            if (Browser.Driver.FindElement(By.XPath("//*[@id='createCodeWizardNumber']/label[2]/span[1]")).Displayed)
            {
                PriceListSaveDev.ClickOn();
                PriceListSaveDev.ClickOn();
            }
            else {
                PriceListSaveDev.ClickOn();
            }
            softAssert.VerifySuccessMsg();
            softAssert.VerifyElementHasEqual(utility.TableCount(priceListTableCount), Constant.tmpTableCount + 1);
        }

       
        public void DevCreatePriceListSeriesApplicaiton() {
            Pages.Home_Page.EntePriceListTab();
            PriceListCreateNew.ClickOn();
            PriceListCode.EnterText(Constant.priceListCode + RandomNumber.smallNumber());
            PriceListName.EnterText(Constant.priceListName + RandomNumber.smallNumber());
            Thread.Sleep(500);
            PriceListType.ClickOn();
            PriceListType.SendKeys(Keys.ArrowDown);
            PriceListType.SendKeys(Keys.ArrowDown);
            PriceListType.ClickOn();
            PriceListSubCode.EnterText(Constant.priceListExistCode);
            Thread.Sleep(500);
            PriceListSubCode.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            PriceListSubCode.SendKeys(Keys.Enter);
            PriceListSaveDev.ClickOn();
            PriceListSaveDev.ClickOn();
            softAssert.VerifyElementHasEqual(utility.TableCount(priceListTableCount), Constant.tmpTableCount + 1);
        }
    }
}
