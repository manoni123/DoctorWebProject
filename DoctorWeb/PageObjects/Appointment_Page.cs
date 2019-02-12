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
    public class Appointment_Page
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        AssertionExtent softAssert = new AssertionExtent();


        [FindsBy(How = How.CssSelector, Using = "#generalTabstrip > ul > li.k-item.k-state-default.k-last")]
        [CacheLookup]
        public IWebElement AppointmentReminderPage { get; set; }

        public void EnterCancelReason()
        {
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreen.ClickWait();
            Pages.Home_Page.GeneralScreen.ClickWait();
            AppointmentReminderPage.ClickOn();
        }

        public void AppointmentReminderApplication() {

        }
    }
}
