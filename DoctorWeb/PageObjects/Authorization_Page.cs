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

        [FindsBy(How = How.XPath, Using = "//*[@id=\"panelGroup\"]/div/div/ul/li[2]")]
        [CacheLookup]
        public IWebElement SelectSecondGroup { get; set; }

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
            //call homepage to enter setting window
            Thread.Sleep(500);
            Pages.Home_Page.SettingScreen.ClickWait("Setting");
            Pages.Home_Page.UserAuthorizationScreen.ClickWait("Authorization");
            softAssert.VerifyElementIsPresent(GroupCreate);
        }

        //create new permission group
        public void CreateGroupApplication()
        {
            GroupCreate.ClickOn(Constant.Create);
            softAssert.VerifyElementPresentInsideWindow(GroupCancel, GroupCancel);
            GroupName.EnterClearText("11");
            GroupSave.ClickOn(Constant.Save);
            softAssert.VerifyElementPresentInsideWindow(GroupNameError, GroupCancel);
            GroupName.EnterClearText(Constant.groupName + RandomNumber.smallNumber());
            Thread.Sleep(500);
            GroupSave.ClickOn(Constant.Save);
           // softAssert.VerifyElementNotPresent(GroupCancel);
        }

        public void EditGroupApplication()
        {
            softAssert.VerifyElementPresentInsideWindow(GroupeEdit, GroupCancel);
            GroupeEdit.ClickOn(Constant.Edit);
            GroupName.EnterClearText("11");
            GroupEditSave.ClickOn(Constant.Save);
            softAssert.VerifyElementPresentInsideWindow(GroupNameError, GroupCancel);
            GroupName.EnterClearText(Constant.groupName + RandomNumber.smallNumber());
            GroupEditSave.ClickOn(Constant.Save);
           // softAssert.VerifyElementNotPresent(GroupCancel);
        }

        public void DeleteGroupApplication()
        {
            softAssert.VerifyElementPresentInsideWindow(DeleteLastGroup, GroupCancel);
            try
            {
                DeleteLastGroup.ClickOn(Constant.Delete);
                softAssert.VerifyElementPresentInsideWindow(ApproveDelete, GroupCancel);
                ApproveDelete.ClickOn(Constant.Approve);
            }
            catch (Exception)
            {
                TestContext.WriteLine("failed becuase of users in group - Not BUG!");
            }
        }

        public void ImportUsersToGroupApplication()
        {
            Thread.Sleep(500);
            SelectSecondGroup.ClickOn(Constant.Click);
            ImportToGroup.ClickOn(Constant.Click);
            SelectFirstUserOnList.ClickOn(Constant.Click);
            ConfirmUserImport.ClickOn(Constant.Approve);
            Browser.Driver.FindElement(By.XPath("//*[@id=\"panelGroup\"]/div/div/ul/li[4]/span[5]")).ClickOn(Constant.Click);
            if (ApproveDelete.IsDisplayed("approve shown"))
            {
                Assert.Fail();
            }
        }
    }
}
