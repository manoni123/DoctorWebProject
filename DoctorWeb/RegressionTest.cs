using DoctorWeb.Utility;
using NUnit.Framework;
using NUnit.Framework.Internal;
using DoctorWeb;
using OpenQA.Selenium;
using System;
using System.Collections;

namespace DoctorWeb
{
    public class RegressionTest : BaseFixture
    {
        AssertionExtent softAssert = new AssertionExtent();
      

        //Each Test Category has a fixture of its own that contains a setup and tear down beforre and after each test
        //OneTimeSetUp and OnTimeTearDown reffers to BaseFixture and effects all the tests
        [SetUp]
        public void LoginBeforeEachTest()
        {
            Pages.Login_Page.LoginApplication();
        }

        [TearDown]
        public void LogoutAfterEachTest()
        {
            Pages.Home_Page.LogoutApplication();
        }

        //+++++++++++++Patient Tests++++++++++++++++++//

        [Test, Category("Patient")]
        public void PatientCreateTest()
        {
            //call patient page
            Pages.Patient_Page.NewPatientApplication();
        }

        [Test, Category("Patient")]
        public void PatientDocumentUploadTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Document_Page.UploadFileApplication();
        }

        [Test, Category("Patient")]
        public void PatientVisitsTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Visits_Page.PatientVisitsApplication();
        }

        [Test, Category("Patient")]
        public void PatientMessageTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Messages_Page.PatientMessageApplication();
        }

        [Test, Category("Patient")]
        public void PatientCreateNewMultiple()
        {
            Pages.Home_Page.OpenEntityDropdown.ClickOn();
            Pages.Home_Page.CreateNewPatient.ClickWait();
            softAssert.VerifyElementIsPresent(Pages.Patient_Page.PatientName);
            Pages.Home_Page.OpenEntityDropdown.ClickOn();
            Pages.Home_Page.CreateNewPatient.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.PopupButtonOk, Pages.Home_Page.PopupClose);
            Pages.Home_Page.PopupButtonOk.ClickOn();
        }

        [Test, Category("Patient")]
        public void PatientCloseTabBeforeSave()
        {
            Pages.Home_Page.OpenEntityDropdown.ClickOn();
            Pages.Home_Page.CreateNewPatient.ClickOn();
            softAssert.VerifyElementIsPresent(Pages.Patient_Page.PatientName);
            Pages.Patient_Page.PatientName.SendKeys(Constant.patientName);
            Pages.Home_Page.CloseTab.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.PopupButtonOk, Pages.Home_Page.PopupButtonCancel);
            Pages.Home_Page.PopupButtonOk.ClickOn();
        }
        //+++++++++++++Medical Tab Tests++++++++++++++++++//

        [Test, Category("Medical")]
        public void AnamnezaCreateTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterAnamnezaTable();
            Pages.PatientMedical_Page.CreateNewAnamnezaApplication();
        }

        [Ignore("ff")]
        [Test, Category("Medical")]
        public void AnamnezaSaveWhenCreate()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterAnamnezaTable();
            Pages.PatientMedical_Page.CreateNewAnamnezaWhenSaveApplication();
        }

        [Test, Category("Medical")]
        public void AnamnezaEditTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterAnamnezaTable();
            Pages.PatientMedical_Page.CreateNewAnamnezaApplication();
            Pages.PatientMedical_Page.EnterAnamnezaTable();
            Pages.PatientMedical_Page.EditNewAnamnezaApplication();
        }

        [Test, Category("Medical")]
        public void AnamnezaDeleteTest()
        {
            Pages.PatientMedical_Page.DeleteNewAnamanezaApplication();
        }

        [Test, Category("Medical")]
        public void IcdAddTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterAnamnezaTable();
            Pages.PatientMedical_Page.AddICDApplication();
        }

        [Test, Category("Medical")]
        public void NoteCreateTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterNoteTable();
            Pages.PatientMedical_Page.CreateNewNoteApplication();
        }

        [Test, Category("Medical")]
        public void NoteEditTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterNoteTable();
            Pages.PatientMedical_Page.CreateNewNoteApplication();
            Pages.PatientMedical_Page.EnterNoteTable();
            Pages.PatientMedical_Page.EditNoteApplication();
        }

        [Test, Category("Medical")]
        public void NoteDeleteTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterNoteTable();
            Pages.PatientMedical_Page.CreateNewNoteApplication();
            Pages.PatientMedical_Page.EnterNoteTable();
            Pages.PatientMedical_Page.DeleteNoteApplication();
        }
        //medicine
        [Test, Category("Medical")]
        public void MedicineCreateTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterMedicineTable();
            Pages.PatientMedical_Page.CreateNewMedicineApplication();
        }

        [Test, Category("Medical")]
        public void MedicineEditTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterMedicineTable();
            Pages.PatientMedical_Page.CreateNewMedicineApplication();
            Pages.PatientMedical_Page.EnterMedicineTable();
            Pages.PatientMedical_Page.EditMedicineApplication();
        }

        [Test, Category("Medical")]
        public void MedicineDeleteTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterMedicineTable();
            Pages.PatientMedical_Page.DeleteMedicineApplication();
        }


        [Test, Category("Medical")]
        public void MedicalWarningTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterMedicineTable();
            Pages.PatientMedical_Page.CreateNewMedicineApplication();
            Pages.PatientMedical_Page.ValidateWarningIndicator();

        }
        //+++++++++++++Suppliers and Contacts Tests++++++++++++++++++//

        [Test, Category("Entity")]
        public void SupplierCreateTest()
        {
            //create new supplier
            Pages.Supplier_Page.NewSupplierCreateApplication();
        }

        [Test, Category("Entity")]
        public void SupplierContactCreateTest()
        {
            //create new supplier
            Pages.Supplier_Page.NewSupplierCreateApplication();
            //create supplier contact
            Pages.Supplier_Page.NewSupplierContactApplication();
        }

        [Test, Category("Entity")]
        public void ContactCreateTest()
        {
            Pages.Contact_Page.NewContactApplication();
        }

        //+++++++++++++Settings Tests++++++++++++++++++//
        [Test, Category("Settings")]
        public void FilterMainPageTest()
        {
            Pages.Home_Page.FilterImageApplication();
        }


        [Test, Category("Settings")]
        public void ExpertiseCreateTest()
        {
            Pages.Home_Page.EnterUserManagmentScreen();
            Pages.UsersManagement_Page.EnterPracticeWindow();
            Pages.UsersManagement_Page.CreatePracticeApplication();
        }

        [Test, Category("Settings")]
        public void ExpertiseEditTest()
        {
            Pages.Home_Page.EnterUserManagmentScreen();
            Pages.UsersManagement_Page.EnterPracticeWindow();
            Pages.UsersManagement_Page.EditPracticeApplication();
        }

        [Test, Category("Settings")]
        public void ExpertiseDeleteTest()
        {

            Pages.UsersManagement_Page.DeletePracticeApplication();
        }

        [Test, Category("Settings")]
        public void DepartmentCreateTest()
        {

            Pages.Business_Page.CreateDepartmentApplication();
            Pages.Business_Page.DepartmentCloseButton.ClickOn();
        }

        [Test, Category("Settings")]
        public void DepartmentDeleteTest()
        {
            Pages.Business_Page.CheckDepartmentIsNull();
            Pages.Business_Page.EnterDepaertmentWindow();
            Pages.Business_Page.CreateDepartmentApplication();
            Pages.Business_Page.DeleteDepartmentApplication();
        }

        [Ignore("ff")]
        [Test, Category("Settings")]
        public void DepartmentActiveDeleteTest()
        {
            Pages.Business_Page.DeleteActiveDepartmentApplication();

        }

        [Test, Category("Settings")]
        public void DepartmentEditTest()
        {
            Pages.Business_Page.CheckDepartmentIsNull();
            Pages.Business_Page.EnterDepaertmentWindow();
            Pages.Business_Page.EditDepartmentApplicaiton();

        }

        [Test, Category("Settings")]
        public void CategoryCreateTest()
        {
            Pages.PriceList_Page.EnterPriceListScreen();
            Pages.PriceList_Page.OpenCategoryManager();
            Pages.PriceList_Page.CreateCategoryApplication();
            Pages.PriceList_Page.CategoryCloseWindow.ClickOn();
        }

        [Test, Category("Settings")]
        public void CategoryDeleteTest()
        {
            Pages.PriceList_Page.EnterPriceListScreen();
            Pages.PriceList_Page.OpenCategoryManager();
            Pages.PriceList_Page.CreateCategoryApplication();
            Pages.PriceList_Page.DeleteCategoryApplication();
        }

        [Ignore("skip Test")]
        [Test, Category("Settings")]
        public void CategoryActiveDeleteTest()
        {
            Pages.PriceList_Page.CreateCategoryApplication();
            Pages.PriceList_Page.DeleteActiveCategoryApplication();
        }

        [Test, Category("Settings")]
        public void CategoryEditTest()
        {
            Pages.PriceList_Page.EnterPriceListScreen();
            Pages.PriceList_Page.OpenCategoryManager();
            Pages.PriceList_Page.EditCategoryApplication();
        }

        [Test, Category("Settings")]
        public void BusinessCreateTest()
        {
            Pages.Business_Page.EnterSettingScreen();
            if (!Pages.Home_Page.AdminTab.Enabled)
            {
                Assert.Pass();
            }
            else
            {
                Pages.Business_Page.CreateBusinessApplication();
            }
        }

        [Test, Category("Settings")]
        public void BranchCreateTest()
        {
            //call business page to preform create branch
            Pages.Business_Page.EnterSettingScreen();
            Pages.Business_Page.CreateBranchApplication();
        }

        [Test, Category("Settings")]
        public void GroupCreateTest()
        {
            Pages.Authorization_Page.EnterAuthorizationScreen();
            Pages.Authorization_Page.CreateGroupApplication();
        }

        [Test, Category("Settings")]
        public void GroupEditTest()
        {
            Pages.Authorization_Page.EnterAuthorizationScreen();
            Pages.Authorization_Page.CreateGroupApplication();
            Pages.Authorization_Page.EditGroupApplication();


        }

        [Test, Category("Settings")]
        public void GroupDeleteTest()
        {
            Pages.Authorization_Page.EnterAuthorizationScreen();
            Pages.Authorization_Page.CreateGroupApplication();
            Pages.Authorization_Page.DeleteGroupApplication();
        }

        [Ignore("skip Test")]
        [Test, Category("Settings")]
        public void GroupImportTest()
        {
            //create new and try to delete last created group
            Pages.Authorization_Page.ImportUsersToSecretaryGroupApplication();
        }
        //users
        [Test, Category("Settings")]
        public void UserCreateTest()
        {
            Pages.UsersManagement_Page.EnterManagementWindow();
            Pages.UsersManagement_Page.CreateUser.ClickWait();
            Pages.UsersManagement_Page.CreateUserApplication();
        }

        [Test, Category("Settings")]
        public void PriceListCreateTest()
        {
            Pages.PriceList_Page.EnterPriceListScreen();
            Pages.PriceList_Page.OpenPriceListAddWindow();
            Pages.PriceList_Page.CreatePriceListApplication();
        }

        [Test, Category("Settings")]
        public void PrieListCountTest()
        {
            Pages.PriceList_Page.CountPriceListApplicaiton();
        }

        //additional fields
        [Test, Category("Settings")]
        public void AdditionalFieldCreateTest()
        {
            //call the create additional field application
            Pages.AdditinalFields_Page.EnterAdditionalFieldsScreen();
            Pages.AdditinalFields_Page.OpenFieldsManager();
            Pages.AdditinalFields_Page.AdditionalFieldApplication();
        }

        [Test, Category("Settings")]
        public void RightBarPannelTest()
        {
            Pages.Home_Page.RightBarApplication();
        }

        //+++++++++++++ Tests++++++++++++++++++//

        [Test, Category("Reports")]
        public void ReportPatientTest()
        {
            Pages.Reports_Page.EnterReportScreen();
            Pages.Reports_Page.PatientReportApplication();
        }

        [Test, Category("Reports")]
        public void ReportContactTest()
        {
            Pages.Reports_Page.EnterReportScreen();
            Pages.Reports_Page.ContactReportApplication();
        }

        [Test, Category("Reports")]
        public void ReportMeetingTest()
        {
            Pages.Reports_Page.EnterReportScreen();
            Pages.Reports_Page.MeetingReportApplication();
        }

        [Test, Category("Reports")]
        public void ReportNotificationTest()
        {
            Pages.Reports_Page.EnterReportScreen();
            Pages.Reports_Page.NotificationReportApplication();
        }

        [Ignore("Not ready")]
        [Test, Category("Reports")]
        public void ReportAuditTest()
        {
            Pages.Reports_Page.EnterReportScreen();
            Pages.Reports_Page.AuditReportApplication();
        }

        //+++++++++++++Scheduler Tests++++++++++++++++++//

        [Test, Category("Scheduler")]
        public void LockTest()
        {
            Pages.Home_Page.LockApplication();
        }

        [Test, Category("Scheduler")]
        public void ReportDailyTest()
        {
            Pages.Scheduler_Page.EnterDailyReportScreen();
            Pages.Scheduler_Page.SchedulerEventPrintCancel.ClickOn();
        }

        [Test, Category("Scheduler")]
        public void ReportCancelledMeetingTest()
        {
            Pages.Scheduler_Page.EnterCancelledMeetingWindow();
            Pages.CancelledMeeting_Page.CloseWindow.ClickOn();
        }

        [Test, Category("Scheduler")]
        public void OpenBlockListWindowTest()
        {
            Pages.Scheduler_Page.EnterOpenBlockWindow();
            Pages.BlockOpen_Page.CloseWindow.ClickOn();
        }

        [Test, Category("Scheduler")]
        public void StandbyListWindowTest()
        {
            Pages.Scheduler_Page.EnterStanbyWindow();
            Pages.StandbyList_Page.CloseWindow.ClickOn();
        }

        [Test, Category("Scheduler")]
        public void BlockCreateEmptyTest()
        {
            Pages.BlockOpen_Page.BlockCreateEmptyApplication();
        }

        [Test, Category("Scheduler")]
        public void EnterLaterYearTest()
        {
            Pages.Scheduler_Page.EnterLateYear();
        }

        [Test, Category("Scheduler")]
        public void MeetingCreateTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.ClosePatientTab.ClickOn();
            Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
            Pages.Meeting_Page.CreateMeetingApplication();
        }

        [Test, Category("Scheduler")]
        public void StandbyCreateTest()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.ClosePatientTab.ClickOn();
            Pages.Standby_Page.CreateStandbyApplication();
        }

        [Test, Category("Scheduler")]
        public void AvailbleTimeTest()
        {
            Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
            Pages.Meeting_Page.CancelMeeting.ClickOn();
        }

        [Ignore("no ready")]
        [Test, Category("Authorization")]
        public void ManagerLoginTest()
        {
            Pages.Login_Page.LoginApplication();
        }


        [Test, Category("Authorization")]
        public void TherapistLoginTest()
        {
            Pages.Login_Page.TherapistLogin();

        }

        [Test, Category("Authorization")]
        public void ClerkLoginTest()
        {
            Pages.Login_Page.ClerkApplication();
        }

        //Create Patient > Create MEdicine> Create Note > Search Availble Time
        [Test, Category("EndToEnd")]
        public void PatientMedicineNoteAppointment()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterMedicineTable();
            Pages.PatientMedical_Page.CreateNewMedicineApplication();
            Pages.PatientMedical_Page.EnterNoteTable();
            Pages.PatientMedical_Page.CreateNewNoteApplication();
            Pages.Home_Page.CloseTab.ClickOn();
            Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
            Pages.Meeting_Page.CreateMeetingApplication();
        }

        [Test, Category("Smoke"), Order(1)]
        public void SmokeTesting()
        {
                Pages.Home_Page.SettingScreen.ClickWait();
                softAssert.VerifyElementIsPresent(Pages.Home_Page.UserManagementScreen);
                Pages.Home_Page.UserManagementScreen.ClickWait();
                softAssert.VerifyElementIsPresent(Pages.UsersManagement_Page.PracticesManagerButton);
                Pages.Home_Page.UserAuthorizationScreen.ClickWait();
                softAssert.VerifyElementIsPresent(Pages.Authorization_Page.GroupCreate);
                Pages.Home_Page.GeneralScreen.ClickWait();
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.Scheduler_Page.AvailbleTime_Btn.ClickOn();
                Pages.Home_Page.PopupClose.ClickOn();
        }
    }
}