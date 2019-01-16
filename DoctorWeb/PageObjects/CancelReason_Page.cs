using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class CancelReason_Page
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         
        AssertionExtent softAssert = new AssertionExtent();


        [FindsBy(How = How.CssSelector, Using = "#generalTabstrip > ul > li:nth-child(6)")]
        [CacheLookup]
        public IWebElement CancelReasonPage { get; set; }

        [FindsBy(How = How.Id, Using = "btncancelAppointmentReasonCreateNew")]
        [CacheLookup]
        public IWebElement CreateNewCancelReason { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement CancelReasonName { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement ApprovePopup { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-cancel")]
        [CacheLookup]
        public IWebElement CancelPopup { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridCancelAppointmentReasons']/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement SaveCancelReason { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridCancelAppointmentReasons']/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement DropCancelReason { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridCancelAppointmentReasons']/div[2]/table/tbody/tr/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement EditCancelReason { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridCancelAppointmentReasons']/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement DeleteCancelReason { get; set; }

        public void EnterCancelReason() {
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreen.ClickWait(1500);
            Pages.Home_Page.GeneralScreen.ClickWait(2000);
            CancelReasonPage.ClickOn();
        }

        public void CreateCancelReasonApplication() {
            CreateNewCancelReason.ClickOn();
            SaveCancelReason.ClickOn();
            softAssert.VerifyErrorMsg();
            CreateNewCancelReason.ClickOn();
            CancelReasonName.SendKeys(Constant.CancelReason);
            SaveCancelReason.ClickOn();
        }

        public void EditCancelReasonApplicaiton() {
            EditCancelReason.ClickOn();
            CancelReasonName.Clear();
            SaveCancelReason.ClickOn();
            softAssert.VerifyErrorMsg();
            EditCancelReason.ClickOn();
            CancelReasonName.EnterClearText("Tester", "Test");
        }

        public void DeleteCancelReasonApplicaiton() {
            DeleteCancelReason.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(ApprovePopup, CancelPopup);
            ApprovePopup.ClickOn();
        }
    }
}
