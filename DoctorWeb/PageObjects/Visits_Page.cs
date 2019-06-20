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

        public void PatientVisitsApplication()
        {
            //Pages.PriceList_Page.PriceListFirstCodeName();;
            Pages.Patient_Page.NewPatientApplication();
            Thread.Sleep(1000);
            Pages.Patient_Page.EnterPatientVisits();
            var countBefore = utility.TableCount("//*[@id='tab2_gridCustomerEvents']/div[2]/div[1]/table/tbody");
            Pages.Patient_Page.ClosePatientTab.ClickOn();
            Pages.Home_Page.EnterAvailbleTime();
            Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
            Pages.Meeting_Page.CreateMeetingApplication();
            utility.TextClearDropdownAndEnter(Pages.Home_Page.SearchBox, Pages.Patient_Page.PatientUseName);
            Thread.Sleep(1500);
            var VisitButton = Browser.Driver.FindElement(By.CssSelector("#tab4_menuCustomerExpended > li:nth-child(3)"));
            VisitButton.ClickOn();
            var countAfter = utility.TableCount("//*[@id='tab4_gridCustomerEvents']/div[2]/div[1]/table/tbody");
            softAssert.VerifyElemenNotHaveEqual(countBefore, countAfter);
        }
    }
}
