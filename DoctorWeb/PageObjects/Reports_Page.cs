using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class Reports_Page
    {
         
        public static String downloadPath = "D:\\seleniumdownloads";
        AssertionExtent softAssert = new AssertionExtent();

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.Id, Using = "btnToShow")]
        [CacheLookup]
        public IWebElement PatientReportShow { get; set; }

        [FindsBy(How = How.Id, Using = "CreateCustomerDateFrom")]
        [CacheLookup]
        public IWebElement PatientReportFromDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab2_gridCustomersResult\"]/div[2]/div[1]/table/tbody/tr[1]/td[1]")]
        [CacheLookup]
        public IWebElement ClickFirstPatient { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'שם פרטי')]")]
        [CacheLookup]
        public IWebElement PatientOutputName { get; set; }

        [FindsBy(How = How.Id, Using = "btnToExcel")]
        [CacheLookup]
        public IWebElement PatientReportExcel { get; set; }

        [FindsBy(How = How.Id, Using = "btnToPDF")]
        [CacheLookup]
        public IWebElement PatientReportPdf { get; set; }

        [FindsBy(How = How.Id, Using = "btnExportContactsToShow")]
        [CacheLookup]
        public IWebElement ContactReportShow { get; set; }

        [FindsBy(How = How.Id, Using = "btnExportContactsToPDF")]
        [CacheLookup]
        public IWebElement ContactReportPDF { get; set; }

        [FindsBy(How = How.Id, Using = "btnExportContactsToExcel")]
        [CacheLookup]
        public IWebElement ContactReportExcel { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'שם')]")]
        [CacheLookup]
        public IWebElement ContactOutputName { get; set; }

        [FindsBy(How = How.Id, Using = "btnToShow_SE")]
        [CacheLookup]
        public IWebElement MeetingReportShow { get; set; }

        [FindsBy(How = How.Id, Using = "btnToShow_SE")]
        [CacheLookup]
        public IWebElement MeetingReportPdf { get; set; }

        [FindsBy(How = How.Id, Using = "btnToShow_SE")]
        [CacheLookup]
        public IWebElement MeetingReportExcel { get; set; }

        [FindsBy(How = How.Id, Using = "DateFrom")]
        [CacheLookup]
        public IWebElement MeetingReportDateFrom { get; set; }

        [FindsBy(How = How.Id, Using = "btnToShow_UsersActions")]
        [CacheLookup]
        public IWebElement ShowAuditReport { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reportsTabstrip > ul > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement BuiltinReport { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='builtInReports_SubMenu_TabStrip']/ul/li[2]")]
        [CacheLookup]
        public IWebElement PatientReportTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='builtInReports_SubMenu_TabStrip']/ul/li[3]")]
        [CacheLookup]
        public IWebElement ContactReportTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='reportsTabstrip']/ul/li[2]")]
        [CacheLookup]
        public IWebElement ContactReportTabProd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='builtInReports_SubMenu_TabStrip']/ul/li[4]")]
        [CacheLookup]
        public IWebElement MeetingReportTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='reportsTabstrip']/ul/li[3]")]
        [CacheLookup]
        public IWebElement MeetingReportTabProd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='builtInReports_SubMenu_TabStrip']/ul/li[5]")]
        [CacheLookup]
        public IWebElement NotificationReportTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='reportsTabstrip']/ul/li[4]")]
        [CacheLookup]
        public IWebElement NotificationReportTabProd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='builtInReports_SubMenu_TabStrip']/ul/li[6]")]
        [CacheLookup]
        public IWebElement AuditReportTab { get; set; }

        [FindsBy(How = How.Id, Using = "btnPrintSchedulerEvents")]
        [CacheLookup]
        public IWebElement PrintDailyMeetingWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'שם משפחה)]")]
        [CacheLookup]
        public IWebElement MeetingReportOutput { get; set; }

        [FindsBy(How = How.Id, Using = "btnToPDF_Notificaions")]
        [CacheLookup]
        public IWebElement NotificationReportPDF { get; set; }

        [FindsBy(How = How.Id, Using = "btnToExcel_Notificaions")]
        [CacheLookup]
        public IWebElement NotificationReportExcel { get; set; }

        [FindsBy(How = How.Id, Using = "btnToShow_Notificaions")]
        [CacheLookup]
        public IWebElement NotficationReportShow { get; set; }

        [FindsBy(How = How.Id, Using = "NotificationDateFrom")]
        [CacheLookup]
        public IWebElement NotificationDateFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'ת.שליחה')]")]
        [CacheLookup]
        public IWebElement NotificationOutput { get; set; }

        [FindsBy(How = How.ClassName, Using = "error-notification")]
        [CacheLookup]
        public IWebElement ErrorToast { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainDetails > div > div > div > div:nth-child(1) > span:nth-child(3) > span > span")]
        [CacheLookup]
        public IWebElement CreateCustomerDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='popup-btn-OK']")]
        [CacheLookup]
        public IWebElement PopupButton { get; set; }

        public void EnterReportScreenProd()
        {
            Thread.Sleep(500);
            Pages.Home_Page.ReportScreenProd.ClickWait();
        }

        public void EnterReportScreen() {
            Thread.Sleep(500);
            Pages.Home_Page.ReportScreen.ClickWait();
            Pages.Reports_Page.BuiltinReport.ClickWait();
        }

        public void PatientReportApplication()
        {
            Thread.Sleep(500);
            PatientReportTab.ClickOn();
            PatientReportFromDate.EnterClearText(Constant.dateMinusMonth);
            PatientReportExcel.ClickOn();
            PatientReportShow.ClickWait();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.XPath("popup-btn-OK")).ClickOn();
            } else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
        }

        public void PatientReportApplicationProd()
        {
            Thread.Sleep(500);
            PatientReportFromDate.EnterClearText(Constant.dateMinusMonth);
            PatientReportExcel.ClickOn();
            PatientReportShow.ClickWait();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.XPath("popup-btn-OK")).ClickOn();
            } else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
        }

        public void ContactReportApplication()
        {
            Thread.Sleep(500);
            ContactReportTab.ClickOn();
            ContactReportExcel.ClickOn();
            ContactReportShow.ClickWait();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.XPath("popup-btn-OK")).ClickOn();
            }
            else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
            else {
                softAssert.VerifyElementIsPresent(ContactOutputName);
            }
        }

        public void ContactReportApplicationProd()
        {
            Thread.Sleep(500);
            ContactReportTabProd.ClickOn();
            ContactReportExcel.ClickOn();
            ContactReportShow.ClickOn();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.XPath("popup-btn-OK")).ClickOn();
            }
            else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
            else {
                Thread.Sleep(500);
                softAssert.VerifyElementIsPresent(ContactOutputName);
            }
        }

        public void MeetingReportApplication()
        {
            Thread.Sleep(500);
            MeetingReportTab.ClickWait();
            MeetingReportDateFrom.EnterClearText(Constant.dateMinusMonth);
            MeetingReportExcel.ClickOn();
            MeetingReportShow.ClickOn();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.Id("popup-btn-OK")).ClickOn();
            } else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
            else {
                softAssert.VerifyElementIsPresent(MeetingReportOutput);
            }
        }

        public void MeetingReportApplicationProd()
        {
            Thread.Sleep(500);
            MeetingReportTab.ClickWait();
            MeetingReportDateFrom.EnterClearText(Constant.dateMinusMonth);
            MeetingReportExcel.ClickOn();
            MeetingReportShow.ClickOn();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.Id("popup-btn-OK")).ClickOn();
            } else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
            else
            {
                softAssert.VerifyElementIsPresent(MeetingReportOutput);
            }
        }

        public void NotificationReportApplication()
        {
            Thread.Sleep(500);
            NotificationReportTab.ClickOn();
            NotificationDateFrom.EnterClearText(Constant.dateMinusMonth);
            NotificationReportExcel.ClickOn();
            NotficationReportShow.ClickOn();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.Id("popup-btn-OK")).ClickOn();
            } else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
        }

        public void NotificationReportApplicationProd()
        {
            Thread.Sleep(500);
            NotificationReportTabProd.ClickOn();
            NotificationDateFrom.EnterClearText(Constant.dateMinusMonth);
            NotificationReportExcel.ClickOn();
            NotficationReportShow.ClickOn();
            if (Browser.chromebDriver.PageSource.Contains("popup-message"))
            {
                Browser.Driver.FindElement(By.Id("popup-btn-OK")).ClickOn();
            } else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
        }

        public void AuditReportApplication()
        {
            Thread.Sleep(500);
            AuditReportTab.ClickOn();
            ShowAuditReport.ClickOn();
            if (Pages.Home_Page.CloseTab.Displayed)
            {
                Pages.Home_Page.CloseTab.ClickOn();
            } else if (Browser.chromebDriver.PageSource.Contains("btnCancelSendAuditReportToEmail"))
            {
                Browser.Driver.FindElement(By.Id("btnCancelSendAuditReportToEmail")).ClickOn();
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                Browser.Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }  
}
