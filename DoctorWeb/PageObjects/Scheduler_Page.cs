﻿using DoctorWeb.Utility;
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
        
        public IWebElement SchedulerMenuList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#schedulerHeaderMenu_mn_active > span")]
        
        public IWebElement DailyReportWindow { get; set; }

        [FindsBy(How = How.Id, Using = "btnSchedulerEventsPrint_Closeancel")]
        
        public IWebElement SchedulerEventPrintCancel { get; set; }

        [FindsBy(How = How.LinkText, Using = "דוח פגישות מבוטלות")]
        
        public IWebElement CancelledMeetingWindow { get; set; }

        [FindsBy(How = How.LinkText, Using = "רשימת פתיחות וחסימות")]
        
        public IWebElement OpenBlockWindow { get; set; }

        [FindsBy(How = How.LinkText, Using = "רשימת סטנד ביי")]
        
        public IWebElement StandbyWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='schedulerHeader']/span[3]/span")]
        
        public IWebElement CalendarBranchList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='mainCalendar']/div[1]/a[2]")]
        
        public IWebElement CalandarMonthHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='mainCalendar']/table/tbody/tr[3]/td[3]/a")]
        
        public IWebElement CalanderSelectDate { get; set; }

        [FindsBy(How = How.Id, Using = "nextWeekButton")]
        
        public IWebElement NextWeekCalendar { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='schedulerUserList']/li[1]/span/label/span[2]")]
        
        public IWebElement SelectFirstSchedulerOnList { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[1]/td[3]")]
        
        public IWebElement ClickOnScheduler { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='appointment - menu_mn_active']")]
        
        public IWebElement CreateMeetingSchedulerBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic-add-standby")]
        
        public IWebElement StanByCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnNewAppointment']/div/span[1]")]
        
        public IWebElement AvailbleTime_Btn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[1]/td[4]")]
        
        public IWebElement FirstCellToday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='standbyOptionsGridName']/div[2]/table/tbody/tr[1]/td[7]/a")]
        
        public IWebElement StanbyAppointmentBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridWaitList']/div[2]/div[1]/table/tbody/tr[1]/td[9]/a[3]")]
        
        public IWebElement StandbyAppointmentSelect { get; set; }

        [FindsBy(How = How.Id, Using = "btnClose")]
        
        public IWebElement StandbyAppointmentCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#gridWaitList > div.k-grid-content.k-auto-scrollable > div.k-virtual-scrollable-wrap > table > tbody > tr:nth-child(1) > td.text-align-center.k-command-cell > a.k-button.k-button-icontext.k-grid-CreateAppoiintment.k-button.btn-red-white-toolbox.k-state-disabled")]
        public IWebElement DisabledSetMeetingBtn { get; set; }

        public static By AvailbleTimeBtn = By.XPath("//*[@id='btnNewAppointment']/div/span[1]");
        public static By StandbySchedulerTab = By.Id("tabPageWaitingListContainer");

        public void GoTo() {
            Pages.Home_Page.EnterSchedulerWindow();
            softAssert.VerifyElementIsPresent(SchedulerMenuList);
        }

        public void DragAndDropTemporaryList() {
           // //Pages.PriceList_Page.PriceListFirstCodeName();;
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.ClosePatientTab.ClickOn();
            Thread.Sleep(500);
            EnterStandBySchedulerList();
            Constant.tmpListCount = utility.ListCount("//*[@id='temp-wait-list']");
            var test = Browser.Driver.FindElement(By.XPath("//*[@id='tempWaitListPanelBar']/li/span/span[3]")).Text;
            var schedulerRows = utility.TableCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            var schedulerCells = utility.TableDataCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            int numOfCellInRow = schedulerCells / schedulerRows;
            int currentRow = 1;
            for (int td = 1; td < schedulerCells;)
            {
            IWebElement singleCell = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[" + currentRow + "]/td[" + td + "]"));
            (new Actions(Browser.chromebDriver)).DoubleClick(singleCell).Perform();
            Thread.Sleep(500);
                if (Pages.Home_Page.ErrorPopup.IsDisplayed("error popup"))
                {
                    //  Pages.Home_Page.ErrorPopup.ClickOn();
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
            Constant.tmpListCount = utility.ListCount("//*[@id='wait-list']");
            Thread.Sleep(500);
            EnterStandBySchedulerList();

            var schedulerRows = utility.TableCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            var schedulerCells = utility.TableDataCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            int numOfCellInRow = schedulerCells / schedulerRows;
            int currentRow = 1;
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
                Thread.Sleep(1000);
                dragAndDropStandbyAction();
            }
        }

        public void dragAndDropStandbyAction() {
            IWebElement drag = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/div[2]"));
            Thread.Sleep(500);
            IWebElement drop = Browser.Driver.FindElement(By.XPath("//*[@id='waitListPanelBar']/li/div"));
            Thread.Sleep(500);
            (new Actions(Browser.chromebDriver)).ClickAndHold(drag).MoveToElement(drop).DragAndDrop(drag, drop).Perform();
            Thread.Sleep(1500);
            Pages.Standby_Page.StandbyEndDate.EnterClearText(Constant.datePlusMonth);
            Pages.Standby_Page.CreateStandby.ClickWait();
            softAssert.VerifyElementHasEqual(utility.ListCount("//*[@id='wait-list']"), Constant.tmpListCount + 1);
        }

        public void dragAndDropWaitListAction() {
            IWebElement drag = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/div[2]"));
            Thread.Sleep(500);
            IWebElement drop = Browser.Driver.FindElement(By.XPath("//*[@id='tempWaitListPanelBar']/li/div"));
            Thread.Sleep(500);
            (new Actions(Browser.chromebDriver)).ClickAndHold(drag).MoveToElement(drop).DragAndDrop(drag, drop).Perform();
            Thread.Sleep(1500);
            softAssert.VerifyElementHasEqual(utility.ListCount("//*[@id='temp-wait-list']"), Constant.tmpListCount + 1);
        }

        public void StandbySetMeetingApplication()
        {
            Pages.Standby_Page.CreateStandbyApplication();
            Thread.Sleep(1500);
            Pages.Scheduler_Page.EnterStanbyWindow();
            StandbyAppointmentSelect.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(StandbyAppointmentCancel, StandbyAppointmentCancel);
            StanbyAppointmentBtn.ClickWait();
            softAssert.VerifyElementPresentInsideWindow(Pages.Meeting_Page.ApproveMeeting, Pages.Meeting_Page.CancelMeeting);
            Pages.Meeting_Page.ApproveMeeting.ClickWait();
            softAssert.VerifySuccessMsg();
            Pages.Home_Page.PopupCloseClass.ClickOn();
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
            Browser.chromebDriver.FindElement(StandbySchedulerTab).ClickOn();
            Constant.tmpListCount = utility.ListCount(Pages.Standby_Page.standbyListCount);
        }
    }
}
