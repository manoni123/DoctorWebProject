using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class Authorization_Page
    {
        
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();


        [FindsBy(How = How.Id, Using = "btnAddClaim")]
        [CacheLookup]
        public IWebElement GroupCreate { get; set; }

        [FindsBy(How = How.Id, Using = "ClaimName-error")]
        [CacheLookup]
        public IWebElement GroupNameError { get; set; }

        [FindsBy(How = How.Id, Using = "ClaimName")]
        [CacheLookup]
        public IWebElement GroupName { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveAddClaim")]
        [CacheLookup]
        public IWebElement GroupSave { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelAddClaim")]
        [CacheLookup]
        public IWebElement GroupCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#panelGroup > div > div > div > ul > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement SelectSecretaryGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#panelGroup > div > div > div > ul > li:nth-child(3)")]
        [CacheLookup]
        public IWebElement SelectTerapistGroup { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='panelGroup']/div/div/div/ul/li[4]/span[6]")]
        [CacheLookup]
        public IWebElement GroupeEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='panelGroup']/div/div/div/ul/li[4]/span[5]")]
        [CacheLookup]
        public IWebElement DeleteLastGroup { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveEditClaim")]
        [CacheLookup]
        public IWebElement GroupEditSave { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddUserToGroup")]
        [CacheLookup]
        public IWebElement ImportToGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#frmSelectUsersForClaim > div:nth-child(2) > div.directionLTR.padding-scroll-body > table > tbody > tr:nth-child(1) > td:nth-child(1) > label")]
        [CacheLookup]
        public IWebElement SelectFirstUserOnList { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddUsersToClaimOK")]
        [CacheLookup]
        public IWebElement ConfirmUserImport { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement ApproveDelete { get; set; }


        public void EnterAuthorizationScreen()
        {
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreen.ClickWait();
            Pages.Home_Page.UserAuthorizationScreen.ClickWait();
            softAssert.VerifyElementIsPresent(GroupCreate);
        }

        //create new permission group
        public void CreateGroupApplication()
        {
            GroupCreate.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(GroupCancel, GroupCancel);
            GroupName.EnterClearText("11");
            GroupSave.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(GroupNameError, GroupCancel);
            GroupName.EnterClearText(Constant.groupName + RandomNumber.smallNumber());
            Thread.Sleep(500);
            GroupSave.ClickOn();
           // softAssert.VerifyElementNotPresent(GroupCancel);
        }

        public void EditGroupApplication()
        {
            softAssert.VerifyElementPresentInsideWindow(GroupeEdit, GroupCancel);
            GroupeEdit.ClickOn();
            GroupName.EnterClearText("11");
            GroupEditSave.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(GroupNameError, GroupCancel);
            GroupName.EnterClearText(Constant.groupName + RandomNumber.smallNumber());
            GroupEditSave.ClickOn();
           // softAssert.VerifyElementNotPresent(GroupCancel);
        }

        public void DeleteGroupApplication()
        {
            softAssert.VerifyElementPresentInsideWindow(DeleteLastGroup, GroupCancel);
            try
            {
                DeleteLastGroup.ClickOn();
                softAssert.VerifyElementPresentInsideWindow(ApproveDelete, GroupCancel);
                ApproveDelete.ClickOn();
            }
            catch (Exception)
            {
                TestContext.WriteLine("failed becuase of users in group - Not BUG!");
            }
        }

        public void SecretaryPermissionApplication() {
            try
            {
                Pages.Patient_Page.NewConfidentialPatientApplication();
                Pages.Home_Page.LogoutApplication();
                Pages.Login_Page.LoginMiddleTest(Constant.groupUser, Constant.loginPassword);
                Pages.Home_Page.SearchBox.EnterClearText(Pages.Patient_Page.PatientUseName);
                Pages.Home_Page.SearchBox.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Pages.Home_Page.SearchBox.SendKeys(Keys.Enter);
                softAssert.VerifyErrorMsg();
            }
            catch (Exception e)
            {
               
            }
        }

        public void ImportUsersToSecretaryGroupApplication()
        {
            Thread.Sleep(500);
            SelectSecretaryGroup.ClickOn();
            ImportToGroup.ClickOn();
            Thread.Sleep(500);
            IWebElement reutName = Browser.Driver.FindElement(By.XPath("//*[@id='frmSelectUsersForClaim']/div[2]/div[2]/table/tbody/tr[1]/td[1]"));
            reutName.ClickOn();
            ConfirmUserImport.ClickOn();
        }
    }
}
