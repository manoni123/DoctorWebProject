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
        UtilityFunction utility = new UtilityFunction();

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

        [FindsBy(How = How.Id, Using = "btnAddUsersToClaimCancel")]
        [CacheLookup]
        public IWebElement CancelUserImport { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement ApproveDelete { get; set; }

        public string countGroupList = "//*[@id='panelGroup']/div/div/div/ul";
        public string countUserInImport = "//*[@id='frmSelectUsersForClaim']/div[2]/div[2]/table/tbody";


        public void GoTo()
        {
            Thread.Sleep(500);
            Pages.Home_Page.EnterSettingScreen();
         //   Browser.chromebDriver.FindElement(By.CssSelector("#settingsTabstrip > ul > li:nth-child(3)")).ClickWait();
            Pages.Home_Page.UserAuthorizationScreen.ClickOn();
            Constant.tmpListCount = utility.ListCount(countGroupList);
            softAssert.VerifyElementIsPresent(GroupCreate);
        }

        public void GoToProd()
        {
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreenProd.ClickWait();
            Pages.Home_Page.UserAuthorizationScreen.ClickWait();
            softAssert.VerifyElementIsPresent(GroupCreate);
        }

        public void ImportUserWindow() {
            ImportToGroup.ClickOn();
            Constant.tmpTableCount = utility.TableCount(countUserInImport);
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
            softAssert.VerifyElementHasEqual(utility.ListCount(countGroupList), Constant.tmpListCount+1);
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
            softAssert.VerifySuccessMsg();
            // softAssert.VerifyElementNotPresent(GroupCancel);
        }

        public void DeleteGroupApplication()
        {
            IWebElement deleteLastGroup = Browser.Driver.FindElement(By.XPath("//*[@id='panelGroup']/div/div/div/ul/li[" + utility.ListCount(countGroupList) + "]/span[5]"));
            deleteLastGroup.ClickOn();
            ApproveDelete.ClickWait();
            softAssert.VerifyElementHasEqual(utility.ListCount(countGroupList), Constant.tmpListCount);
        }

        public void SecretaryPermissionApplication() {
            Pages.Patient_Page.NewConfidentialPatientApplication();
            Pages.Home_Page.LogoutApplication();
            Pages.Login_Page.LoginMiddleTest(Constant.groupUser, Constant.loginPassword);
            utility.TextClearDropdownAndEnter(Pages.Home_Page.SearchBox, Pages.Patient_Page.PatientUseName);
            softAssert.VerifyErrorMsg();
        }

        public void ImportUsersToSecretaryGroupApplication()
        {
            Pages.Authorization_Page.GoTo();

            Thread.Sleep(500);
            SelectSecretaryGroup.ClickOn();
            ImportToGroup.ClickOn();
            try {
                Thread.Sleep(500);
                IWebElement reutName = Browser.Driver.FindElement(By.XPath("//*[@id='frmSelectUsersForClaim']/div[2]/div[2]/table/tbody/tr[1]/td[1]"));
                reutName.ClickOn();
                ConfirmUserImport.ClickOn();
            } catch (Exception) {
                ConfirmUserImport.ClickOn();
                Assert.Pass("no user to pass");
            }
        }
    }
}
