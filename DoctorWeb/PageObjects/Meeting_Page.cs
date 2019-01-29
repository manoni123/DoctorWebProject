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
    public class Meeting_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();


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

        [FindsBy(How = How.XPath, Using = "//*[@id='createAppointmentForm']/div/div[2]/div[1]/div[1]/div[3]/div[1]/span[1]/span/span[1]")]
        [CacheLookup]
        public IWebElement VisitReason { get; set; }

        [FindsBy(How = How.Id, Using = "PriceListRefID_validationMessage")]
        [CacheLookup]
        public IWebElement VisitReasonError { get; set; }

        [FindsBy(How = How.Id, Using = "EntityID_validationMessage")]
        [CacheLookup]
        public IWebElement PatientNameError { get; set; }

        [FindsBy(How = How.Id, Using = "PriceListRefID_validationMessage")]
        [CacheLookup]
        public IWebElement HourSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListRefID_listbox']/li[1]")]
        [CacheLookup]
        public IWebElement SelectFirstPriceList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='createAppointmentForm']/div/div[2]/div[1]/div[1]/div[5]/div[2]/span[1]/span/input[1]")]
        [CacheLookup]
        public IWebElement MeetingDuration { get; set; }

        public void CreateMeetingApplication() {
            try
            {
                Thread.Sleep(500);
                SearchPatient.Clear();
                SearchPatient.SendKeys(Pages.Patient_Page.PatientUseName);
                Thread.Sleep(1500);
                SearchPatient.SendKeys(Keys.ArrowDown);
                Thread.Sleep(1000);
                SearchPatient.SendKeys(Keys.Enter);
                Thread.Sleep(500);
                SearchPatient.SendKeys(Keys.Tab);
                Thread.Sleep(500);
                VisitReason.ClickOn();
                SelectFirstPriceList.ClickOn();
                ApproveMeeting.ClickOn();
            }
            catch (Exception e) {
                CancelMeeting.ClickOn();
                Assert.Warn( e + Constant.WarningMsg);
            }
        }

        public void CreateMeetingKnownPatient()
        {
            try
            {
                Thread.Sleep(500);
                SearchPatient.Clear();
                SearchPatient.SendKeys(Pages.Patient_Page.PatientUseName);
                Thread.Sleep(1500);
                SearchPatient.SendKeys(Keys.ArrowDown);
                Thread.Sleep(1000);
                SearchPatient.SendKeys(Keys.Enter);
                Thread.Sleep(500);
                SearchPatient.SendKeys(Keys.Tab);
                Thread.Sleep(500);
                VisitReason.ClickOn();
                SelectFirstPriceList.ClickOn();
                ApproveMeeting.ClickOn();
            }
            catch (Exception e)
            {
                CancelMeeting.ClickOn();
                Assert.Warn(e + Constant.WarningMsg);
            }
        }
    }
}
