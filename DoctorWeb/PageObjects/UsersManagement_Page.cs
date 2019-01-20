﻿using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class UsersManagement_Page
    {

         
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();


        [FindsBy(How = How.Id, Using = "btnAddUser")]
        [CacheLookup]
        public IWebElement CreateUser { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gridUsers\"]/div[2]/div[1]/table/tbody/tr[2]/td[6]/a/span")]
        [CacheLookup]
        public IWebElement EditUSer { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        [CacheLookup]
        public IWebElement UserLastname { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        [CacheLookup]
        public IWebElement UserEmail { get; set; }

        [FindsBy(How = How.Id, Using = "PhoneMobile")]
        [CacheLookup]
        public IWebElement UserMobile { get; set; }

        [FindsBy(How = How.Id, Using = "btnCreateUserContinue")]
        [CacheLookup]
        public IWebElement UserContinueBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelCreateUser")]
        [CacheLookup]
        public IWebElement UserCancelBtn { get; set; }

        [FindsBy(How = How.Id, Using = "Email_validationMessage")]
        [CacheLookup]
        public IWebElement UserEmailVerification { get; set; }

        [FindsBy(How = How.Id, Using = "btnCreateUserPrev")]
        [CacheLookup]
        public IWebElement UserGoBack { get; set; }

        [FindsBy(How = How.ClassName, Using = "notification-title")]
        [CacheLookup]
        public IWebElement UserWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"CreateUserStep2\"]/div/div[3]/div/label")]
        [CacheLookup]
        public IWebElement CheckThreapistButton { get; set; }
    
        [FindsBy(How = How.Id, Using = "editUserTab2")]
        [CacheLookup]
        public IWebElement EditUserTab2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"EditUserTab2\"]/div/div[2]/div/span")]
        [CacheLookup]
        public IWebElement GroupSelect { get; set; }

        [FindsBy(How = How.Id, Using = "editUserTab3")]
        [CacheLookup]
        public IWebElement EditUserTab3 { get; set; }

        [FindsBy(How = How.Id, Using = "btnEditUser")]
        [CacheLookup]
        public IWebElement EditUserBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"panelUserBusiness\"]/div/div/div/ul/li[1]")]
        [CacheLookup]
        public IWebElement SelectBusinessOnUserCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Branches_0__BranchID']")]
        [CacheLookup]
        public IWebElement BranchIdOnUserCreate { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#branchID1005 > label")]
        //[CacheLookup]
        //public IWebElement SelectBranchOnUserCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Branches_0__BranchID\"]")]
        [CacheLookup]
        public IWebElement IsBranchSelected { get; set; }

        [FindsBy(How = How.Id, Using = "btnManagePractises")]
        [CacheLookup]
        public IWebElement PracticesManagerButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnUserPractiseManagerCreateNew")]
        [CacheLookup]
        public IWebElement CreateNewPractice { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement PracticeName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ManageUserPractiseGrid']/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement PracticeApprove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"ManageUserPractiseGrid\"]/div[2]/table/tbody/tr[2]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement EditPracticeApprove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"ManageUserPractiseGrid\"]/div[2]/table/tbody/tr[2]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement PracticeEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"ManageUserPractiseGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement PracticeDelete { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement DeletePopup { get; set; }

        [FindsBy(How = How.Id, Using = "btnUserPractiseManagerCancel")]
        [CacheLookup]
        public IWebElement PracticeWindowClose { get; set; }

        [FindsBy(How = How.Id, Using = "Name_validationMessage")]
        [CacheLookup]
        public IWebElement EmptyNameValidation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"panelUserDepartment\"]/div/div[2]/div/ul/li[1]/label")]
        [CacheLookup]
        public IWebElement SelectDepartmentOnUserCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"userActiveHours\"]/tbody/tr[6]/td[8]/img[2]")]
        [CacheLookup]
        public IWebElement MinusClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"windowPopup0\"]")]
        [CacheLookup]
        public IWebElement UserWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"userActiveHours\"]/tbody/tr/td[7]/span")]
        [CacheLookup]
        public IWebElement TherapistBranchList { get; set; }

        public void EnterManagementWindow()
        {
            Pages.Home_Page.SettingScreen.ClickWait("Setting");
            Pages.Home_Page.UserManagementScreen.ClickWait("UserManagement");
        }

        public void EnterCreateNewUser() {
            CreateUser.ClickWait("Create User");
        }

        //create a create user 
        public void CreateUserApplication()
        {

            softAssert.VerifyElementPresentInsideWindow(UserCancelBtn, UserCancelBtn);
            UserName.EnterClearText(Constant.userName);
            UserContinueBtn.ClickOn("UserContinue");
            softAssert.VerifyElementPresentInsideWindow(UserEmailVerification, UserCancelBtn);
            UserLastname.EnterClearText(Constant.userLastName);
            UserEmail.EnterClearText(Constant.userEmail);
            UserMobile.EnterClearText(Constant.userPhone);
            UserContinueBtn.ClickOn("UserContinue");
            softAssert.VerifyElementPresentInsideWindow(UserGoBack, UserCancelBtn);
            UserContinueBtn.ClickOn("UserContinue");
            SelectBusinessOnUserCreate.ClickOn("Select Busines");
            //UserContinueBtn.ClickOn("UserContinue");
            //softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.ErrorPopup, UserCancelBtn);
            //Thread.Sleep(500);
            var branchID = BranchIdOnUserCreate.GetAttribute("value");
            Browser.Driver.FindElement(By.CssSelector("#branchID"+branchID+" > label")).ClickOn(Constant.Checkbox);
            UserContinueBtn.ClickOn("UserContinue");
            softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.ErrorPopup, UserCancelBtn);
            SelectDepartmentOnUserCreate.ClickOn("SelectDepartment");
            UserContinueBtn.ClickOn("UserContinue");
            softAssert.VerifySuccessMsg();

            //wish to make an assert here on green toastg msg when successfull
        }

        //Application to edit user - change setting and save.
        public void UserEditApplication()
        {
            try
            {
                //Select Second User on List (If Any) And perform some edit.
                //First user = current user.
            int rowCount = Browser.Driver.FindElements(By.XPath("//*[@id=\"gridUsers\"]/div[2]/div[1]/table/tbody/tr")).Count;
            if (rowCount < 2)
            {
                Log.Error("Fail Test on puprose, Reason: " + Environment.NewLine + "The User only has one user in the table - himself");
                Assert.Fail();
            }

            //edit 2nd user on list
                EditUSer.ClickOn("User Edit 1");
                UserName.EnterClearText(Constant.userName);
                UserLastname.EnterClearText(Constant.userLastName);
                UserEmail.EnterClearText(Constant.userEmail);
                UserMobile.EnterClearText(Constant.userPhone);

                //moves to determine setting
                EditUserTab2.ClickOn("User Edit 2");
                GroupSelect.ClickOn(Constant.Click);
                GroupSelect.SendKeys(Keys.ArrowDown);
                GroupSelect.ClickOn(Constant.Click);
          
                //moves to user activty screen
                //select first business >>> first Branch >> marks all departments
                EditUserTab3.ClickOn("User Edit 3");
                SelectBusinessOnUserCreate.ClickOn(Constant.Select);
                //SelectBranchOnUserCreate.ClickOn();

                //check if save without selecting department
                UserContinueBtn.ClickOn("UserContinue");
                if (!SelectBusinessOnUserCreate.IsDisplayed("check activity window"))
                {
                    Log.Error("Test Failed - saved without select department");
                    Assert.Fail();
                }
                else
                {
                    SelectDepartmentOnUserCreate.ClickOn(Constant.Select);
                    UserContinueBtn.ClickOn(Constant.Click);
                }

                int minusCount = 6;
                while (minusCount != 0)
                {
                    MinusClick.ClickOn(Constant.Click);
                    minusCount--;
                    Thread.Sleep(300);
                }

                Thread.Sleep(500);
                UserContinueBtn.ClickOn("UserContinue");
                if (!UserWindow.IsDisplayed("user window"))
                {
                    Log.Error("Saved without branch select");
                    Assert.Fail();
                }
                else
                {
                    TherapistBranchList.ClickOn(Constant.Select);
                }
                //save complete user - check if window closed
                UserContinueBtn.ClickOn("UserContinue");
                if (UserWindow.IsDisplayed("user window"))
                {
                    Log.Error("Saved but didnt close window - fail");
                    Assert.Fail();
                }
                else {

                    //select department
                    SelectDepartmentOnUserCreate.ClickOn(Constant.Select);
                    Log.Info("pressed on the first ");
                    UserContinueBtn.ClickOn(Constant.Click);
                }

             }
                catch (Exception e)
                {
                    Log.Debug(e);
                }

        }

        public void EnterPracticeWindow()
        {
            PracticesManagerButton.ClickWait("PracticeManager");
        }

        //create practice in usermanagement window
        public void CreatePracticeApplication()
        {
            CreateNewPractice.ClickOn(Constant.Create);
            PracticeApprove.ClickOn(Constant.Approve);
            softAssert.VerifyElementPresentInsideWindow(EmptyNameValidation, PracticeWindowClose);
            Thread.Sleep(500);
            PracticeName.EnterClearText(Constant.practiceName + RandomNumber.smallNumber());
            PracticeApprove.ClickOn(Constant.Approve);
            softAssert.VerifyElementPresentInsideWindow(PracticeDelete, PracticeWindowClose);
            PracticeWindowClose.ClickOn(Constant.CloseWindow);
        }

        //edit practice name
        public void EditPracticeApplication()
        {
            PracticeEdit.ClickOn(Constant.Edit);
            PracticeName.Clear();
            EditPracticeApprove.ClickOn(Constant.Approve);
            softAssert.VerifyElementPresentInsideWindow(EmptyNameValidation, PracticeWindowClose);
            Thread.Sleep(500);
            PracticeName.EnterClearText(Constant.practiceName + RandomNumber.smallNumber());
            EditPracticeApprove.ClickOn(Constant.Approve);
            PracticeWindowClose.ClickOn(Constant.CloseWindow);
        }

        public void DeletePracticeApplication()
        {
            CreateNewPractice.ClickOn(Constant.Create);
            PracticeName.EnterClearText(Constant.practiceName + RandomNumber.smallNumber());
            PracticeApprove.ClickOn("Practice Approve");
            softAssert.VerifyElementPresentInsideWindow(PracticeDelete, PracticeWindowClose);
            PracticeDelete.ClickOn("Practice Delete");
            DeletePopup.ClickOn(Constant.Delete);
            softAssert.VerifyElementPresentInsideWindow(PracticeWindowClose, PracticeWindowClose);
            PracticeWindowClose.ClickOn(Constant.CloseWindow);
        }

        public void DeleteActivePracticeApplication()
        {
            try
            {
                PracticesManagerButton.ClickOn(Constant.Click);
                if (PracticeDelete.IsDisplayed("is delete icon displayed"))
                {
                    Log.Error("delete is displayed after active - fail");
                }
                else
                {
                    PracticeWindowClose.ClickOn(Constant.CloseWindow);
                }
            }
            catch (Exception)
            {
                throw;
            }
 
        }
    }
}
