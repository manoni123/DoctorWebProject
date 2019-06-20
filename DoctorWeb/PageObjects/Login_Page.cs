using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Login_Page
    {
        protected static readonly ILog Log = LogManager.GetLogger(typeof(Login_Page));
        AssertionExtent softAssert = new AssertionExtent();


        [FindsBy(How = How.Id, Using = "SelectedLanguageName")]
        [CacheLookup]
        public IWebElement LanguageSelect { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        [CacheLookup]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='loginForm']/div[2]/div[4]/div/p/button")]
        [CacheLookup]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnNewAppointment")]
        [CacheLookup]
        public IWebElement NewAppointment { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='toggleSidePanButton']")]
        [CacheLookup]
        public IWebElement SideBarArrow { get; set; }

        //Login Form credentials
        public void LoginApplication()
        {
            int selectEnviornment = Constant.VersionNumber;
            switch (selectEnviornment)
            {
                case 1:
                    LanguageSelect.SendKeys(Keys.ArrowDown);
                    UserName.EnterText(Constant.testUser);
                    UserPassword.EnterText(Constant.prodPassword);
                    Thread.Sleep(500);
                    Browser.Driver.FindElement(By.XPath("//*[@id='loginForm']/div[2]/div[4]/div/p/button")).ClickOn();
                    Thread.Sleep(1500);
                    if (Pages.Home_Page.AppointmentBtn_1.Displayed)
                    {
                        //nothing
                    }
                    else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
                    {
                        SideBarArrow.ClickOn();
                    }
                    break;
                case 2:
                    LanguageSelect.SendKeys(Keys.ArrowDown);
                    UserName.EnterText(Constant.testUser);
                    UserPassword.EnterText(Constant.loginPassword);
                    Thread.Sleep(500);
                    Browser.Driver.FindElement(By.XPath("//*[@id='loginForm']/div[2]/div[4]/div/p/button")).ClickOn();
                    Thread.Sleep(1500);
                    if (Pages.Home_Page.AppointmentBtn_1.Displayed)
                    {
                        //nothing
                    }
                    else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
                    {
                        SideBarArrow.ClickOn();
                    }
                    break;
                case 3:
                    Pages.MobileTherapist_Page.MobileLogin();
                break;

                case 4:
                    LanguageSelect.SendKeys(Keys.ArrowDown);
                    UserName.EnterText(Constant.newClientUser);
                    UserPassword.EnterText(Constant.prodPassword);
                    Thread.Sleep(500);
                    Browser.Driver.FindElement(By.XPath("//*[@id='loginForm']/div[2]/div[4]/div/p/button")).ClickOn();
                    Thread.Sleep(1500);
                    if (Pages.Home_Page.AppointmentBtn_1.Displayed)
                    {
                        //nothing
                    }
                    else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
                    {
                        SideBarArrow.ClickOn();
                    }
                    break;


            }
        }

        public void LoginMiddleTest(string name, string password) {
            UserName.EnterText(name);
            UserPassword.EnterText(password);
        }

        public void LoginCredentials(int num) {
            int userCredential = num;
            switch (userCredential) {
                case 1:

                break;
            }
        }

        public void LoginUnauthorizedUserApplication() {
            //change language by clicking the language drop down list
            LanguageSelect.SendKeys(Keys.ArrowDown);
            Log.Info("pressed arrow down to select hebrew language");
            //fill user name, pasdoword and hit LOGIN
            UserName.EnterClearText(Constant.unauthorizedUserName);
            UserPassword.EnterClearText(Constant.loginPassword);
            LoginButton.ClickOn();
            if (NewAppointment.IsDisplayed("new Appointment btn"))
            {

            }
            else
            {
                Log.Error("Login Failed");
                Assert.Fail();
            }
        }

        public void TherapistLogin()
        {    
            //change language by clicking the language drop down list
            LanguageSelect.SendKeys(Keys.ArrowDown);
            //  Log.Info("pressed arrow down to select hebrew language");
            //fill user name, pasdoword and hit LOGIN
            UserName.EnterClearText(Constant.therapistUser);
            UserPassword.EnterClearText(Constant.loginPassword);
            LoginButton.ClickOn();
            if (Pages.Home_Page.AppointmentBtn_1.Displayed)
            {

            }
            else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
            {
                SideBarArrow.ClickOn();
            }
            softAssert.VerifyElementNotPresent(Pages.Home_Page.SettingScreen);
        }

        public void ClerkApplication()
        {
            //change language by clicking the language drop down list
            LanguageSelect.SendKeys(Keys.ArrowDown);
            //  Log.Info("pressed arrow down to select hebrew language");
            //fill user name, pasdoword and hit LOGIN
            UserName.EnterClearText(Constant.clerkUser);
            UserPassword.EnterClearText(Constant.loginPassword);
            LoginButton.ClickOn();
            if (Pages.Home_Page.AppointmentBtn_1.Displayed)
            {

            }
            else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
            {
                SideBarArrow.ClickOn();
            }
            softAssert.VerifyElementNotPresent(Pages.Home_Page.SettingScreen);
  
        }
    }
}
