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
    public class Treatment_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "tab3_btnAddNewTreatmentItem")]
        [CacheLookup]
        public IWebElement CreateNewTreatment { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frmNewTreatment']/div[1]/div/table/tbody/tr/td[1]/div/span[1]")]
        [CacheLookup]
        public IWebElement SelectTerapist { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frmNewTreatment']/div[1]/div/table/tbody/tr/td[2]/div/span[1]")]
        [CacheLookup]
        public IWebElement SelectPricelistType { get; set; }

        [FindsBy(How = How.Id, Using = "Codes")]
        [CacheLookup]
        public IWebElement SelectCode { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn_codeBrowser")]
        [CacheLookup]
        public IWebElement CodeBrowser { get; set; }

        [FindsBy(How = How.ClassName, Using = "//*[@id='gridCodeBrowser']/div[2]/table/tbody/tr[1]/td[5]")]
        [CacheLookup]
        public IWebElement ApproveField { get; set; }

        [FindsBy(How = How.ClassName, Using = "//*[@id='gridCodeBrowser']/div[2]/table/tbody/tr[1]/td[5]/div/input")]
        [CacheLookup]
        public IWebElement ApproveCodeButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnTreatmentItemSave")]
        [CacheLookup]
        public IWebElement SaveTreatment { get; set; }

        [FindsBy(How = How.ClassName, Using = "btnTreatmentPlanTemplateEditCancel")]
        [CacheLookup]
        public IWebElement CancelTreatment { get; set; }

        [FindsBy(How = How.Id, Using = "PlanName")]
        [CacheLookup]
        public IWebElement TreatmentPlanName { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveTreatmentPlan")]
        [CacheLookup]
        public IWebElement TreatmentPlanSave { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='frmNewSeries']/div[1]/div/table/tbody/tr/td[1]/div/span[1]")]
        [CacheLookup]
        public IWebElement TreatmentSeriesTherapist { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridTreatmentPlanItems']/div[2]/table/tbody/tr/td[2]/span[1]")]
        [CacheLookup]
        public IWebElement TreatmentPlanTherapist { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_treatmentMenu']/li[7]")]
        [CacheLookup]
        public IWebElement TreatmentSingleDeleteFromMenu { get; set; }

        [FindsBy(How = How.Id, Using = "btnConfirmDeleteTreatmentSubmit")]
        [CacheLookup]
        public IWebElement TreatmentSingleDeleteFromMenuConfirmDelete { get; set; }

        [FindsBy(How = How.Id, Using = "btnConfirmDeleteTreatmentCancel")]
        [CacheLookup]
        public IWebElement TreatmentSingleDeleteFromMenuCancelDelete { get; set; }

        private string countTreatmentTable = "//*[@id='tab3_customerTreatmentsGrid_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody";

        public void GoTo() {
            Pages.Patient_Page.PatientTreatments.ClickWait();
            Constant.tmpTableCount = utility.TableCount("//*[@id='tab3_customerTreatmentsGrid_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody");
        }

        public void CreateNewSingleTreatmentApplication() {
            Pages.Patient_Page.NewPatientApplication();
            GoTo();
            CreateNewTreatment.ClickOn();
            utility.SelectFromList("newItemMenu", 0);
            utility.ClickDropdownAndEnter(SelectTerapist);
            utility.SelectCodeOnCodeBroswer("//*[@id='gridCodeBrowser']/div[2]/table/tbody/tr[1]/td[5]/div/input");
            Thread.Sleep(500);
            SaveTreatment.ClickWait();
            softAssert.VerifyElemenNotHaveEqual(utility.TableCount("//*[@id='tab3_customerTreatmentsGrid_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody"), Constant.tmpTableCount);
        }

        public void CreateNewSeriesTreatmentApplication()
        {
            Pages.Patient_Page.NewPatientApplication();
            GoTo();
            CreateNewTreatment.ClickOn();
            utility.SelectFromList("newItemMenu", 1);
            utility.ClickDropdownAndEnter(TreatmentSeriesTherapist);
            utility.SelectCodeOnCodeBroswer("//*[@id='gridCodeBrowser']/div[2]/table/tbody/tr/td[6]/div/input");
            Thread.Sleep(500);
            SaveTreatment.ClickWait();
            softAssert.VerifyElemenNotHaveEqual(utility.TableCount("//*[@id='tab3_customerTreatmentsGrid_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody"), Constant.tmpTableCount);
        }

        public void DeleteTreatmentApplication()
        {
            CreateNewSingleTreatmentApplication();
            CreateMeetingForTreatment();
            Browser.chromebDriver.FindElement(By.XPath("//*[@id='tab3_customerTreatmentsGrid_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody/tr[1]/td[13]/a/span")).ClickOn();
            TreatmentSingleDeleteFromMenu.ClickOn();
            TreatmentSingleDeleteFromMenuCancelDelete.ClickOn();
          //  softAssert.VerifySuccessMsg();
        }

        public void CreateMeetingForTreatment()
        {
            Browser.chromebDriver.FindElement(By.XPath("//*[@id='tab3_customerTreatmentsGrid_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody/tr/td[3]/input")).Click();
            utility.SelectFromList("tab3_createAppointmentMenu", 1); // press on treatment and select By find a time.
            Pages.AvailbleTime_Page.SearchAvailbleTimeFromTreatmentApplication();
            Pages.Meeting_Page.ApproveMeeting.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void CreateNewPlanTreatmentApplication()
        {
            Pages.Patient_Page.NewPatientApplication();
            GoTo();
            CreateNewTreatment.ClickOn();
            utility.SelectFromList("newItemMenu", 2);
            TreatmentPlanName.SendKeys("Plan" + RandomNumber.smallNumber());
          //  utility.ClickDropdownAndEnter(TreatmentPlanTherapist);
            TreatmentPlanTherapist.ClickOn();
            TreatmentPlanTherapist.SendKeys(Keys.Down);
            utility.SelectCodeOnCodeBroswer("//*[@id='gridCodeBrowser']/div[2]/table/tbody/tr[1]/td[5]/div/input");
            Thread.Sleep(500);
            TreatmentPlanSave.Click();
            softAssert.VerifyElemenNotHaveEqual(utility.TableCount("//*[@id='tab3_customerTreatmentsGrid_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody"), Constant.tmpTableCount);
        }
    }
}
