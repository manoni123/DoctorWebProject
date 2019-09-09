using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Patient_Page
    {
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.XPath, Using = "//*[@id=\"mainTabStrip\"]/ul/li[2]")]
        [CacheLookup]
        public IWebElement NewPatiantTabClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab2_FirstName']")]
        [CacheLookup]
        public IWebElement PatientName { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_LastName")]
        [CacheLookup]
        public IWebElement PatientLastame { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_IDNumber")]
        [CacheLookup]
        public IWebElement PatientId { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab2_frmCustomerDetails_0']/div[2]/div/div/div[1]/div[1]/div/div[1]/div[1]/div[3]/div[1]/span")]
        [CacheLookup]
        public IWebElement PatientIDType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='details_scrollable_area']/div/div[1]/div[1]/div/div[1]/div[3]/ul/li/div/label")]
        [CacheLookup]
        public IWebElement PatientConfidential { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_btnSaveDetails_0")]
        [CacheLookup]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelBusinessSelection")]
        [CacheLookup]
        public IWebElement CancelSelectBusiness { get; set; }

        [FindsBy(How = How.Id, Using = "tab3_btnEditPersonDetails")]
        [CacheLookup]
        public IWebElement PatientEditButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainTabStrip > ul > li.k-item.k-state-default.k-tab-on-top.k-state-active > span.k-link > span.k-link > span")]
        [CacheLookup]
        public IWebElement ClosePatientTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tab4_customerTabStrip > ul > li.k-item.k-state-default.k-last")]
        [CacheLookup]
        public IWebElement RelationFamilyTab { get; set; }

        [FindsBy(How = How.Id, Using = "menuItemNewPatient")]
        [CacheLookup]
        public IWebElement SelectPatient { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_menuCustomerExpended']/li[3]/span")]
        public IWebElement PatientVisits { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_menuCustomerExpended']/li[4]/span")]
        public IWebElement PatientMessagesProd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_menuCustomerExpended']/li[4]/span")]
        [CacheLookup]
        public IWebElement PatientTreatments { get; set; }

        [FindsBy(How = How.Id, Using = "tab2.FirstName_validationMessage")]
        [CacheLookup]
        public IWebElement PatientValidation { get; set; }

        [FindsBy(How = How.Id, Using = "tab3_btnNewAppointment")]
        [CacheLookup]
        public IWebElement PatientMeetingCreate { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='tab3_newAppointmentContextMenu']/li[1]")]
        [CacheLookup]
        public IWebElement PatientAvailbleTime { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='tab3_newAppointmentContextMenu_mn_active']")]
        [CacheLookup]
        public IWebElement PatienMoveToScheduler { get; set; }

        //patiant use name
        public string PatientUseName = Constant.patientName;
        public static By PatientMessages = By.XPath("//*[@id='tab3_menuCustomerExpended']/li[5]");
        public static By PatientDocument = By.XPath("//*[@id='tab3_menuCustomerExpended']/li[2]/span");
        public static By MedicalTab = By.CssSelector("#tab3_customerTabStrip > ul > li:nth-child(2)");

        //create or fill method to call to use in tests
        public void NewPatientApplication()
        {
            if (Constant.patientCreated == false)
            {
                Pages.Home_Page.OpenEntityDropdown.ClickOn();
                Pages.Home_Page.CreateNewPatient.ClickOn();
                PatientExecute();
                PatientConfirmCreate();
                Thread.Sleep(500);
                Constant.patientCreated = true;
            } else if (Constant.patientCreated == true)
            {
                Pages.Home_Page.OpenEntityDropdown.ClickOn();
                Pages.Home_Page.CreateNewPatient.ClickOn();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                utility.TextClearDropdownAndEnter(Pages.Home_Page.SearchBox, PatientUseName);
                Thread.Sleep(500);
            }
        }

        public void NewConfidentialPatientApplication()
        {
            Pages.Home_Page.OpenEntityDropdown.ClickOn();
            Pages.Home_Page.CreateNewPatient.ClickOn();
            PatientConfidentialExecute();
            PatientConfirmCreate();
            var isCheck = Browser.Driver.FindElement(By.XPath("//*[@id='tab3_Confidential']")).GetAttribute("checked");
            Assert.IsTrue(isCheck == "true");
        }

        //fill patient  with MUST-only credentials
        public void PatientExecute()
        {
            PatientCreateBusiness();
            PatientName.SendKeys("1");
            SaveButton.ClickOn();
        //    softAssert.VerifyElementIsPresent(PatientValidation);
            PatientName.EnterClearText(PatientUseName);
            PatientLastame.EnterClearText(Constant.patientLastname);
            PatientId.SendKeys(RandomNumber.smallNumber());
            PatientIDType.ClickOn();
            PatientIDType.SendKeys(Keys.ArrowDown);
        }

        public void PatientCreateBusiness() {
            if (Browser.chromebDriver.PageSource.Contains("btnCancelBusinessSelection")) {
                Browser.Driver.FindElement(By.XPath("//*[@id='1000']")).ClickOn();
            }
        }

        public void PatientConfidentialExecute() {
            PatientExecute();
            PatientConfidential.ClickOn();
        }

        public void PatientConfirmCreate() {
            SaveButton.ClickWait();
            softAssert.VerifyElementIsPresent(PatientEditButton);
            Constant.patientDataID =  Browser.Driver.FindElement(By.ClassName("mainTabPrefix")).GetAttribute("data-entity-id");
    }

        public void PatientCloseTab() {
            ClosePatientTab.ClickOn();
        }

        public void NewBlockedPatientApplication()
        {
            //call home_Page to use in the patient applicaitn

            //open entity list and press on create new patient
            Pages.Home_Page.OpenEntityDropdown.ClickOn();
            Thread.Sleep(500);
            //press create new patient causes the drop down to close
            //needed to create a JS press command (not human) in order to click the list for it to work propertly
            IWebElement element = Browser.Driver.FindElement(By.CssSelector("#menuItemNewPatient"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.Driver; js.ExecuteScript("arguments[0].ClickOn();", element);
            Thread.Sleep(500);
            Log.Info("Create new patient pressed OK");

            //check if the user has more then one business popup window
            //boolean termines that the window is Open = enabled

            if (Browser.Driver.FindElement(By.Id("windowPopup0")).IsDisplayed("window popup"))
            {
                Thread.Sleep(500);
                Log.Info("select business window has opened");
                Browser.Driver.FindElement(By.XPath("//*[@id=\"windowPopup0\"]/div/div[2]/ul/li[1]")).ClickOn();
                BlockedPatientCreate();
            }
            else
            {
                Log.Info("No business found to select");
                BlockedPatientCreate();
                Thread.Sleep(500);
                Pages.Home_Page.ProfileList.ClickOn();
                Pages.Home_Page.LogoutButton.ClickOn();
            }
        }

        public void EnterMedicalTab()
        {
            Browser.chromebDriver.FindElement(MedicalTab, 1000).ClickOn();
        }


        public void BlockedPatientCreate() {
            PatientName.EnterClearText(PatientUseName);
            PatientLastame.EnterClearText(Constant.patientLastname);
            PatientConfidential.ClickOn();
            SaveButton.ClickOn();
        }

        public void EnterPatientDocument()
        {
            Browser.chromebDriver.FindElement(PatientDocument, 1500).ClickOn();
            softAssert.VerifyElementIsPresent(Pages.Document_Page.UplaodFileBtn);
        }

        public void EnterPatientMessages()
        {
            Browser.chromebDriver.FindElement(PatientMessages, 1000).ClickWait();
            softAssert.VerifyElementIsPresent(Browser.Driver.FindElement(By.XPath("//*[@id='tab3_gridCustomerMessages_" + Constant.patientDataID +"']/div[2]/div[1]")));
        }

        public void EnterPatientMessagesProd()
        {
            Thread.Sleep(500);
            PatientMessagesProd.ClickWait();
            softAssert.VerifyElementIsPresent(Browser.Driver.FindElement(By.XPath("//*[@id='tab3_gridCustomerMessages_" + Constant.patientDataID + "']/div[2]/div[1]/table/tbody")));
        }
    }
}