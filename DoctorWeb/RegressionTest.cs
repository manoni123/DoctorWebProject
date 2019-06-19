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
        public void PatientDocumentUploadTest()
        {
            UITest(() =>
            {
                Pages.Document_Page.UploadFileApplication();
            }, Pages.Patient_Page.ClosePatientTab);

        }

        [Test, Category("Patient")]
        public void PatientVisitsTest()
        {
            UITest(() =>
            {
                Pages.Visits_Page.PatientVisitsApplication();
            }, Pages.Patient_Page.ClosePatientTab);
        }

        [Test, Category("Patient")]
        public void PatientCreateNewMultiple()
        {
            UITest(() =>
            {
                Pages.Home_Page.OpenEntityDropdown.ClickOn();
                Pages.Home_Page.CreateNewPatient.ClickWait();
                softAssert.VerifyElementIsPresent(Pages.Patient_Page.PatientName);
                Pages.Home_Page.OpenEntityDropdown.ClickOn();
                Pages.Home_Page.CreateNewPatient.ClickOn();
                softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.PopupButtonOk, Pages.Home_Page.PopupClose);
                Pages.Home_Page.PopupButtonOk.ClickOn();
            }, Pages.Patient_Page.ClosePatientTab);

        }

        [Test, Category("Patient")]
        public void PatientCloseTabBeforeSave()
        {
            UITest(() =>
            {
                Pages.Home_Page.OpenEntityDropdown.ClickOn();
                Pages.Home_Page.CreateNewPatient.ClickOn();
                softAssert.VerifyElementIsPresent(Pages.Patient_Page.PatientName);
                Pages.Patient_Page.PatientName.SendKeys(Constant.patientName);
                Pages.Home_Page.CloseTab.ClickOn();
                softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.PopupButtonOk, Pages.Home_Page.PopupButtonCancel);
                Pages.Home_Page.PopupButtonOk.ClickOn();
            }, Pages.Patient_Page.ClosePatientTab);
        }

        [Test, Category("Patient")]
        public void PatientConfidentialCreateTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewConfidentialPatientApplication();
            }, Pages.Patient_Page.ClosePatientTab);
        }
        //+++++++++++++Medical Tab Tests++++++++++++++++++//

        [Test, Category("Medical")]
        public void AnamnezaCRUDTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EnterAnamnezaTable();
                Pages.PatientMedical_Page.CreateNewAnamnezaApplication();
                Pages.PatientMedical_Page.EditNewAnamnezaApplication();
                Pages.PatientMedical_Page.DeleteNewAnamanezaApplication();
            }, Pages.PatientMedical_Page.CloseAnamnezaTable);
        }

        [Test, Category("Medical")]
        public void IcdAddTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.AddICDApplication();
            }, Pages.PatientMedical_Page.ICDCancel, Pages.PatientMedical_Page.CloseAnamnezaTable);
        }


        [Test, Category("Medical")]
        public void NoteCRUDTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.CreateNewNoteApplication();
                Pages.PatientMedical_Page.EditNoteApplication();
                Pages.PatientMedical_Page.DeleteNoteApplication();
            }, Pages.PatientMedical_Page.CloseNotesTable);
        }

        //medicine
        [Test, Category("Medical")]
        public void MedicineCRUDTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EnterMedicineTable();
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
                Pages.PatientMedical_Page.EditMedicineApplication();
                Pages.PatientMedical_Page.DeleteMedicineApplication();
            }, Pages.PatientMedical_Page.CancelMedicineTable);
        }

        [Test, Category("Medical")]
        public void MedicalWarningTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EnterMedicineTable();
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
                Pages.PatientMedical_Page.ValidateWarningIndicator();
            }, Pages.PatientMedical_Page.CancelMedicineTable);


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
            Pages.Supplier_Page.NewSupplierContactApplication();
        }

        [Test, Category("Entity")]
        public void ContactCreateTest()
        {
            UITest(() =>
            {
                Pages.Contact_Page.NewContactApplication();
            });
        }

        //+++++++++++++Settings Tests++++++++++++++++++//
        [Test, Category("Settings")]
        public void FilterMainPageTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.FilterImageApplication();
            });
        }


        [Test, Category("Settings")]
        public void ExpertiseCRUDTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EnterUserManagmentScreenProd();
                Pages.UsersManagement_Page.EnterPracticeWindow();
                Pages.UsersManagement_Page.CreatePracticeApplication();
                Pages.UsersManagement_Page.EditPracticeApplication();
                Pages.UsersManagement_Page.DeletePracticeApplication();
            }, Pages.Home_Page.PopupClose, Pages.UsersManagement_Page.PracticeWindowClose);
        }

        [Test, Category("Settings")]
        public void DepartmentCRUDTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.SettingScreenProd.ClickWait();
                Pages.Business_Page.CreateDepartmentApplication();
                Pages.Business_Page.EditDepartmentApplicaiton();
                Pages.Business_Page.DeleteDepartmentApplication();
                Pages.Business_Page.DepartmentCloseButton.ClickOn();
            }, Pages.Business_Page.DepartmentCloseButton);
        }

        [Test, Category("Settings")]
        public void CategoryCRUDTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.EnterPriceListScreen();
                Pages.PriceList_Page.OpenCategoryManager();
                Pages.PriceList_Page.CreateCategoryApplication();
                Pages.PriceList_Page.EditCategoryApplication();
                Pages.PriceList_Page.DeleteCategoryApplication();
                Pages.PriceList_Page.CategoryCloseWindow.ClickOn();
            }, Pages.PriceList_Page.CategoryCloseWindow);

        }

        [Test, Category("Settings")]
        public void BusinessCreateTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.SettingScreenProd.ClickWait();
                if (!Pages.Home_Page.AdminTab.Enabled)
                {
                    Assert.Pass();
                }
                else
                {
                    Pages.Business_Page.CreateBusinessApplication();
                }
            }, Pages.Business_Page.BusinessClose);
        }

        [Test, Category("Settings")]
        public void BranchCreateTest()
        {
            UITest(() =>
            {
                //call business page to preform create branch
               Pages.Home_Page.SettingScreenProd.ClickWait();
               Pages.Business_Page.CreateBranchApplication();
            }, Pages.Business_Page.BranchCancelButton);
        }

    [Test, Category("Settings")]
        public void GroupCRUDTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.EnterAuthorizationScreenProd();
                Pages.Authorization_Page.CreateGroupApplication();
                Pages.Authorization_Page.EditGroupApplication();
                Pages.Authorization_Page.DeleteGroupApplication();
            }, Pages.Authorization_Page.GroupCancel);
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
            Pages.UsersManagement_Page.CreateUserApplication();
        }

        [Test, Category("Settings")]
        public void PriceListCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.EnterPriceListScreen();
                Pages.PriceList_Page.CreatePriceListApplication();
            }, Pages.PriceList_Page.PriceListCancelDev);
        }

        //additional fields
        [Test, Category("Settings")]
        public void AdditionalFieldCreateTest()
        {
            UITest(() =>
            {
                Pages.AdditinalFields_Page.EnterAdditionalFieldsScreen();
                Pages.AdditinalFields_Page.AdditionalFieldApplication();
            }, Pages.AdditinalFields_Page.CloseFieldWindow);
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
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreenProd();
                Pages.Reports_Page.PatientReportApplicationProd();
            }, Pages.Reports_Page.PopupButton);
        }

    [Test, Category("Reports")]
        public void ReportContactTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreenProd();
                Pages.Reports_Page.ContactReportApplicationProd();
            }, Pages.Reports_Page.PopupButton);
        }

    [Test, Category("Reports")]
        public void ReportMeetingTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreenProd();
                Pages.Reports_Page.MeetingReportApplicationProd();
            }, Pages.Reports_Page.PopupButton);
        }

        [Test, Category("Reports")]
        public void ReportNotificationTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreenProd();
                Pages.Reports_Page.NotificationReportApplicationProd();
            }, Pages.Reports_Page.PopupButton);

        }
        //+++++++++++++Scheduler Tests++++++++++++++++++//

        [Test, Category("Scheduler")]
        public void LockTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.LockApplication();
            }, Pages.Home_Page.LockScreenExit);
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
            UITest(() =>
            {
               Pages.Scheduler_Page.EnterOpenBlockWindow();
               Pages.BlockOpen_Page.CloseWindow.ClickOn();
            }, Pages.Home_Page.PopupClose);

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
            UITest(() =>
            {
                Pages.Scheduler_Page.EnterLateYear();
            });
        }

        [Test, Category("Scheduler")]
        public void MeetingCreateTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.Home_Page.EnterAvailbleTime();
                Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
                Pages.Meeting_Page.CreateMeetingApplicationProd();
            }, Pages.Meeting_Page.CancelMeeting);

        }

        [Test, Category("Scheduler")]
        public void StandbyCreateTest()
        {

            Pages.Standby_Page.CreateStandbyApplicaitonProd();
        }

        [Test, Category("Scheduler")]
        public void AvailbleTimeTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EnterAvailbleTime();
                Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
                Pages.Meeting_Page.CancelMeeting.ClickOn();
            }, Pages.AvailbleTime_Page.CloseWindow);
        }

        //Create Patient > Create MEdicine> Create Note > Search Availble Time
        [Test, Category("EndToEnd")]
        public void PatientMedicineNoteAppointment()
        {
            UITest(() =>
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
            }, Pages.Home_Page.PopupClose, Pages.Home_Page.PopupClose);

        }

        [Test, Category("Smoke"), Order(1)]
        public void SmokeTesting()
        {
            UITest(() =>
            {
                Pages.Home_Page.SettingScreenProd.ClickWait();
               // softAssert.VerifyElementIsPresent(Pages.Home_Page.UserManagementScreen);
                Pages.Home_Page.UserManagementScreen.ClickWait();
               // softAssert.VerifyElementIsPresent(Pages.UsersManagement_Page.PracticesManagerButton);
                Pages.Home_Page.UserAuthorizationScreen.ClickWait();
               // softAssert.VerifyElementIsPresent(Pages.Authorization_Page.GroupCreate);
                Pages.Home_Page.GeneralScreen.ClickWait();
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.Scheduler_Page.AvailbleTime_Btn.ClickOn();
                Pages.Home_Page.PopupClose.ClickOn();
            }, Pages.Home_Page.PopupClose, Pages.Home_Page.PopupClose);
        }
    }
}