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

        [FindsBy(How = How.CssSelector, Using = "#reportsTabstrip > ul > li.k-item.k-state-default.k-first")]
        [CacheLookup]
        public IWebElement PatientReportTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reportsTabstrip > ul > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement ContactReportTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reportsTabstrip > ul > li:nth-child(3)")]
        [CacheLookup]
        public IWebElement MeetingReportTab { get; set; }

        [FindsBy(How = How.Id, Using = "btnPrintSchedulerEvents")]
        [CacheLookup]
        public IWebElement PrintDailyMeetingWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'ת.יצירה)]")]
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

        [FindsBy(How = How.CssSelector, Using = "#reportsTabstrip > ul > li:nth-child(4)")]
        [CacheLookup]
        public IWebElement NotificationReportTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reportsTabstrip > ul > li.k-item.k-state-default.k-last")]
        [CacheLookup]
        public IWebElement AuditReportTab { get; set; }

        [FindsBy(How = How.ClassName, Using = "error-notification")]
        [CacheLookup]
        public IWebElement ErrorToast { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainDetails > div > div > div > div:nth-child(1) > span:nth-child(3) > span > span")]
        [CacheLookup]
        public IWebElement CreateCustomerDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='popup-btn-OK']")]
        [CacheLookup]
        public IWebElement PopupButton { get; set; }


        public void EnterReportScreen() {
            Thread.Sleep(500);
            Pages.Home_Page.ReportScreen.ClickWait();
        }

        public void PatientReportApplication()
        {
            var tabs = Browser.chromebDriver.WindowHandles;

            Thread.Sleep(500);
            PatientReportFromDate.EnterClearText(Constant.dateMinusMonth);

            try
            {
                PatientReportExcel.ClickOn();
             //   PatientReportPdf.ClickWait(2000);
                PatientReportShow.ClickWait();
                softAssert.VerifyElementIsPresent(PatientOutputName);

            } catch(Exception) {
                PopupButton.ClickOn();
            }
        } 
        public void ContactReportApplication()
        {
            Thread.Sleep(500);
            ContactReportTab.ClickOn();
            try
            {
                ContactReportExcel.ClickOn();
       //         ContactReportPDF.ClickWait(2000);
                ContactReportShow.ClickOn();
                Thread.Sleep(500);
                softAssert.VerifyElementIsPresent(ContactOutputName);
            }
            catch (Exception)
            {
                PopupButton.ClickOn();
            }
        }

        public void MeetingReportApplication()
        {
            var tabs = Browser.chromebDriver.WindowHandles;

            Thread.Sleep(500);
            MeetingReportTab.ClickOn();
            MeetingReportDateFrom.EnterClearText(Constant.dateMinusMonth);
            try
            {
                MeetingReportExcel.ClickOn();
        //        MeetingReportPdf.ClickWait(2000);
                MeetingReportShow.ClickOn();
                softAssert.VerifyElementIsPresent(MeetingReportOutput);

                if (tabs.Count > 1)
                {
                    Browser.chromebDriver.SwitchTo().Window(tabs[1]);
                    Browser.chromebDriver.Close();
                    Browser.chromebDriver.SwitchTo().Window(tabs[0]);
                }
            }
            catch (Exception)
            {
                PopupButton.ClickOn();
            }
        }

        public void NotificationReportApplication()
        {
            Thread.Sleep(500);
            NotificationReportTab.ClickOn();
            NotificationDateFrom.EnterClearText(Constant.dateMinusMonth);
            try
            {
                NotificationReportExcel.ClickOn();
         //       NotificationReportPDF.ClickWait(2000);
                NotficationReportShow.ClickOn();
                softAssert.VerifyElementIsPresent(NotificationOutput);
            }
            catch (Exception)
            {
                PopupButton.ClickOn();
            }
        }

        public void AuditReportApplication()
        {
            try
            {
                Thread.Sleep(500);
                AuditReportTab.ClickOn();
                ShowAuditReport.ClickOn();
                if (Pages.Home_Page.CloseTab.Displayed)
                {
                    Pages.Home_Page.CloseTab.ClickOn();
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception)
            {

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
