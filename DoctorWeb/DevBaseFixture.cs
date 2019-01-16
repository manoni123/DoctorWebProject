using System.Diagnostics;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Tests.Parallel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace DoctorWeb
{
    public class DevBaseFixture
    {
        readonly Process myProcess = new Process();

        [OneTimeSetUp]
        public void Setup()
        {
            ExtentTestManager.CreateParentTest(GetType().Name);
            DevBrowser.Initialize();
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            ExtentManager.Instance.Flush();
            DevBrowser.Close();
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
        }
    }
}