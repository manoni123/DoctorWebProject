using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Home_Page
    {

        AssertionExtent softAssert = new AssertionExtent();

        private readonly ILog Log =
      LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.Id, Using = "btnNewAppointment")]
        [CacheLookup]
        public IWebElement AppointmentBtn_1 { get; set; }

        [FindsBy(How = How.Id, Using = "btnNewAppointment2")]
        [CacheLookup]
        public IWebElement AppointmentBtn_2 { get; set; }

        [FindsBy(How = How.Id, Using = "addNewCustomerContainer")]
        [CacheLookup]
        public IWebElement OpenEntityDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "windowPopup0")]
        [CacheLookup]
        public IWebElement BusinessSelectWindowOnPatientCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='windowPopup0']/div/div[2]/ul/li[0]")]
        [CacheLookup]
        public IWebElement SelectBusiness { get; set; }

        [FindsBy(How = How.Id, Using = "menuItemNewPatient")]
        [CacheLookup]
        public IWebElement CreateNewPatient { get; set; }

        [FindsBy(How = How.Id, Using = "menuItemNewSupplier")]
        [CacheLookup]
        public IWebElement CreateNewSupplier { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"menuItemNewContact\"]/span/span")]
        [CacheLookup]
        public IWebElement CreateNewContact { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainTabStrip > ul > li.k-item.k-state-default.k-tab-on-top.k-state-active > span.k-link > span.k-link > span")]
        [CacheLookup]
        public IWebElement CloseTab { get; set; }

        [FindsBy(How = How.Id, Using = "patientsAutoComplete")]
        [CacheLookup]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='homeNavItems']/li[1]")]
        [CacheLookup]
        public IWebElement SchedularScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#homeNavItems > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement SettingScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#homeNavItems > li:nth-child(3)")]
        [CacheLookup]
        public IWebElement ReportScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement UserManagementScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(3)")]
        [CacheLookup]
        public IWebElement UserAuthorizationScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(4)")]
        [CacheLookup]
        public IWebElement GeneralScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(4)")]
        [CacheLookup]
        public IWebElement DevPricelistScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(5)")]
        [CacheLookup]
        public IWebElement DevGeneralScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li.k-item.k-state-default.k-last")]
        [CacheLookup]
        public IWebElement AdminTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='/images/icons/ic-logout.svg']")]
        [CacheLookup]
        public IWebElement LockScreen { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        [CacheLookup]
        public IWebElement LockScreenPassword { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic-lock")]
        [CacheLookup]
        public IWebElement LockIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnUnLockScreen']")]
        [CacheLookup]
        public IWebElement LokcScreenEntryButton { get; set; }

        [FindsBy(How = How.Id, Using = "lockScreenError")]
        [CacheLookup]
        public IWebElement LokcScreenError { get; set; }

        [FindsBy(How = How.Id, Using = "user_context_menu_button")]
        [CacheLookup]
        public IWebElement ProfileList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"3\"]/span")]
        [CacheLookup]
        public IWebElement ChangePasswordScreen { get; set; }

        [FindsBy(How = How.Id, Using = "OldPassword")]
        [CacheLookup]
        public IWebElement OldPassword { get; set; }

        [FindsBy(How = How.Id, Using = "NewPassword")]
        [CacheLookup]
        public IWebElement NewPassword { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        [CacheLookup]
        public IWebElement ConfirmPassword { get; set; }

        [FindsBy(How = How.Id, Using = "changePassword")]
        [CacheLookup]
        public IWebElement changePasswordBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"2\"]/span")]
        [CacheLookup]
        public IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"1\"]/span")]
        [CacheLookup]
        public IWebElement ProfileButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic_ok")]
        [CacheLookup]
        public IWebElement SuccessPopup { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic_problem")]
        [CacheLookup]
        public IWebElement ErrorPopup { get; set; }

        [FindsBy(How = How.ClassName, Using = "popup-close-button")]
        [CacheLookup]
        public IWebElement PopupClose { get; set; }

        [FindsBy(How = How.Id, Using = "btnAdvancedCustomerFilter")]
        [CacheLookup]
        public IWebElement MainFilterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnResetFilter")]
        [CacheLookup]
        public IWebElement MainFilterReset { get; set; }

        [FindsBy(How = How.ClassName, Using = "k-overlay")]
        [CacheLookup]
        public IWebElement Overlay { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#frmAdvancedCustomerFilter > div > ul > li:nth-child(3) > label")]
        [CacheLookup]
        public IWebElement MainFilterPhoneBook { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement PopupButtonOk { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-cancel")]
        [CacheLookup]
        public IWebElement PopupButtonCancel { get; set; }

        [FindsBy(How = How.Id, Using = "toggleSidePanButton")]
        [CacheLookup]
        public IWebElement SidePannelBtn { get; set; }

        public void LogoutApplication() {
            Thread.Sleep(500);
            ProfileList.ClickOn();
            LogoutButton.ClickOn();
            var text = Environment.NewLine;
            Assert.IsTrue(Pages.Login_Page.LoginButton.Displayed);
        }

        public void LockApplication()
        {
            softAssert.VerifyElementIsPresent(LockScreen);
            LockScreen.ClickOn();
            softAssert.VerifyElementIsPresent(LockScreenPassword);
            LockScreenPassword.SendKeys(Constant.loginPassword);
            Thread.Sleep(500);
            LokcScreenEntryButton.ClickOn();
            softAssert.VerifyElementIsPresent(SchedularScreen);
        }

        public void ChangePassword() {
            ProfileList.ClickOn();
            ChangePasswordScreen.ClickOn();
            OldPassword.EnterClearText(Constant.groupUser);
            NewPassword.EnterClearText(Constant.loginPassword);
            ConfirmPassword.EnterClearText(Constant.loginPassword);
            changePasswordBtn.ClickOn();
        }

        public void EnterUserManagmentScreen() {
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreen.ClickWait();
            Pages.Home_Page.UserManagementScreen.ClickWait();
        }

        public void EntePriceListTab()
        {
            Pages.Home_Page.SettingScreen.ClickWait();
            Pages.Home_Page.DevPricelistScreen.ClickWait();
        }

        // blocked patient, normal patient with watch medical, patient w.o watch medical, edit patient, enter setting screen. 

        public void UnauthorizedCreatePatient()
        {
            OpenEntityDropdown.ClickOn();
            try
            {
                if (CreateNewPatient.IsDisplayed("patient create button"))
                {
                    Console.WriteLine("fail test");
                    Assert.Fail();
                }
                else {
                    Log.Info("create patient isnt availble - Pass test.");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        public void UnaothorizedEnterSettingScreen()
        {
            Thread.Sleep(500);
            try
            {
                if (ReportScreen.IsDisplayed("setting screen"))
                {
                    Console.WriteLine("fail test");
                    Assert.Fail();
                }
                else
                {
                    Log.Info("setting screen isnt availble - pass");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void UnaothorizedWatchBlockedPatient() {
            Thread.Sleep(500);
            SearchBox.EnterClearText(Pages.Patient_Page.PatientUseName);
            Thread.Sleep(500);
            String spanText = Browser.Driver.FindElement(By.XPath("//span[text()='אין הרשאה לצפות בפרטי המטופל !']")).ToString();
            Assert.AreEqual(spanText, "אין הרשאה לצפות בפרטי המטופל !");
        }
        public void EnterAvailbleTime()
        {
            Thread.Sleep(500);
            AppointmentBtn_1.ClickOn();
        }


        public void FilterImageApplication() {
            string filterImg = "http://drweb-sys.com//images/icons/ic-filter.svg";

            MainFilterBtn.ClickOn();
            MainFilterPhoneBook.ClickOn();
            Overlay.ClickOn();
            softAssert.VerifyElementHasEqual(filterImg, "http://drweb-sys.com//images/icons/ic-filter.svg");
        }

        public void RightBarApplication (){
            String closedBarArrow = "https://test.drweb-sys.com/images/icons/arrow-close-bar-left.svg";
          
            SidePannelBtn.ClickOn();
            LogoutApplication();
            Pages.Login_Page.LoginApplication();
            softAssert.VerifyElementHasEqual(closedBarArrow, "https://test.drweb-sys.com/images/icons/arrow-close-bar-left.svg");
            SidePannelBtn.ClickOn();
        }
    }
}
