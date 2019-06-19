using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DoctorWeb.Utility;
using NUnit.Framework;

namespace DoctorWeb.PageObjects
{
    public class MobileTherapist_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "mat-error-0")]
        [CacheLookup]
        public IWebElement EmailRequiredError { get; set; }

        [FindsBy(How = How.Id, Using = "mat-error-2")]
        [CacheLookup]
        public IWebElement InvalidPasswordError { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='app']/app-login/mat-sidenav-container/mat-sidenav-content/div/form/div/p/a/span")]
        [CacheLookup]
        public IWebElement ForgotPasswordBtn { get; set; }

        [FindsBy(How = How.Id, Using = "mat-input-2")]
        [CacheLookup]
        public IWebElement ForgottenPasswordEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mat-input-0")]
        [CacheLookup]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mat-input-1")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/app-login/mat-sidenav-container/mat-sidenav-content/div/form/div/button")]
        [CacheLookup]
        public IWebElement Enter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/header/mat-toolbar/mat-toolbar-row[1]/app-main-menu/button/span/mat-icon")]
        [CacheLookup]
        public IWebElement ScreenMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk - overlay - 0']/div/div/button[1]")]
        [CacheLookup]
        public IWebElement SchedulerBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk - overlay - 0']/div/div/button[2]")]
        [CacheLookup]
        public IWebElement SearchPatientBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk - overlay - 0']/div/div/button[3]")]
        [CacheLookup]
        public IWebElement LogoutBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/app-scheduler/mat-card/mat-card-content/div/app-appointment[1]/div/div[1]/app-appointment-menu/button/span/mat-icon")]
        [CacheLookup]
        public IWebElement FirstMeetingList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk - overlay - 2']/div/div/button[1]")]
        [CacheLookup]
        public IWebElement MeetingDetails { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk - overlay - 2']/div/div/button[7]")]
        [CacheLookup]
        public IWebElement PatientDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main > app-find-time > div > div > form > div:nth-child(11) > div > button:nth-child(2)")]
        [CacheLookup]
        public IWebElement CancelAvailbleTime { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main > app-find-time > div > div > form > div:nth-child(11) > div > button.mat-elevation-z6.ml-3.mat-raised-button.mat-accent")]
        [CacheLookup]
        public IWebElement ApproveAvailbleTime { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mat-input-14")]
        [CacheLookup]
        public IWebElement PatientSearch { get; set; }


        public void MobileLogin() {
            Email.EnterText(Constant.testUser);
            Password.EnterText(Constant.loginPassword);
            Enter.ClickWait();
        }

        public void MobileLogout() {
            ScreenMenu.ClickOn();
            LogoutBtn.ClickOn();
        }

        public void TestTest() {
            //nothing
        }
    }
}
