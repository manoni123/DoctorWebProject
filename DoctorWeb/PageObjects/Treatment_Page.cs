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

        public void CreateNewSeriesTreatment()
        {
            Pages.Patient_Page.PatientTreatments.ClickWait();
            CreateNewTreatment.ClickOn();
            IWebElement treatmentList = Browser.Driver.FindElement(By.Id("newItemMenu"));
            treatmentList.FindElements(By.TagName("li")).ElementAt(2).ClickOn();
        }

        public void CreateNewTreatmentPlan()
        {
            Pages.Patient_Page.PatientTreatments.ClickWait();
            CreateNewTreatment.ClickOn();
            IWebElement treatmentList = Browser.Driver.FindElement(By.Id("newItemMenu"));
            treatmentList.FindElements(By.TagName("li")).ElementAt(2).ClickOn();
        }
    }
}
