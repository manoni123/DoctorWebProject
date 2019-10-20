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
    public class Business_Page
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "btnAddBusiness")]
        [CacheLookup]
        public IWebElement BusinessCreate { get; set; }

        [FindsBy(How = How.Id, Using = "BusinessName")]
        [CacheLookup]
        public IWebElement BusinessName { get; set; }

        [FindsBy(How = How.Id, Using = "PractitionerNumber")]
        [CacheLookup]
        public IWebElement BusinessPractinerNum { get; set; }

        [FindsBy(How = How.Id, Using = "Address")]
        [CacheLookup]
        public IWebElement BusinessAddress { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveBusiness")]
        [CacheLookup]
        public IWebElement BusinessSavebutton { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelDepartment")]
        [CacheLookup]
        public IWebElement BusinessClose { get; set; }

        [FindsBy(How = How.Id, Using = "Phone1")]
        [CacheLookup]
        public IWebElement BusinessPhone { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        [CacheLookup]
        public IWebElement BusinessEmail { get; set; }

        [FindsBy(How = How.Name, Using = "CityID_input")]
        [CacheLookup]
        public IWebElement BusinessCity { get; set; }

        [FindsBy(How = How.Id, Using = "BusinessName_validationMessage")]
        [CacheLookup]
        public IWebElement businessNameValidation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"panelBusiness\"]/div/div/div/div/ul/li[1]")]
        [CacheLookup]
        public IWebElement SelectBusinessFromList { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddBranch")]
        [CacheLookup]
        public IWebElement BranchCreate { get; set; }

        [FindsBy(How = How.Id, Using = "Address")]
        [CacheLookup]
        public IWebElement BranchAddress { get; set; }

        [FindsBy(How = How.Name, Using = "CityID_input")]
        [CacheLookup]
        public IWebElement BranchCity { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        [CacheLookup]
        public IWebElement BranchEmail { get; set; }

        [FindsBy(How = How.Id, Using = "Phone1")]
        [CacheLookup]
        public IWebElement BranchPhone { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveBusiness")]
        [CacheLookup]
        public IWebElement BranchSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelBranch")]
        [CacheLookup]
        public IWebElement BranchCancelButton { get; set; }

        [FindsBy(How = How.Id, Using = "Email_validationMessage")]
        [CacheLookup]
        public IWebElement BranchEmailValidation { get; set; }

        [FindsBy(How = How.Id, Using = "btnManageDepartments")]
        [CacheLookup]
        public IWebElement DepartmentManagement { get; set; }

        [FindsBy(How = How.Id, Using = "btnDepartmentManagerCreateNew")]
        [CacheLookup]
        public IWebElement DepartmentCreate { get; set; }

        [FindsBy(How = How.Id, Using = "DepartmentName")]
        [CacheLookup]
        public IWebElement DepartmentName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"DepartmentManagmentGrid\"]/div[2]/table/tbody/tr[1]/td[3]/label")]
        [CacheLookup]
        public IWebElement DepartmentActiveCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"DepartmentManagmentGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement DepartmentConfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"DepartmentManagmentGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement DepartmentDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"DepartmentManagmentGrid\"]/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement DepartmentEdit { get; set; }

        [FindsBy(How = How.Id, Using = "btnDepartmentManagerCancel")]
        [CacheLookup]
        public IWebElement DepartmentCloseButton { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement BtnApproveDelete { get; set; }

        [FindsBy(How = How.Id, Using = "DepartmentName_validationMessage")]
        [CacheLookup]
        public IWebElement DepNameValidationPopup { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"departmentForBranch\"]/li[1]/span[2]/span")]
        [CacheLookup]
        public IWebElement DepartmentEnableMark { get; set; }

        public string departmentTableCount = "//*[@id='DepartmentManagmentGrid']/div[2]/table/tbody";
        public static By DepartmentManagementWindow = By.Id("btnManageDepartments");


        public void CheckDepartmentIsNull() {
            Pages.Home_Page.SettingScreen.ClickWait();
            //enter inside etting window and mark one business
            SelectBusinessFromList.ClickOn();
            var disButton = DepartmentManagement.GetAttribute("disabled");
          //  softAssert.VerifyElementIsNull(disButton);
        }

        public void EnterDepaertmentWindow() {
            Browser.chromebDriver.FindElement(DepartmentManagementWindow);
            softAssert.VerifyElementIsPresent(DepartmentCloseButton);
            Constant.tmpTableCount = utility.TableCount(departmentTableCount);
        }

        public void EnterSettingScreen() {
            Pages.Home_Page.EnterSettingScreen();
            softAssert.VerifyElementIsPresent(BusinessCreate);
        }

        //create new business
        public void CreateBusinessApplication()
        {
            //call home page to enter inside setting window
            Thread.Sleep(500);
            BusinessCreate.ClickOn();
            softAssert.VerifyElementIsPresent(BusinessName);
        //    BusinessName.EnterClearText("1", "name test");
            BusinessSavebutton.ClickOn();
            softAssert.VerifyElementIsPresent(BusinessEmail);
            BusinessName.EnterClearText(Constant.businessName);
            BusinessPractinerNum.EnterClearText(Constant.businessNum);
            BusinessAddress.EnterClearText(Constant.businessAddress);
            BusinessCity.EnterClearText(Constant.businessCity);
            BusinessPhone.EnterClearText(Constant.businessNum);
            BusinessEmail.EnterClearText(Constant.businessEmail);
            BusinessSavebutton.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void CreateBranchApplication()
        {
            Thread.Sleep(500);
            SelectBusinessFromList.ClickOn();
            BranchCreate.ClickOn();
            softAssert.VerifyElementIsPresent(BranchCancelButton);
            BranchSaveButton.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(BranchEmail, BusinessClose);
            BranchAddress.EnterClearText(Constant.branchAddress);
            BranchCity.EnterText(Constant.businessCity);
            BranchPhone.EnterClearText(Constant.userPhone);
            BranchEmail.EnterClearText(Constant.userEmail);
            Thread.Sleep(500);
            BranchSaveButton.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void CreateDepartmentApplication()
        {
            Pages.Business_Page.CheckDepartmentIsNull();
            Pages.Business_Page.EnterDepaertmentWindow();
            DepartmentCreate.ClickOn();
            DepartmentConfirm.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(DepNameValidationPopup, DepartmentCloseButton);
            DepartmentName.EnterClearText(Constant.departmentName + RandomNumber.smallNumber());
            DepartmentConfirm.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(DepartmentDelete, DepartmentCloseButton);
            softAssert.VerifyElementHasEqual(utility.TableCount(departmentTableCount), Constant.tmpTableCount +1);
        }

        public void DeleteDepartmentApplication() {
            DepartmentDelete.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(BtnApproveDelete, BusinessClose);
            BtnApproveDelete.ClickOn();
            softAssert.VerifyElementHasEqualInsideWindow(utility.TableCount(departmentTableCount), Constant.tmpTableCount, DepartmentCloseButton);
        }

        public void DeleteActiveDepartmentApplication()
        {

            DepartmentCloseButton.ClickOn();
            SelectBusinessFromList.ClickOn();
            if (Browser.Driver.FindElement(By.XPath("//span[@class='k-switch km-switch k-widget km-widget k-switch-off km-switch-off']")).Displayed)
            {
                DepartmentEnableMark.ClickOn();
                DepartmentManagement.ClickOn();

                if (DepartmentDelete.IsDisplayed("department delete"))
                {
                    Thread.Sleep(500);
                    Log.Error("Delete is displayed on Active Department - FAIL");
                   // Assert.Fail();
                }
                else
                {
                    Thread.Sleep(500);
                    Browser.Driver.FindElement(By.Id("btnDepartmentManagerCancel")).ClickOn();
                    Log.Info("Test Pass");
                   // Assert.Pass();
                }
            }
            else if (Browser.Driver.FindElement(By.XPath("//span[@class='k-switch km-switch k-widget km-widget k-switch-off km-switch-on']")).Displayed)
            {
                DepartmentManagement.ClickOn();
                if (DepartmentDelete.IsDisplayed("department delete"))
                {
                    Log.Error("Delete is displayed on Active Department - FAIL");
                    Assert.Fail();
                }
                else
                {
                    DepartmentCloseButton.ClickOn();
                    Log.Info("Test Pass");
                    Assert.Pass();
                }
            }
            DepartmentCloseButton.ClickOn();
        }

        public void EditDepartmentApplicaiton()
        {
            DepartmentEdit.ClickOn();
            DepartmentName.Clear();
            DepartmentConfirm.ClickOn();
            softAssert.VerifyElementIsPresent(DepNameValidationPopup);
            DepartmentName.EnterClearText(Constant.departmentName + RandomNumber.smallNumber());
            DepartmentConfirm.ClickOn();
        }
    }
}
