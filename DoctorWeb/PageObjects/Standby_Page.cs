using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Standby_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "btnWaitListSave")]
        [CacheLookup]
        public IWebElement CreateStandby { get; set; }

        [FindsBy(How = How.Id, Using = "btnbtnWaitListCancel")]
        [CacheLookup]
        public IWebElement CancelStandby { get; set; }

        [FindsBy(How = How.Id, Using = "waitingListPatientsAutoComplete")]
        [CacheLookup]
        public IWebElement StandbySearch { get; set; }

        [FindsBy(How = How.Name, Using = "UserPractiseID_input")]
        [CacheLookup]
        public IWebElement StandbyPractice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='waitingListForm']/div/div[2]/div[1]/div/div[3]/div/span[1]/span/span[1]")]
        [CacheLookup]
        public IWebElement StandbyBranch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='waitingListForm']/div/div[3]/div[1]/div/div[3]/div/span[1]/span/input")]
        [CacheLookup]
        public IWebElement TherapistSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='waitListPanelBar']/li/span/span[3]")]
        [CacheLookup]
        public IWebElement StandByListCount { get; set; }

        [FindsBy(How = How.Id, Using = "ToDate")]
        [CacheLookup]
        public IWebElement StandbyEndDate { get; set; }

        public void CreateStandbyApplication() {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.ClosePatientTab.ClickOn();

            Pages.Scheduler_Page.EnterStandBySchedulerList();
            var CountBefore = utility.ListCount("//*[@id='wait-list']");
            Pages.Scheduler_Page.StanByCreate.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(CreateStandby, CancelStandby);
            utility.TextClearDropdownAndEnter(StandbySearch, Pages.Patient_Page.PatientUseName);
            CreateStandby.ClickOn();
            softAssert.VerifyErrorMsg();
            Pages.Meeting_Page.PriceList.ClickOn();
            Pages.Meeting_Page.CodeBroswer.ClickOn();
            Pages.Meeting_Page.CodeBroswerFirstCode.ClickOn();
            Pages.Meeting_Page.SaveTreatmentFromPricelist.ClickOn();
            TherapistSearch.SendKeys(Keys.ArrowDown);
            TherapistSearch.SendKeys(Keys.Enter);
            var CountAfter = utility.ListCount("//*[@id='wait-list']");
            Thread.Sleep(1000);
            Assert.AreNotEqual(CountBefore, CountAfter);
        }
    }
}
