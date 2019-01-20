using DoctorWeb.PageObjects;
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
    public class Contact_Page
    {
         
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();

        [FindsBy(How = How.Id, Using = "tab2_FirstName")]
        [CacheLookup]
        public IWebElement ContactName { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_LastName")]
        [CacheLookup]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_Mobile")]
        [CacheLookup]
        public IWebElement ContactPhone { get; set; }

        [FindsBy(How = How.Id, Using = "tab2.FirstName_validationMessage")]
        [CacheLookup]
        public IWebElement NameValidation { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_tab2_btnSavePhoneBookDetails0")]
        [CacheLookup]
        public IWebElement ContactSaveButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainTabStrip > ul > li.k-item.k-state-default.k-tab-on-top.k-state-active > span.k-link > span.k-link > span")]
        [CacheLookup]
        public IWebElement ContactCloseTab { get; set; }

        public void NewContactApplication()
        {
            try
            {
                Pages.Home_Page.OpenEntityDropdown.ClickOn("EntityDropdown");
                Pages.Home_Page.CreateNewContact.ClickOn(Constant.Create);
                ContactName.SendKeys("1");
                ContactSaveButton.ClickOn(Constant.Save);
                softAssert.VerifyElementIsPresent(NameValidation);
                ContactName.EnterClearText(Constant.contactName);
                ContactLastName.EnterClearText(Constant.contactName);
                ContactPhone.EnterClearText(Constant.contactPhone);
                ContactSaveButton.ClickOn(Constant.Save);
                softAssert.VerifySuccessMsg();

                ContactCloseTab.ClickOn(Constant.CloseWindow);
            }   catch (Exception) {
                Log.Debug("contact Create Failed");
            }
        }
    }
}
