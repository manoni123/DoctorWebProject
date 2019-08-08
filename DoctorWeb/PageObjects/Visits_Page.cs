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
        UtilityFunction utility = new UtilityFunction();
      

        [FindsBy(How = How.Id, Using = "tab2btnPrintEventsDetails1")]
        [CacheLookup]
        public IWebElement PrintSummon { get; set; }

        [FindsBy(How = How.Id, Using = "tab2ExportContactsToPDF1")]
        [CacheLookup]
        public IWebElement VisitsPdf { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_gridCustomerEvents']/div[2]/div[1]/table/tbody")]
        [CacheLookup]
        public IWebElement TherapistDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tab4_menuCustomerExpended > li:nth-child(3)")]
        [CacheLookup]
        public IWebElement VisitButton { get; set; }

        public string visitsTableCount = "//*[@id='tab4_gridCustomerEvents']/div[2]/div[1]/table/tbody";

        public void PatientVisitsApplication()
        {
            //Pages.PriceList_Page.PriceListFirstCodeName();;
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.EnterPatientVisits();
            Constant.tmpTableCount = utility.TableCount(visitsTableCount);
            Pages.Patient_Page.ClosePatientTab.ClickOn();
            Pages.Home_Page.EnterAvailbleTime();
            Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
            Pages.Meeting_Page.CreateMeetingApplication();
            utility.TextClearDropdownAndEnter(Pages.Home_Page.SearchBox, Pages.Patient_Page.PatientUseName);
            Pages.Patient_Page.EnterPatientVisits();
            softAssert.VerifyElementHasEqual(utility.TableCount(visitsTableCount),  Constant.tmpTableCount + 1);
        }
    }
}
