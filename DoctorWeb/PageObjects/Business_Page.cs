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

        [FindsBy(How = How.Id, Using = "CityName")]
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

        [FindsBy(How = How.Id, Using = "CityName")]
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


        public void CheckDepartmentIsNull() {
            Pages.Home_Page.SettingScreen.ClickWait(1500);
            //enter inside etting window and mark one business
            SelectBusinessFromList.ClickOn();
            var disButton = DepartmentManagement.GetAttribute("disabled");
          //  softAssert.VerifyElementIsNull(disButton);
        }

        public void EnterDepaertmentWindow() {
            Thread.Sleep(500);
            DepartmentManagement.ClickOn();
            softAssert.VerifyElementIsPresent(DepartmentCloseButton);
        }

        public void EnterSettingScreen() {
            Pages.Home_Page.SettingScreen.Click();
            softAssert.VerifyElementIsPresent(BusinessCreate);
        }

        //create new business
        public void CreateBusinessApplication()
        {
            //call home page to enter inside setting window
            Thread.Sleep(500);
            BusinessCreate.Click();
            softAssert.VerifyElementIsPresent(BusinessName);
        //    BusinessName.EnterClearText("1", "name test");
            BusinessSavebutton.Click();
            softAssert.VerifyElementIsPresent(BusinessEmail);
            BusinessName.EnterClearText(Constant.businessName, "business name");
            BusinessPractinerNum.EnterClearText(Constant.businessNum, "BusinessNum");
            BusinessAddress.EnterClearText(Constant.businessAddress, "BusinessAddress");
            BusinessCity.EnterClearText(Constant.businessAddress, "businessCity");
            BusinessPhone.EnterClearText(Constant.businessNum, "business phone");
            BusinessEmail.EnterClearText(Constant.businessEmail, "business email");
            BusinessSavebutton.Click();
        }

        public void CreateBranchApplication()
        {
            Thread.Sleep(500);
            SelectBusinessFromList.ClickWait(500);
            BranchCreate.ClickOn();
            softAssert.VerifyElementIsPresent(BranchCancelButton);
         //   BranchAddress.SendKeys("1");
            BranchSaveButton.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(BranchEmail, BusinessClose);
            BranchAddress.EnterClearText(Constant.branchAddress, "BranchAddress");
            BranchCity.EnterText("Rishon");
            BranchPhone.EnterClearText(Constant.userPhone, "branch phone");
            BranchEmail.EnterClearText(Constant.userEmail, "branch Email");
            Thread.Sleep(500);
            BranchSaveButton.Click();
         //   softAssert.VerifyElementNotPresent(BranchSaveButton);
        }

        public void CreateDepartmentApplication()
        {
            //call home page enter inside setting window and create department
            DepartmentCreate.Click();
            DepartmentConfirm.Click();
            softAssert.VerifyElementPresentInsideWindow(DepNameValidationPopup, DepartmentCloseButton);
            DepartmentName.EnterClearText(Constant.departmentName + RandomNumber.smallNumber(), "DepName");
            DepartmentConfirm.Click();
            softAssert.VerifyElementPresentInsideWindow(DepartmentDelete, DepartmentCloseButton);
        }

        public void DeleteDepartmentApplication() {
            Thread.Sleep(500);
            softAssert.VerifyElementPresentInsideWindow(DepartmentDelete, DepartmentCloseButton);
            DepartmentDelete.Click();
            softAssert.VerifyElementPresentInsideWindow(BtnApproveDelete, BusinessClose);
            BtnApproveDelete.ClickOn();
            DepartmentCloseButton.Click();
        }

        public void DeleteActiveDepartmentApplication()
        {

            DepartmentCloseButton.ClickOn();
            SelectBusinessFromList.ClickOn();
            if (Browser.Driver.FindElement(By.XPath("//span[@class='k-switch km-switch k-widget km-widget k-switch-off km-switch-off']")).Displayed)
            {
                DepartmentEnableMark.ClickOn();
                DepartmentManagement.Click();

                if (DepartmentDelete.IsDisplayed("department delete"))
                {
                    Thread.Sleep(500);
                    Log.Error("Delete is displayed on Active Department - FAIL");
                   // Assert.Fail();
                }
                else
                {
                    Thread.Sleep(500);
                    Browser.Driver.FindElement(By.Id("btnDepartmentManagerCancel")).Click();
                    Log.Info("Test Pass");
                   // Assert.Pass();
                }
            }
            else if (Browser.Driver.FindElement(By.XPath("//span[@class='k-switch km-switch k-widget km-widget k-switch-off km-switch-on']")).Displayed)
            {
                DepartmentManagement.Click();
                if (DepartmentDelete.IsDisplayed("department delete"))
                {
                    Log.Error("Delete is displayed on Active Department - FAIL");
                    Assert.Fail();
                }
                else
                {
                    DepartmentCloseButton.Click();
                    Log.Info("Test Pass");
                    Assert.Pass();
                }
            }
            DepartmentCloseButton.Click();
        }

        public void EditDepartmentApplicaiton()
        {
            DepartmentEdit.Click();
            DepartmentName.Clear();
            DepartmentConfirm.Click();
            softAssert.VerifyElementIsPresent(DepNameValidationPopup);
            DepartmentName.EnterClearText(Constant.departmentName + RandomNumber.smallNumber(), "Department Name");
            DepartmentConfirm.Click();
            DepartmentCloseButton.ClickOn();
        }
    }
}
