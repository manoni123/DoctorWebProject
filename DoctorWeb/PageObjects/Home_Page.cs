using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Home_Page
    {

        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        private readonly ILog Log =
      LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.Id, Using = "btnNewAppointment")]
        
        public IWebElement AppointmentBtn_1 { get; set; }

        [FindsBy(How = How.Id, Using = "btnNewAppointment2")]
        
        public IWebElement AppointmentBtn_2 { get; set; }

        [FindsBy(How = How.Id, Using = "addNewCustomerContainer")]
        
        public IWebElement OpenEntityDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "windowPopup0")]
        
        public IWebElement BusinessSelectWindowOnPatientCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='windowPopup0']/div/div[2]/ul/li[0]")]
        
        public IWebElement SelectBusiness { get; set; }

        [FindsBy(How = How.Id, Using = "menuItemNewPatient")]
        
        public IWebElement CreateNewPatient { get; set; }

        [FindsBy(How = How.Id, Using = "menuItemNewSupplier")]
        public IWebElement CreateNewSupplier { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"menuItemNewContact\"]/span/span")]
        public IWebElement CreateNewContact { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainTabStrip > ul > li.k-item.k-state-default.k-tab-on-top.k-state-active > span.k-link > span.k-link > span")]
        public IWebElement CloseTab { get; set; }

        [FindsBy(How = How.Id, Using = "patientsAutoComplete")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='homeNavItems']/li[1]")]
        public IWebElement SchedularScreen { get; set; }

        [FindsBy(How = How.Id, Using = "btnSettings")]       
        public IWebElement SettingScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#homeNavItems > li:nth-child(2)")]   
        public IWebElement SettingScreenProd { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#homeNavItems > li:nth-child(2)")]
        public IWebElement ReportScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#homeNavItems > li:nth-child(3)")]
        public IWebElement ReportScreenProd { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#homeNavItems > li:nth-child(3)")]
        public IWebElement FormsScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(2)")]
        public IWebElement UserManagementScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(3)")]
        public IWebElement UserAuthorizationScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(4)")]
        public IWebElement GeneralScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li:nth-child(4)")]     
        public IWebElement DevPricelistScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#settingsTabstrip > ul > li.k-item.k-state-default.k-last")]
        public IWebElement AdminTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='/images/icons/ic-logout.svg']")]
        public IWebElement LockScreen { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement LockScreenPassword { get; set; }

        [FindsBy(How = How.Id, Using = "logout")]
        public IWebElement LockScreenExit { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic-lock")]
        public IWebElement LockIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnUnLockScreen']")]
        public IWebElement LokcScreenEntryButton { get; set; }

        [FindsBy(How = How.Id, Using = "lockScreenError")]
        public IWebElement LokcScreenError { get; set; }

        [FindsBy(How = How.Id, Using = "user_context_menu_button")]
        public IWebElement ProfileList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"3\"]/span")]
        public IWebElement ChangePasswordScreen { get; set; }

        [FindsBy(How = How.Id, Using = "OldPassword")]
        public IWebElement OldPassword { get; set; }

        [FindsBy(How = How.Id, Using = "NewPassword")]
        public IWebElement NewPassword { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPassword { get; set; }

        [FindsBy(How = How.Id, Using = "changePassword")]
        public IWebElement changePasswordBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"2\"]/span")]
        public IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"1\"]/span")]
        public IWebElement ProfileButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic_ok")]
        public IWebElement SuccessPopup { get; set; }

        [FindsBy(How = How.ClassName, Using = "ic_problem")]       
        public IWebElement ErrorPopup { get; set; }

        [FindsBy(How = How.LinkText, Using = "X")]
        public IWebElement PopupClose { get; set; }

        [FindsBy(How = How.ClassName, Using = "popup-close-button")]        
        public IWebElement PopupCloseClass { get; set; }

        [FindsBy(How = How.Id, Using = "btnAdvancedCustomerFilter")]     
        public IWebElement MainFilterBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnResetFilter")]      
        public IWebElement MainFilterReset { get; set; }

        [FindsBy(How = How.ClassName, Using = "k-overlay")]
        public IWebElement Overlay { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#frmAdvancedCustomerFilter > div > ul > li:nth-child(3) > label")]
        public IWebElement MainFilterPhoneBook { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]      
        public IWebElement PopupButtonOk { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-cancel")]     
        public IWebElement PopupButtonCancel { get; set; }

        [FindsBy(How = How.Id, Using = "toggleSidePanButton")]
        public IWebElement SidePannelBtn { get; set; }

        public static By SettingButton = By.Id("btnSettings");
        public static By DevGeneralScreen = By.CssSelector("#settingsTabstrip > ul > li:nth-child(5)");
        public static By DevPriceListScreen = By.CssSelector("#settingsTabstrip > ul > li:nth-child(4)");
        public static By SystemTabs = By.XPath("//*[@id='mainTabStrip']/ul");
        public string MainTabs = "//*[@id='mainTabStrip']/ul";

        public void LogoutApplication() {
            int selectEnviornment = Constant.VersionNumber;
            switch (selectEnviornment)
            {
                case 1:
                    Thread.Sleep(500);
                    ProfileList.ClickOn();
                    LogoutButton.ClickOn();
                    Assert.IsTrue(Pages.Login_Page.LoginButton.Displayed);
                    break;

                case 2:
                    Thread.Sleep(500);
                    ProfileList.ClickOn();
                    LogoutButton.ClickOn();
                    Assert.IsTrue(Pages.Login_Page.LoginButton.Displayed);
                    break;

                case 3:
                    Thread.Sleep(500);
                    Pages.MobileTherapist_Page.MobileLogout();
                    break;

                case 4:
                    Thread.Sleep(500);
                    ProfileList.ClickOn();
                    LogoutButton.ClickOn();
                    Assert.IsTrue(Pages.Login_Page.LoginButton.Displayed);
                    break;
            }
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

        public void EnterSchedulerWindow()
        {
            Browser.chromebDriver.WaitFindElement(SchedularScreen);
         //   SchedularScreen.ClickWait();
        }

        public void EnterSettingScreen()
        {
            Browser.chromebDriver.FindElement(SettingButton).ClickWait();
        }

        public void EnterUserManagmentScreen() {
            Thread.Sleep(500);
            EnterSettingScreen();
            Browser.chromebDriver.FindElement(By.CssSelector("#settingsTabstrip > ul > li:nth-child(2)")).ClickOn();
         //   UserManagementScreen.ClickWait();
            softAssert.VerifyElementIsPresent(Pages.UsersManagement_Page.PracticesManagerButton);
        }

        public void EnterUserManagmentScreenProd()
        {
            Thread.Sleep(500);
            SettingScreenProd.ClickWait();
            UserManagementScreen.ClickWait();
        }

        public void EnterPermissionScreen() {
            EnterSettingScreen();
            UserAuthorizationScreen.ClickOn();
            softAssert.VerifyElementIsPresent(Pages.Authorization_Page.GroupCreate);
        }

        public void EnterGeneralScreen()
        {
            EnterSettingScreen();
            Browser.chromebDriver.FindElement(DevGeneralScreen, 500).ClickOn();
        }

        public void EntePriceListTab()
        {
            EnterSettingScreen();
            Browser.chromebDriver.FindElement(DevPriceListScreen).ClickOn();
            Constant.tmpTableCount = utility.TableCount(Pages.PriceList_Page.priceListTableCount);
            Constant.priceListExistCode = utility.ElementText(Pages.PriceList_Page.priceListFirstCode);
        }

        // blocked patient, normal patient with watch medical, patient w.o watch medical, edit patient, enter setting screen. 

        public void UnauthorizedCreatePatient()
        {
            OpenEntityDropdown.ClickOn();
            if (CreateNewPatient.IsDisplayed("patient create button"))
            {
                Console.WriteLine("fail test");
                Assert.Fail();
            }
            else {
                Log.Info("create patient isnt availble - Pass test.");
            }

        }
        public void UnaothorizedEnterSettingScreen()
        {
            Thread.Sleep(500);
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
        public void UnaothorizedWatchBlockedPatient() {
            Thread.Sleep(500);
            SearchBox.EnterClearText(Pages.Patient_Page.PatientUseName);
            Thread.Sleep(500);
            String spanText = Browser.Driver.FindElement(By.XPath("//span[text()='אין הרשאה לצפות בפרטי המטופל !']")).ToString();
            Assert.AreEqual(spanText, "אין הרשאה לצפות בפרטי המטופל !");
        }

        public void FilterImageApplication() {
            MainFilterBtn.ClickOn();
            MainFilterPhoneBook.ClickOn();
            Overlay.ClickOn();
            softAssert.VerifyElementHasEqual(Constant.filterImg, "http://drweb-sys.com//images/icons/ic-filter.svg");
        }

        public void RightBarApplication() {
            SidePannelBtn.ClickOn();
            LogoutApplication();
            Pages.Login_Page.LoginApplication();
            softAssert.VerifyElementHasEqual(Constant.closedBarArrow, "https://test.drweb-sys.com/images/icons/arrow-close-bar-left.svg");
            SidePannelBtn.ClickOn();
        }

        public int OpenTabsCount()
        {
            int tabCount = Browser.chromebDriver.FindElements(SystemTabs).Count();
            return tabCount;
        }
    }
}
