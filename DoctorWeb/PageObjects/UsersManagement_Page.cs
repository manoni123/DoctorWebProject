using Data;
using DoctorWeb.Utility;
using log4net;
using MySql.Data.MySqlClient;
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
            Pages.Home_Page.SettingScreen.ClickWait();
            Pages.Home_Page.UserManagementScreen.ClickWait();
        }

        public void EnterCreateNewUser() {
            CreateUser.ClickWait();
        }

        //create a create user 
        public void CreateUserApplication()
        {

            softAssert.VerifyElementPresentInsideWindow(UserCancelBtn, UserCancelBtn);
            UserName.EnterClearText(Constant.userName);
            UserContinueBtn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(UserEmailVerification, UserCancelBtn);
            UserLastname.EnterClearText(Constant.userLastName);
            UserEmail.EnterClearText(Constant.userEmail);
            UserMobile.EnterClearText(Constant.userPhone);
            UserContinueBtn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(UserGoBack, UserCancelBtn);
            UserContinueBtn.ClickOn();
            SelectBusinessOnUserCreate.ClickOn();
            //UserContinueBtn.ClickOn();
            //softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.ErrorPopup, UserCancelBtn);
            //Thread.Sleep(500);
            var branchID = BranchIdOnUserCreate.GetAttribute("value");
            Browser.Driver.FindElement(By.CssSelector("#branchID"+branchID+" > label")).ClickOn();
            UserContinueBtn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.ErrorPopup, UserCancelBtn);
            SelectDepartmentOnUserCreate.ClickOn();
            UserContinueBtn.ClickOn();
            softAssert.VerifySuccessMsg();
            //wish to make an assert here on green toastg msg when successfull
        }

        public void UserPasswordDBSettUP() {
            var dbCon = DBConnect.Instance();
            dbCon.DatabaseName = "doctorweb";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT Password " +
                                 "FROM doctorweb" +
                                 "Where Email = 'rona@doctorwin.co.il'";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                dbCon.Close();
            }
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
                EditUSer.ClickOn();
                UserName.EnterClearText(Constant.userName);
                UserLastname.EnterClearText(Constant.userLastName);
                UserEmail.EnterClearText(Constant.userEmail);
                UserMobile.EnterClearText(Constant.userPhone);

                //moves to determine setting
                EditUserTab2.ClickOn();
                GroupSelect.ClickOn();
                GroupSelect.SendKeys(Keys.ArrowDown);
                GroupSelect.ClickOn();
          
                //moves to user activty screen
                //select first business >>> first Branch >> marks all departments
                EditUserTab3.ClickOn();
                SelectBusinessOnUserCreate.ClickOn();
                //SelectBranchOnUserCreate.ClickOn();

                //check if save without selecting department
                UserContinueBtn.ClickOn();
                if (!SelectBusinessOnUserCreate.IsDisplayed("check activity window"))
                {
                    Log.Error("Test Failed - saved without select department");
                    Assert.Fail();
                }
                else
                {
                    SelectDepartmentOnUserCreate.ClickOn();
                    UserContinueBtn.ClickOn();
                }

                int minusCount = 6;
                while (minusCount != 0)
                {
                    MinusClick.ClickOn();
                    minusCount--;
                    Thread.Sleep(300);
                }

                Thread.Sleep(500);
                UserContinueBtn.ClickOn();
                if (!UserWindow.IsDisplayed("user window"))
                {
                    Log.Error("Saved without branch select");
                    Assert.Fail();
                }
                else
                {
                    TherapistBranchList.ClickOn();
                }
                //save complete user - check if window closed
                UserContinueBtn.ClickOn();
                if (UserWindow.IsDisplayed("user window"))
                {
                    Log.Error("Saved but didnt close window - fail");
                    Assert.Fail();
                }
                else {

                    //select department
                    SelectDepartmentOnUserCreate.ClickOn();
                    Log.Info("pressed on the first ");
                    UserContinueBtn.ClickOn();
                }

             }
                catch (Exception e)
                {
                    Log.Debug(e);
                }

        }

        public void EnterPracticeWindow()
        {
            PracticesManagerButton.ClickWait();
        }

        //create practice in usermanagement window
        public void CreatePracticeApplication()
        {
            CreateNewPractice.ClickOn();
            PracticeApprove.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(EmptyNameValidation, PracticeWindowClose);
            Thread.Sleep(500);
            PracticeName.EnterClearText(Constant.practiceName + RandomNumber.smallNumber());
            PracticeApprove.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(PracticeDelete, PracticeWindowClose);
            PracticeWindowClose.ClickOn();
        }

        //edit practice name
        public void EditPracticeApplication()
        {
            PracticeEdit.ClickOn();
            PracticeName.Clear();
            EditPracticeApprove.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(EmptyNameValidation, PracticeWindowClose);
            Thread.Sleep(500);
            PracticeName.EnterClearText(Constant.practiceName + RandomNumber.smallNumber());
            EditPracticeApprove.ClickOn();
            PracticeWindowClose.ClickOn();
        }

        public void DeletePracticeApplication()
        {
            CreateNewPractice.ClickOn();
            PracticeName.EnterClearText(Constant.practiceName + RandomNumber.smallNumber());
            PracticeApprove.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(PracticeDelete, PracticeWindowClose);
            PracticeDelete.ClickOn();
            DeletePopup.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(PracticeWindowClose, PracticeWindowClose);
            PracticeWindowClose.ClickOn();
        }

        public void DeleteActivePracticeApplication()
        {
            try
            {
                PracticesManagerButton.ClickOn();
                if (PracticeDelete.IsDisplayed("is delete icon displayed"))
                {
                    Log.Error("delete is displayed after active - fail");
                }
                else
                {
                    PracticeWindowClose.ClickOn();
                }
            }
            catch (Exception)
            {
                throw;
            }
 
        }
    }
}
