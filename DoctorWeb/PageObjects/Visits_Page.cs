using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Visits_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly AssertionExtent softAssert = new AssertionExtent();

        [FindsBy(How = How.Id, Using = "tab2btnPrintEventsDetails1")]
        [CacheLookup]
        public IWebElement PrintSummon { get; set; }

        [FindsBy(How = How.Id, Using = "tab2ExportContactsToPDF1")]
        [CacheLookup]
        public IWebElement VisitsPdf { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_gridCustomerEvents']/div[2]/div[1]/table/tbody")]
        [CacheLookup]
        public IWebElement TherapistDropdown { get; set; }


        public void PatientVisitsApplication()
        {
            Pages.Patient_Page.PatientMeetingCreate.ClickOn();
            IWebElement patientAvailbleTime = Browser.Driver.FindElement(By.Id("tab3_newAppointmentContextMenu"));
            patientAvailbleTime.FindElements(By.TagName("li")).ElementAt(0).ClickOn();
            Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
            Pages.Meeting_Page.CreateMeetingApplication();
            Thread.Sleep(500);
            Pages.Patient_Page.EnterPatientVisits();
            Pages.Patient_Page.PatientVisits.ClickOn();
            var meetingTable = Browser.Driver.FindElements(By.XPath("//*[@id='tab3_gridCustomerEvents']/div[2]/div[1]/table/tbody")).Count;
            if (meetingTable == 0) {
                Assert.Fail(); 
            }

        }
    }
}
