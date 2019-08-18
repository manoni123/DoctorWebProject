using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class AvailbleTime_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();

        [FindsBy(How = How.Name, Using = "ExpertiesID_input")]
        [CacheLookup]
        public IWebElement ExpertiseSelect { get; set; }

        [FindsBy(How = How.Id, Using = "btnFindTime")]
        [CacheLookup]
        public IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "popup-close-button")]
        [CacheLookup]
        public IWebElement CloseWindow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#getFreeTimeGrid_SuperSlots > div.k-grid-content.k-auto-scrollable > div.k-virtual-scrollable-wrap > table > tbody > tr:nth-child(1) > td > table > tbody > tr > td:nth-child(3) > table > tbody > tr > td > span")]
        [CacheLookup]
        public IWebElement FirstFreeTime { get; set; }

        [FindsBy(How = How.Id, Using = "btnGetFreeTimeBack")]
        [CacheLookup]
        public IWebElement AvailbleTimeGoBackBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#getFreeTimeGrid_SlotsPerDay > div.k-grid-content.k-auto-scrollable > table > tbody > tr:nth-child(1) > td.text-align-center.k-command-cell > a")]
        [CacheLookup]
        public IWebElement FirstFreeTimeSetMeeting { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='findTimeSlotForm']/div/div[2]/div[1]/div[1]/div[7]/div/div/span[5]/span/input[1]")]
        [CacheLookup]
        public IWebElement MeetingDuration { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='findTimeSlotForm']/div/div[2]/div[1]/div[1]/div[8]/div/span[1]/span/input")]
        [CacheLookup]
        public IWebElement VisitReason { get; set; }

        public void GoTo() {
            Thread.Sleep(500);
            Pages.Scheduler_Page.AvailbleTime_Btn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.AvailbleTime_Page.SearchBtn, Pages.AvailbleTime_Page.CloseWindow);
        }


        public void SearchAvailbleTimeApplication()
        {
            ExpertiseSelect.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            var durationTest = Browser.Driver.FindElement(By.XPath("//*[@id='findTimeSlotForm']/div/div[2]/div[1]/div[1]/div[7]/div/div/span[5]/span/input[1]")).GetAttribute("aria-valuenow");
            SearchBtn.ClickOn();
            FirstFreeTime.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(AvailbleTimeGoBackBtn, CloseWindow);
            FirstFreeTimeSetMeeting.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.Meeting_Page.ApproveMeeting, Pages.Meeting_Page.CancelMeeting);
            softAssert.VerifyElementHasEqual(Pages.Meeting_Page.MeetingDuration.GetAttribute("aria-valuenow"), durationTest);
        }
    }
}
