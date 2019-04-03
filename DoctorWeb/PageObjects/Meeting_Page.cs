using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Meeting_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "btnCancelAppointment")]
        [CacheLookup]
        public IWebElement CancelMeeting { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnCreateAppointmentSave']")]
        [CacheLookup]
        public IWebElement ApproveMeeting { get; set; }

        [FindsBy(How = How.Id, Using = "btnCreateAppointmentSave")]
        [CacheLookup]
        public IWebElement Expertise { get; set; }

        [FindsBy(How = How.Id, Using = "appointmentPatientsAutoComplete")]
        [CacheLookup]
        public IWebElement SearchPatient { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='appointmentPatientsAutoComplete_listbox']/li[1]")]
        [CacheLookup]
        public IWebElement SelectFirstPatient { get; set; }

        [FindsBy(How = How.Id, Using = "btnTreatmentsFromPricelist")]
        [CacheLookup]
        public IWebElement PriceList { get; set; }

        [FindsBy(How = How.Id, Using = "PriceListRefID_validationMessage")]
        [CacheLookup]
        public IWebElement VisitReasonError { get; set; }

        [FindsBy(How = How.Id, Using = "EntityID_validationMessage")]
        [CacheLookup]
        public IWebElement PatientNameError { get; set; }

        [FindsBy(How = How.Id, Using = "PriceListRefID_validationMessage")]
        [CacheLookup]
        public IWebElement HourSelect { get; set; }

        [FindsBy(How = How.XPath , Using = "//*[@id='gridTreatmentFroPrice_TreatmentsItems']/div[2]/table/tbody/tr/td[4]")]
        [CacheLookup]
        public IWebElement CodeSearch { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn_codeBrowser")]
        [CacheLookup]
        public IWebElement CodeBroswer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridCodeBrowser']/div[2]/table/tbody/tr/td[5]/div/input")]
        [CacheLookup]
        public IWebElement CodeBroswerFirstCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='createAppointmentForm']/div/div[2]/div[1]/div[1]/div[5]/div[2]/span[1]/span/input[1]")]
        [CacheLookup]
        public IWebElement MeetingDuration { get; set; }

        [FindsBy(How = How.Id, Using = "btnSelectTreatmentsFromPriceListSave")]
        [CacheLookup]
        public IWebElement SaveTreatmentFromPricelist { get; set; }

        [FindsBy(How = How.Id, Using = "btnSelectTreatmentsFromPriceListSave")]
        [CacheLookup]
        public IWebElement CancelTreatmentFromPricelist { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='createAppointmentForm']/div/div[2]/div[1]/div[1]/div[7]/div/span[1]")]
        [CacheLookup]
        public IWebElement RepeatField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridTreatmentFroPrice_TreatmentsItems']/div[2]/table/tbody/tr/td[2]/span[1]")]
        [CacheLookup]
        public IWebElement PriceType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='div_Sources']/label[2]")]
        [CacheLookup]
        public IWebElement SeriesRadioSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='div_Sources']/label[1]")]
        [CacheLookup]
        public IWebElement TreatmentRadioSelect { get; set; }

        public void CreateMeetingApplication() {
            Thread.Sleep(500);
            utility.TextClearDropdownAndEnter(SearchPatient, Pages.Patient_Page.PatientUseName);
            Thread.Sleep(500);
            PriceList.ClickWait();
            CodeBroswer.ClickOn();
            CodeBroswerFirstCode.ClickOn();
            SaveTreatmentFromPricelist.ClickOn();
            ApproveMeeting.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void CreateMeetingFromAvailbleTime() {
            PriceList.ClickWait();
            Browser.Driver.FindElement(By.Id("Code_AutoComplete_PriceListCode")).EnterClearText(Constant.priceListExistCode);
            utility.ClickDropdownAndEnter(CodeSearch);
            SaveTreatmentFromPricelist.ClickOn();
            Thread.Sleep(500);
         //   utility.ClickDropdownAndEnter(RepeatField);
            ApproveMeeting.ClickOn();
        }

        public void CreateMeetingKnownPatient()
        {
            PriceList.ClickOn();
            Browser.Driver.FindElement(By.Id("Code_AutoComplete_PriceListCode")).EnterClearText(Constant.priceListExistCode);
            utility.ClickDropdownAndEnter(CodeSearch);
            SaveTreatmentFromPricelist.ClickOn();
            Thread.Sleep(500);
            ApproveMeeting.ClickOn();
        }
    }
}
