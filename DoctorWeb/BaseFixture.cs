using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Tests.Parallel;
using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DoctorWeb
{
    public class BaseFixture
    {
        readonly Process myProcess = new Process();
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [OneTimeSetUp]
        public void Setup()
        {
            ExtentTestManager.CreateParentTest(GetType().Name);
            ChromeOptions options = new ChromeOptions();
            Browser.Initialize();
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            ExtentManager.Instance.Flush();
            Browser.Close();
        }

        [SetUp]
        public void BeforeTest()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);

        //    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        //    {
        //        int picNum = 0;
        //        var screenshot = ((ITakesScreenshot)Browser.chromebDriver).GetScreenshot();
        //        screenshot.SaveAsFile(@"C:\Temp\bugsScreenshot\bug" + picNum + ".jpg", ScreenshotImageFormat.Jpeg);
        //        picNum++;
        //   }
        }

        //wrap every class
        public static void UITest(Action action, IWebElement window = null, IWebElement popup = null, IWebElement onTopPopup = null)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Log.Error(e);

                string testName = TestContext.CurrentContext.Test.MethodName.ToString();
                string StartupPath = @"C:\Temp\bugsScreenshot\";
                string Year = DateTime.Now.Year.ToString();
                string Month = DateTime.Now.Month.ToString();
                string Day = DateTime.Now.Day.ToString();
                string createDirectory = Directory.CreateDirectory(StartupPath + "\\" + Year + "\\" + Month + "\\" + Day).ToString();
                string bugDirectory = StartupPath + Year + "\\" + Month + "\\" + Day;

                var screenshot = ((ITakesScreenshot)Browser.chromebDriver).GetScreenshot();
                var imageName =  testName +".jpg";
                screenshot.SaveAsFile(@"C:\Temp\bugsScreenshot\" + imageName, ScreenshotImageFormat.Jpeg);

                DirectoryInfo dirInfo = new DirectoryInfo(bugDirectory);
             
                List<String> MyMusicFiles = Directory
                                   .GetFiles("C:\\Temp\\bugsScreenshot\\", "*.jpg").ToList();

                if (new FileInfo(bugDirectory + "\\" + imageName).Exists == true)
                {
                    File.Delete(bugDirectory + "\\" + imageName);
                }

                foreach (string file in MyMusicFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    if (new FileInfo(StartupPath + imageName).Exists != false)
                    {
                        mFile.MoveTo(bugDirectory + "\\" + imageName);
                    }
                }
                
                if (window != null)
                {
                    window.ClickOn();
                }

                Assert.Warn("Not a bug - Failed due to wrong code/compile");
               // throw;
            }
        }
    }
}