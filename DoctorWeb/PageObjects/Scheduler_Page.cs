using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class Scheduler_Page
    {
        
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "schedulerHeaderMenuButton")]
        [CacheLookup]
        public IWebElement SchedulerMenuList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#schedulerHeaderMenu_mn_active > span")]
        [CacheLookup]
        public IWebElement DailyReportWindow { get; set; }

        [FindsBy(How = How.Id, Using = "btnSchedulerEventsPrint_Closeancel")]
        [CacheLookup]
        public IWebElement SchedulerEventPrintCancel { get; set; }

        [FindsBy(How = How.LinkText, Using = "דוח פגישות מבוטלות")]
        [CacheLookup]
        public IWebElement CancelledMeetingWindow { get; set; }

        [FindsBy(How = How.LinkText, Using = "רשימת פתיחות וחסימות")]
        [CacheLookup]
        public IWebElement OpenBlockWindow { get; set; }

        [FindsBy(How = How.LinkText, Using = "רשימת סטנד ביי")]
        [CacheLookup]
        public IWebElement StandbyWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='schedulerHeader']/span[3]/span")]
        [CacheLookup]
        public IWebElement CalendarBranchList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='mainCalendar']/div[1]/a[2]")]
        [CacheLookup]
        public IWebElement CalandarMonthHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='mainCalendar']/table/tbody/tr[3]/td[3]/a")]
        [CacheLookup]
        public IWebElement CalanderSelectDate { get; set; }

        [FindsBy(How = How.Id, Using = "nextWeekButton")]
        [CacheLookup]
        public IWebElement NextWeekCalendar { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='schedulerUserList']/li[1]/span/label/span[2]")]
        [CacheLookup]
        public IWebElement SelectFirstSchedulerOnList { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[1]/td[3]")]
        [CacheLookup]
        public IWebElement ClickOnScheduler { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='appointment - menu_mn_active']")]
        [CacheLookup]
        public IWebElement CreateMeetingSchedulerBtn { get; set; }

        [FindsBy(How = How.Id, Using = "tabPageWaitingListContainer")]
        [CacheLookup]
        public IWebElement StandBySchedulerTab { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic-add-standby")]
        [CacheLookup]
        public IWebElement StanByCreate { get; set; }

        [FindsBy(How = How.ClassName, Using = "//*[@id='btnNewAppointment']/div/span[1]")]
        [CacheLookup]
        public IWebElement AvailbleTime_Btn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[1]/td[4]")]
        [CacheLookup]
        public IWebElement FirstCellToday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='standbyOptionsGridName']/div[2]/table/tbody/tr[1]/td[7]/a")]
        [CacheLookup]
        public IWebElement StanbyAppointmentBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridWaitList']/div[2]/div[1]/table/tbody/tr[1]/td[9]/a[3]")]
        [CacheLookup]
        public IWebElement StandbyAppointmentSelect { get; set; }

        [FindsBy(How = How.Id, Using = "btnClose")]
        [CacheLookup]
        public IWebElement StandbyAppointmentCancel { get; set; }

        public void DragAndDropTemporaryList() {
           // //Pages.PriceList_Page.PriceListFirstCodeName();;
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.ClosePatientTab.ClickOn();
            Thread.Sleep(500);
            EnterStandBySchedulerList();

            var schedulerRows = utility.TableCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            var schedulerCells = utility.TableDataCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            int numOfCellInRow = schedulerCells / schedulerRows;
            int currentRow = 1;
            for (int td = 1; td < schedulerCells;)
            {
                IWebElement singleCell = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[" + currentRow + "]/td[" + td + "]"));
                (new Actions(Browser.chromebDriver)).DoubleClick(singleCell).Perform();
                if (Pages.Home_Page.ErrorPopup.IsDisplayed("error popup"))
                {
                    Pages.Home_Page.ErrorPopup.ClickOn();
                    td++;
                    if (td == numOfCellInRow)
                    {
                        currentRow++;
                        td = 1;
                    }
                }
                else if (Pages.Meeting_Page.CancelMeeting.Displayed)
                {
                    break;
                }
            }
            if (Browser.Driver.FindElement(By.XPath("//*[@id='btnCreateAppointmentSave']")).GetAttribute("aria-disabled").Equals("true"))
            {
                //enter inside exist meeting
                Pages.Meeting_Page.CancelMeeting.ClickOn();
                dragAndDropWaitListAction();
            }
            else if (!Browser.Driver.FindElement(By.XPath("//*[@id='btnCreateAppointmentSave']")).GetAttribute("aria-disabled").Equals("true"))
            {
                Pages.Meeting_Page.CreateMeetingApplication();
                dragAndDropWaitListAction();
            }
        }

        public void DragAndDropStandbyList()
        {
            //Pages.PriceList_Page.PriceListFirstCodeName();;
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.ClosePatientTab.ClickOn();

            Thread.Sleep(500);
            EnterStandBySchedulerList();

            var schedulerRows = utility.TableCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            var schedulerCells = utility.TableDataCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            int numOfCellInRow = schedulerCells / schedulerRows;
            int currentRow = 1;
            var errorPop = Browser.Driver.FindElements(By.ClassName("ic_problem"));
        //    var popupClose = Browser.Driver.FindElements(By.ClassName("popup-close-button"));

            for (int td = 1; td < schedulerCells;)
            {
                IWebElement singleCell = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[" + currentRow + "]/td[" + td + "]"));
                (new Actions(Browser.chromebDriver)).DoubleClick(singleCell).Perform();
                Thread.Sleep(200);
                if (Pages.Home_Page.ErrorPopup.IsDisplayed("error popup"))
                {
                    Pages.Home_Page.ErrorPopup.ClickOn();
                    td++;
                    if (td == numOfCellInRow)
                    {
                        currentRow++;
                        td = 1;
                    }
                }
                else
                {
                    break;
                }
            }
            if (Browser.Driver.FindElement(By.XPath("//*[@id='btnCreateAppointmentSave']")).GetAttribute("aria-disabled").Equals("true"))
            {
                //enter inside exist meeting
                Pages.Meeting_Page.CancelMeeting.ClickOn();
                dragAndDropStandbyAction();
                
            }
            else if (!Browser.Driver.FindElement(By.XPath("//*[@id='btnCreateAppointmentSave']")).GetAttribute("aria-disabled").Equals("true"))
            {
                Pages.Meeting_Page.CreateMeetingApplication();
                dragAndDropStandbyAction();
            }
        }

        public void dragAndDropStandbyAction() {
            IWebElement drag = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/div[2]"));
            IWebElement drop = Browser.Driver.FindElement(By.XPath("//*[@id='waitListPanelBar']/li/div"));
            var CountBefore = utility.ListCount("//*[@id='wait-list']");
            (new Actions(Browser.chromebDriver)).ClickAndHold(drag).MoveToElement(drop).DragAndDrop(drag, drop).Perform();
            Pages.Standby_Page.StandbyEndDate.EnterClearText(Constant.datePlusMonth);
            Pages.Standby_Page.CreateStandby.ClickWait();
            var CountAfter = utility.ListCount("//*[@id='wait-list']");
            Assert.AreNotEqual(CountBefore, CountAfter);
        }

        public void dragAndDropWaitListAction() {
            IWebElement drag = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/div[2]"));
            IWebElement drop = Browser.Driver.FindElement(By.XPath("//*[@id='tempWaitListPanelBar']/li/div"));
            var CountBefore = utility.ListCount("//*[@id='temp-wait-list']");
            (new Actions(Browser.chromebDriver)).ClickAndHold(drag).MoveToElement(drop).DragAndDrop(drag, drop).Perform();
            Thread.Sleep(500);
            var CountAfter = utility.ListCount("//*[@id='temp-wait-list']");
            Assert.AreNotEqual(CountBefore, CountAfter);
        }

        public void StandbySetMeetingApplication() {
            Pages.Standby_Page.CreateStandbyApplication();
            Thread.Sleep(1500);
            Pages.Scheduler_Page.EnterStanbyWindow();
            StandbyAppointmentSelect.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(StandbyAppointmentCancel, StandbyAppointmentCancel);
            StanbyAppointmentBtn.ClickWait();
            softAssert.VerifyElementPresentInsideWindow(Pages.Meeting_Page.ApproveMeeting, Pages.Meeting_Page.CancelMeeting);
            Pages.Meeting_Page.PriceList.ClickOn();
            Pages.Meeting_Page.CodeSearch.SendKeys(Constant.priceListExistCode);
            Pages.Meeting_Page.ApproveMeeting.ClickOn();
            softAssert.VerifySuccessMsg();
            Pages.Home_Page.PopupClose.ClickOn();
        }

        public void EnterLateYear() {
            int yearCount = 0;
            //select the the 2099 year of calendar
            while (yearCount <= 4) {
                CalandarMonthHeader.ClickOn();
                yearCount++;
            }
            //select specific date
            CalanderSelectDate.ClickOn();
            CalanderSelectDate.ClickOn();
        }

        public void EnterDailyReportScreen() {

            SchedulerMenuList.ClickOn();
            IWebElement SchedulerList = Browser.Driver.FindElement(By.Id("schedulerHeaderMenu"));
            SchedulerList.FindElements(By.TagName("li")).ElementAt(0).ClickOn();
            softAssert.VerifyElementIsPresent(Pages.Reports_Page.PrintDailyMeetingWindow);
        }

        public void EnterCancelledMeetingWindow()
        {
            SchedulerMenuList.ClickOn();
            IWebElement SchedulerList = Browser.Driver.FindElement(By.Id("schedulerHeaderMenu"));
            SchedulerList.FindElements(By.TagName("li")).ElementAt(1).ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.CancelledMeeting_Page.CancelledMeetingSearch, Pages.CancelledMeeting_Page.CloseWindow);
        }

        public void EnterOpenBlockWindow()
        {
            SchedulerMenuList.ClickOn();
            IWebElement SchedulerList = Browser.Driver.FindElement(By.Id("schedulerHeaderMenu"));
            SchedulerList.FindElements(By.TagName("li")).ElementAt(2).ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.BlockOpen_Page.CreateNewSlot, Pages.BlockOpen_Page.CloseWindow);
        }

        public void EnterStanbyWindow()
        {
            SchedulerMenuList.ClickOn();
            IWebElement SchedulerList = Browser.Driver.FindElement(By.Id("schedulerHeaderMenu"));
            SchedulerList.FindElements(By.TagName("li")).ElementAt(3).ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.StandbyList_Page.CreateStandby, Pages.StandbyList_Page.CloseWindow);
        }

        public void EnterStandBySchedulerList() {
            Thread.Sleep(500);
            StandBySchedulerTab.ClickWait();
        }

        public void EnterAvailbleTime()
        {
            Thread.Sleep(500);
            AvailbleTime_Btn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.AvailbleTime_Page.SearchBtn, Pages.AvailbleTime_Page.CloseWindow);
        }
    }
}
