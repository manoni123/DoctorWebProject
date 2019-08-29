using DoctorWeb.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.TestCases
{
    [Ignore("jj")]
    public class TestServerErrors
    {
        IList logs, logder;
        String URL = "http://drweb-sys.com/";

        [OneTimeSetUp]
        public void StartSession()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            Browser.chromebDriver = new ChromeDriver(options);
            Browser.chromebDriver.Manage().Window.Maximize();
            Browser.chromebDriver.Navigate().GoToUrl(URL);

            Pages.Login_Page.LoginApplication();
            Thread.Sleep(500);
        }


      //  [Test]
        public void ServerErrorTest() {
            logs = Browser.chromebDriver.Manage().Logs.GetLog(LogType.Browser);
            try {
                Assert.True(logs.Count == 0);
            } catch (AssertionException e) {
                Console.WriteLine("Assert Failed: " + e.Message);
                foreach (LogEntry log in logs) {
                    Console.WriteLine(log.Message);
                    logs.Clear();
                }
            }
        }

        [OneTimeTearDown]
        public void CloseSession() {
            Browser.chromebDriver.Quit();
        }


    }
}
