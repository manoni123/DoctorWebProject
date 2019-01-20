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
            //change language by clicking the language drop down list
            LanguageSelect.SendKeys(Keys.ArrowDown);
  //          LoginButton.ClickOn(Constant.Click);
            UserName.EnterText(Constant.adminUser);
            UserPassword.EnterText(Constant.loginPassword);
            Thread.Sleep(500);
            Browser.Driver.FindElement(By.XPath("//*[@id='loginForm']/div[2]/div[4]/div/p/button")).ClickOn("Found Element");

            if (Pages.Home_Page.AppointmentBtn_1.Displayed)
            {
            }
            else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
            {
            SideBarArrow.ClickOn(Constant.Click);
            }
        }

        public void LoginUnauthorizedUserApplication() {
            //change language by clicking the language drop down list
            LanguageSelect.SendKeys(Keys.ArrowDown);
            Log.Info("pressed arrow down to select hebrew language");
            //fill user name, pasdoword and hit LOGIN
            UserName.EnterClearText(Constant.unauthorizedUserName);
            UserPassword.EnterClearText(Constant.unauthorizedPassword);
            LoginButton.ClickOn(Constant.Click);
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
            try
            {
                //change language by clicking the language drop down list
                LanguageSelect.SendKeys(Keys.ArrowDown);
                //  Log.Info("pressed arrow down to select hebrew language");
                //fill user name, pasdoword and hit LOGIN
                UserName.EnterClearText(Constant.user1);
                UserPassword.EnterClearText(Constant.loginPassword);
                LoginButton.ClickOn(Constant.Click);
                if (Pages.Home_Page.AppointmentBtn_1.Displayed)
                {

                }
                else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
                {
                    SideBarArrow.ClickOn(Constant.Click);
                }
                softAssert.VerifyElementNotPresent(Pages.Home_Page.SettingScreen);
            }
            catch (Exception)
            {

            }
        }

        public void ClerkApplication()
        {
            try
            {
                //change language by clicking the language drop down list
                LanguageSelect.SendKeys(Keys.ArrowDown);
                //  Log.Info("pressed arrow down to select hebrew language");
                //fill user name, pasdoword and hit LOGIN
                UserName.EnterClearText(Constant.clerkUser);
                UserPassword.EnterClearText(Constant.clerkPassword);
                LoginButton.ClickOn(Constant.Click);
                if (Pages.Home_Page.AppointmentBtn_1.Displayed)
                {

                }
                else if (Pages.Home_Page.AppointmentBtn_2.Displayed)
                {
                    SideBarArrow.ClickOn(Constant.Click);
                }
                softAssert.VerifyElementNotPresent(Pages.Home_Page.SettingScreen);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
