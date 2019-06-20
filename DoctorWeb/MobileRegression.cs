using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace DoctorWeb
{
    public class MobileRegression : BaseFixture
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly AssertionExtent softAssert = new AssertionExtent();
        public UtilityFunction utility = new UtilityFunction();

        [SetUp]
        public void LoginBeforeEachTest()
        {
            Log.Info(Environment.NewLine + Environment.NewLine + "##### " + TestContext.CurrentContext.Test.MethodName + " #####" + Environment.NewLine);
            Pages.Login_Page.LoginApplication();
        }

        [TearDown]
        public void LogoutAfterEachTest()
        {
            Pages.Home_Page.LogoutApplication();
        }

        [Test]
        public void Testytestss() {
            Pages.MobileTherapist_Page.TestTest();
        }
    }
}
