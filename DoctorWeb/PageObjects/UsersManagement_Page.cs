using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class UsersManagement_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

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

        [FindsBy(How = How.Id, Using = "btnCancelCreateUser")]
        [CacheLookup]
        public IWebElement UserPrevBtn { get; set; }

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

        [FindsBy(How = How.Id, Using = "btnCancelCreateUser")]
        [CacheLookup]
        public IWebElement UserEditCancelBtn { get; set; }

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
        public IWebElement PracticeName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ManageUserPractiseGrid']/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement PracticeApprove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"ManageUserPractiseGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement EditPracticeApprove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"ManageUserPractiseGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
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

        [FindsBy(How = How.XPath, Using = "//*[@id='userActiveHours']/tbody/tr[1]/td[8]/img[2]")]
        [CacheLookup]
        public IWebElement MinusClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"windowPopup0\"]")]
        [CacheLookup]
        public IWebElement UserWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"userActiveHours\"]/tbody/tr/td[7]/span")]
        [CacheLookup]
        public IWebElement TherapistBranchList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='CreateUserStep2']/div/div[3]/div/label")]
        [CacheLookup]
        public IWebElement TherapistActiveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='CreateUserStep2']/div/div[4]/div/span[1]")]
        [CacheLookup]
        public IWebElement TherapistDropdownPractice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PractiseID_listbox']/li")]
        [CacheLookup]
        public IWebElement TherapistDropdownPracticeList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='userActiveHours']/tbody/tr[2]/td[7]/span")]
        [CacheLookup]
        public IWebElement TherapistSchedulerBranchDropdown { get; set; }

        private string expertiseTableCount = "//*[@id='ManageUserPractiseGrid']/div[2]/table/tbody";


        public void GoToProd()
        {
            Pages.Home_Page.SettingScreenProd.ClickWait();
            Pages.Home_Page.UserManagementScreen.ClickWait();
        }

        public void GoTo()
        {
            Pages.Home_Page.EnterSettingScreen();
            Pages.Home_Page.UserManagementScreen.ClickOn();
        }

        //create a create user 
        public void CreateUserApplication()
        {
            Pages.UsersManagement_Page.GoTo();
            CreateUser.ClickWait();

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
            var branchID = BranchIdOnUserCreate.GetAttribute("value");
            Browser.Driver.FindElement(By.CssSelector("#branchID"+branchID+" > label")).ClickOn();
            UserContinueBtn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.ErrorPopup, UserCancelBtn);
            SelectDepartmentOnUserCreate.ClickOn();
            UserContinueBtn.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void CreateTherapistUserApplication() {
            Pages.UsersManagement_Page.GoTo();

            CreateUser.ClickWait();
            softAssert.VerifyElementPresentInsideWindow(UserCancelBtn, UserCancelBtn);
            UserName.EnterClearText(Constant.userName + RandomNumber.smallNumber());
            UserContinueBtn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(UserEmailVerification, UserCancelBtn);
            UserLastname.EnterClearText(Constant.userLastName);
            UserEmail.EnterClearText("doctor" + RandomNumber.smallNumber() + "@doctorwin.co.il");
            UserMobile.EnterClearText(Constant.userPhone);
            UserContinueBtn.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(UserGoBack, UserCancelBtn);
            TherapistActiveBtn.ClickOn();
            TherapistDropdownPractice.ClickOn();
            List<IWebElement> practiceList = Browser.Driver.FindElements(By.XPath("//*[@id='PractiseID_listbox']/li")).ToList();
            var lastValue = practiceList[practiceList.Count - 1];
            lastValue.ClickOn();
            UserContinueBtn.ClickOn();
            SelectBusinessOnUserCreate.Click();
            var branchID = BranchIdOnUserCreate.GetAttribute("value");
            Browser.Driver.FindElement(By.CssSelector("#branchID" + branchID + " > label")).ClickOn();
            UserContinueBtn.Click();
            softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.ErrorPopup, UserCancelBtn);
            SelectDepartmentOnUserCreate.Click();
            UserContinueBtn.Click();
            therapistSchedulerSetup();
            UserContinueBtn.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        //Application to edit user - change setting and save.
        public void UserEditApplication()
        {
            Pages.Home_Page.ProfileList.ClickOn();
            Pages.Home_Page.ProfileButton.ClickOn();
            Pages.UserProfile_Page.GeneralSetting.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.UserProfile_Page.GeneralSettingCheckbox, Pages.Home_Page.PopupClose);
            Pages.UserProfile_Page.ActivityScope.ClickWait();
            Pages.UserProfile_Page.EditUserCancelBtn.ClickOn();

        }

        public void EnterPracticeWindow()
        {
            PracticesManagerButton.ClickWait();
            Constant.tmpTableCount = utility.TableCount(expertiseTableCount);
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
            softAssert.VerifyElementHasEqual(utility.TableCount(expertiseTableCount), Constant.tmpTableCount +1);
        }

        //edit practice name
        public void EditPracticeApplication()
        {
            PracticeEdit.ClickOn();
            PracticeName.EnterClearText(Constant.practiceName + RandomNumber.smallNumber());
            EditPracticeApprove.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void DeletePracticeApplication()
        {
            PracticeDelete.ClickOn();
            DeletePopup.ClickWait();
            softAssert.VerifyElementHasEqualInsideWindow(utility.TableCount(expertiseTableCount), Constant.tmpTableCount, PracticeWindowClose);
          //  softAssert.VerifyElementPresentInsideWindow(PracticeWindowClose, PracticeWindowClose);
            PracticeWindowClose.ClickOn();
        }

        public void TherapistUserCreateApplication()
        {
            Pages.UsersManagement_Page.CreatePracticeApplication();
            Pages.UsersManagement_Page.CreateTherapistUserApplication();
        }

        public void therapistSchedulerSetup() {
            int rowCount = utility.TableCount("//*[@id='userActiveHours']/tbody");
            while (rowCount > 1) {
                Browser.Driver.FindElement(By.XPath("//*[@id='userActiveHours']/tbody/tr[2]/td[8]/img[2]")).ClickOn();
                rowCount--;
            }
            Thread.Sleep(1000);
            utility.ClickDropdownAndEnter(TherapistSchedulerBranchDropdown);
        }
    }
}
