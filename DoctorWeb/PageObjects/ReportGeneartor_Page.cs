using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class ReportGenerator_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "btn_saveReport")]
        public IWebElement SaveReport { get; set; }

        [FindsBy(How = How.Id, Using = "btn_manageReports")]
        public IWebElement ReportsManagementWindow { get; set; }

        [FindsBy(How = How.Id, Using = "btn_runReport")]
        public IWebElement RunReport { get; set; }

        [FindsBy(How = How.Id, Using = "btnSavedReportsManager_close")]
        public IWebElement ReportManagementWindowClose { get; set; }

        [FindsBy(How = How.Id, Using = "ReportName")]
        public IWebElement ReportName { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveReportTemplate")]
        public IWebElement SaveAfterName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='manageReportsGrid']/div[2]/table/tbody/tr[1]/td[5]/a[1]")]
        public IWebElement ReportEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='manageReportsGrid']/div[2]/table/tbody/tr[1]/td[5]/a[2]")]
        public IWebElement CancelEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='manageReportsGrid']/div[2]/table/tbody/tr[1]/td[5]/a[1]")]
        public IWebElement ApproveEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='manageReportsGrid']/div[2]/table/tbody/tr[1]/td[5]/a[3]")]
        public IWebElement ReportDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='popup-btn-OK']")]
        public IWebElement ApproveDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='manageReportsGrid']/div[2]/table/tbody/tr[1]/td[5]/a[2]")]
        public IWebElement ReportShare { get; set; }

        [FindsBy(How = How.Id, Using = "btn_showFullResultPage")]
        public IWebElement ShowFullReport { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='entity_dd']/span")]
        public IWebElement ReportEntityDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='report-generator-condition-table']/tr[1]/td[2]/span")]
        public IWebElement ReportConditionFieldDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Conditions_0__FieldID_listbox']/li[17]")]
        public IWebElement SelectStatusFieldCondition { get; set; }


        public void GoTo()
        {
            Browser.chromebDriver.WaitFindElement(Pages.Home_Page.ReportScreen);
            //  Pages.Home_Page.ReportScreen.ClickWait();
            Browser.chromebDriver.WaitFindElement(Pages.Reports_Page.ReportGeneatorScreen);
            Pages.Reports_Page.ReportGeneatorScreen.ClickOn();
            Constant.tmpListCount = utility.ListCount(Pages.Home_Page.MainTabs);
        }

        public void ReportManagementWindow()
        {
            ReportsManagementWindow.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(ReportManagementWindowClose, ReportManagementWindowClose);
        }

        public void ReportGenerationCreateApplication()
        {
            GoTo();
            utility.ClickDropdownAndEnter(ReportEntityDropdown);
            FillFieldsToDisplay();
            FindFieldToDefine();
            SaveReport.ClickOn();
            ReportName.SendKeys(Constant.ReportName + RandomNumber.smallNumber());
            SaveAfterName.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void ReportGenerationEditApplication()
        {
            ReportsManagementWindow.ClickOn();
            ReportEdit.ClickOn();
            ReportName.EnterClearText("edit" + RandomNumber.smallNumber());
            ApproveEdit.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void ReportGenerationDeleteApplication()
        {
            ReportDelete.ClickOn();
            ApproveDelete.ClickOn();
            softAssert.VerifySuccessMsg();
            ReportManagementWindowClose.ClickOn();
        }

        public void FindFieldToDefine()
        {
            ReportConditionFieldDropdown.ClickOn();
            SelectStatusFieldCondition.ClickOn();
        }

        public void ExecuteReport()
        {
            RunReport.ClickOn();
            ShowFullReport.ClickWait();
            softAssert.VerifyElementHasEqual(utility.ListCount(Pages.Home_Page.MainTabs), Constant.tmpListCount+1);
        }


        public void FillFieldsToDisplay()
        {
            int fieldsCount = utility.TableCount("//*[@id='grid_FieldList']/div[2]/table/tbody/");
            IWebElement drop = Browser.Driver.FindElement(By.XPath("//*[@id='grid_SortAndSummary']/div[2]/table/tbody"));

            for (int i = 1; i < 10; i++)
            {
                IWebElement drag = Browser.Driver.FindElement(By.XPath("//*[@id='grid_FieldList']/div[2]/table/tbody/tr["+i+"]"));
                (new Actions(Browser.chromebDriver)).ClickAndHold(drag).MoveToElement(drop).DragAndDrop(drag, drop).Perform();
            }
        }
    }
}
