using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using System;

namespace DoctorWeb
{
    public class RegressionDevTest : BaseFixture
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly AssertionExtent softAssert = new AssertionExtent();
        public UtilityFunction utility = new UtilityFunction();
        public bool isActive;
        
        //Each Test Category has a fixture of its own that contains a setup and tear down beforre and after each test
        //OneTimeSetUp and OnTimeTearDown reffers to BaseFixture and effects all the tests
        [SetUp]
        public void LoginBeforeEachTest()
        {  
            Log.Info(Environment.NewLine + Environment.NewLine + "##### " + TestContext.CurrentContext.Test.MethodName + " #####" + Environment.NewLine);
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
            Pages.Patient_Page.NewPatientApplication();
        }

        [Test, Category("Patient")]
        public void PatientConfidentialCreateTest()
        {
            Pages.Patient_Page.NewConfidentialPatientApplication();
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
            Pages.Document_Page.UploadFileApplication();
        }

        [Test, Category("Patient")]
        public void PatientCreateNewMultipleTest()
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
        public void PatientCloseTabBeforeSaveTest()
        {
            Pages.Home_Page.OpenEntityDropdown.ClickOn();
            Pages.Home_Page.CreateNewPatient.ClickWait();
            softAssert.VerifyElementIsPresent(Pages.Patient_Page.PatientName);
            Pages.Patient_Page.PatientName.SendKeys(Constant.patientName);
            Pages.Home_Page.CloseTab.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.PopupButtonOk, Pages.Home_Page.PopupButtonCancel);
            Pages.Home_Page.PopupButtonOk.ClickOn();
        }

        [Test, Category("Users")]
        public void AuthorizationSecretaryTest()
        {
            Pages.Authorization_Page.SecretaryPermissionApplication();
        }
        //+++++++++++++Medical Tab Tests++++++++++++++++++//

        [Test, Category("Medical")]
        public void AnamnezaCreateTest()
        {
            utility.TestWrap(Pages.PatientMedical_Page.CreateNewAnamnezaApplication, Pages.PatientMedical_Page.CloseAnamnezaTable);
        }

        [Ignore("ff")]
        [Test, Category("Medical")]
        public void AnamnezaSaveWhenCreate()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterAnamnezaTable();
                Pages.PatientMedical_Page.CreateNewAnamnezaWhenSaveApplication();
            });
        }

        [Test, Category("Medical")]
        public void AnamnezaEditTest()
        {
            UITest(() =>
            {
                 Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterAnamnezaTable();
                Pages.PatientMedical_Page.CreateNewAnamnezaApplication();
                Pages.PatientMedical_Page.EnterAnamnezaTable();
                Pages.PatientMedical_Page.EditNewAnamnezaApplication();
            });
        }

        [Test, Category("Medical")]
        public void AnamnezaDeleteTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterAnamnezaTable();
                Pages.PatientMedical_Page.DeleteNewAnamanezaApplication();
            });

        }

        [Test, Category("Medical")]
        public void IcdAddTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterAnamnezaTable();
                Pages.PatientMedical_Page.AddICDApplication();
            }, Pages.PatientMedical_Page.ICDCancel);
        }

        [Test, Category("Medical")]
        public void NoteCreateTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.CreateNewNoteApplication();
            });
        }

        [Test, Category("Medical")]
        public void NoteEditTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.CreateNewNoteApplication();
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.EditNoteApplication();
            });
        }

        [Test, Category("Medical")]
        public void NoteDeleteTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.CreateNewNoteApplication();
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.DeleteNoteApplication();
            });
        }
        //medicine
        [Test, Category("Medical")]
        public void MedicineCreateTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterMedicineTable();
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
            }, Pages.PatientMedical_Page.CancelMedicineTable);
        }

        [Test, Category("Medical")]
        public void MedicineEditTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterMedicineTable();
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
                Pages.PatientMedical_Page.EnterMedicineTable();
                Pages.PatientMedical_Page.EditMedicineApplication();
            });
        }

        [Test, Category("Medical")]
        public void MedicineDeleteTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterMedicineTable();
                Pages.PatientMedical_Page.DeleteMedicineApplication();
            });
        }


        [Test, Category("Medical")]
        public void MedicalWarningTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.PatientMedical_Page.EnterMedicalTab();
                Pages.PatientMedical_Page.EnterMedicineTable();
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
                Pages.PatientMedical_Page.ValidateWarningIndicator();
            }, Pages.PatientMedical_Page.CancelMedicineTable);

        }
        //+++++++++++++Suppliers and Contacts Tests++++++++++++++++++//

        [Test, Category("Entity")]
        public void SupplierCreateTest()
        {
            UITest(() =>
            {
                Pages.Supplier_Page.NewSupplierCreateApplication();
            });
            //create new supplier
        }

        [Test, Category("Entity")]
        public void SupplierContactCreateTest()
        {
            UITest(() =>
            {   
                Pages.Supplier_Page.NewSupplierCreateApplication();
                Pages.Supplier_Page.NewSupplierContactApplication();
            });
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
            });
            Pages.Home_Page.FilterImageApplication();
        }


        [Test, Category("Settings")]
        public void ExpertiseCreateTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EnterUserManagmentScreen();
                Pages.UsersManagement_Page.EnterPracticeWindow();
                Pages.UsersManagement_Page.CreatePracticeApplication();
            });
        }

        [Test, Category("Settings")]
        public void ExpertiseEditTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EnterUserManagmentScreen();
                Pages.UsersManagement_Page.EnterPracticeWindow();
                Pages.UsersManagement_Page.EditPracticeApplication();
            });
        }

        [Test, Category("Settings")]
        public void ExpertiseDeleteTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EnterUserManagmentScreen();
                Pages.UsersManagement_Page.EnterPracticeWindow();
                Pages.UsersManagement_Page.DeletePracticeApplication();
            });
        }

        [Ignore("skip Test")]
        [Test, Category("Settings")]
        public void ExpertiseDeleteActiveTest()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.CreatePracticeApplication();
                //create practice now create user and use the new practice
                Pages.UsersManagement_Page.CreateUserApplication();
                //check if activated practice cant be deleted
                Pages.UsersManagement_Page.DeleteActivePracticeApplication();
            });
        }

        [Test, Category("Settings")]
        public void DepartmentCreateTest()
        {
            UITest(() =>
            {
                Pages.Business_Page.CheckDepartmentIsNull();
                Pages.Business_Page.EnterDepaertmentWindow();
                Pages.Business_Page.CreateDepartmentApplication();
                Pages.Business_Page.DepartmentCloseButton.ClickOn();
            });
        }

        [Test, Category("Settings")]
        public void DepartmentDeleteTest()
        {
            UITest(() =>
            {
                Pages.Business_Page.CheckDepartmentIsNull();
                Pages.Business_Page.EnterDepaertmentWindow();
                Pages.Business_Page.CreateDepartmentApplication();
                Pages.Business_Page.DeleteDepartmentApplication();
            });
        }

        [Ignore("ff")]
        [Test, Category("Settings")]
        public void DepartmentActiveDeleteTest()
        {
            UITest(() =>
            {
                Pages.Business_Page.DeleteActiveDepartmentApplication();
            });

        }

        [Test, Category("Settings")]
        public void DepartmentEditTest()
        {
            UITest(() =>
            {
                Pages.Business_Page.CheckDepartmentIsNull();
                Pages.Business_Page.EnterDepaertmentWindow();
                Pages.Business_Page.EditDepartmentApplicaiton();
            });

        }

        [Test, Category("Settings")]
        public void CategoryCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.DevEnterCategoryWindow();
                Pages.PriceList_Page.CreateCategoryApplication();
            });
        }

        [Test, Category("Settings")]
        public void CategoryDeleteTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.DevEnterCategoryWindow();
                Pages.PriceList_Page.CreateCategoryApplication();
                Pages.PriceList_Page.DeleteCategoryApplication();
            });
        }

        [Ignore("skip Test")]
        [Test, Category("Settings")]
        public void CategoryActiveDeleteTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.CreateCategoryApplication();
                Pages.PriceList_Page.DeleteActiveCategoryApplication();
            });
        }

        [Test, Category("Settings")]
        public void CategoryEditTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.DevEnterCategoryWindow();
                Pages.PriceList_Page.CreateCategoryApplication();
                Pages.PriceList_Page.EditCategoryApplication();
            });
        }

        [Test, Category("Settings")]
        public void BusinessCreateTest()
        {
            UITest(() =>
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
            });
        }

        [Test, Category("Settings")]
        public void BranchCreateTest()
        {
            UITest(() =>
            {   
                Pages.Business_Page.EnterSettingScreen();
                Pages.Business_Page.CreateBranchApplication();
            });
        }

        [Test, Category("Settings")]
        public void GroupCreateTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.EnterAuthorizationScreen();
                Pages.Authorization_Page.CreateGroupApplication();
            });
        }

        [Test, Category("Settings")]
        public void GroupEditTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.EnterAuthorizationScreen();
                Pages.Authorization_Page.CreateGroupApplication();
                Pages.Authorization_Page.EditGroupApplication();
            });
        }

        [Test, Category("Settings")]
        public void GroupDeleteTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.EnterAuthorizationScreen();
                Pages.Authorization_Page.CreateGroupApplication();
                Pages.Authorization_Page.DeleteGroupApplication();
            });
        }

        [Test, Category("Settings")]
        public void GroupImportTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.EnterAuthorizationScreen();
                Pages.Authorization_Page.ImportUsersToSecretaryGroupApplication();
            });
        }
        //users
        [Test, Category("Settings")]
        public void UserCreateTest()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.EnterManagementWindow();
                Pages.UsersManagement_Page.EnterCreateNewUser();
                Pages.UsersManagement_Page.CreateUserApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTypeCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceListType_Page.EnterPriceLisTypeScreen();
                Pages.PriceListType_Page.PriceListTypeCreateApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTypeDeleteTest()
        {
            UITest(() =>
            {
                Pages.PriceListType_Page.EnterPriceLisTypeScreen();
                Pages.PriceListType_Page.PriceListTypeCreateApplication();
                Pages.PriceListType_Page.PriceListTypeDeleteApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTypeEditTest()
        {
            UITest(() =>
            {
                Pages.PriceListType_Page.EnterPriceLisTypeScreen();
                Pages.PriceListType_Page.PriceListTypeCreateApplication();
                Pages.PriceListType_Page.PriceListTypeEditApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTaxCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceListTax_Page.EnterPriceListTaxScreen();
                Pages.PriceListTax_Page.PriceListTaxCreateApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTaxDeleteTest()
        {
            UITest(() =>
            {
                Pages.PriceListTax_Page.EnterPriceListTaxScreen();
                Pages.PriceListTax_Page.PriceListTaxCreateApplication();
                Pages.PriceListTax_Page.PriceListTaxDeleteApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTaxEditTest()
        {
            UITest(() =>
            {
                Pages.PriceListTax_Page.EnterPriceListTaxScreen();
                Pages.PriceListTax_Page.PriceListTaxCreateApplication();
                Pages.PriceListTax_Page.PriceListTaxEditApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListCreateTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EntePriceListTab();
                Pages.PriceList_Page.DevCreatePriceListDevApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListCreatePackageTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EntePriceListTab();
                Pages.PriceList_Page.DevCreatePriceListPackageApplicaiton();
            }, Pages.PriceList_Page.PriceListCancelDev);
        }

        [Test, Category("Settings")]
        public void PriceListUpdateTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EntePriceListTab();
                Pages.PriceListUpdate_Page.UpdateBasePriceListApplication();
            });
        }

        //additional fields
        [Test, Category("Settings")]
        public void AdditionalFieldCreateTest()
        {
            UITest(() => 
            {
                Pages.AdditinalFields_Page.DevEnterAdditionalFieldsScreen();
                Pages.AdditinalFields_Page.OpenFieldsManager();
                Pages.AdditinalFields_Page.AdditionalFieldApplication();

            }, Pages.AdditinalFields_Page.CloseFieldWindow);
        }

        [Test, Category("Settings")]
        public void RightBarPannelTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.RightBarApplication();
            });
        }

        //+++++++++++++ Tests++++++++++++++++++//

        [Test, Category("Reports")]
        public void ReportPatientTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreen();
                Pages.Reports_Page.PatientReportApplication();
            }, Pages.Reports_Page.PopupButton);
        }

        [Test, Category("Reports")]
        public void ReportContactTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreen();
                Pages.Reports_Page.ContactReportApplication();

            }, Pages.Reports_Page.PopupButton);
        }

        [Test, Category("Reports")]
        public void ReportMeetingTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreen();
                Pages.Reports_Page.MeetingReportApplication();
            }, Pages.Reports_Page.PopupButton);
        }

        [Test, Category("Reports")]
        public void ReportNotificationTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreen();
                Pages.Reports_Page.NotificationReportApplication();
            }, Pages.Reports_Page.PopupButton);
        }

        [Ignore("Not ready")]
        [Test, Category("Reports")]
        public void ReportAuditTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.EnterReportScreen();
                Pages.Reports_Page.AuditReportApplication();
            }, Pages.Reports_Page.PopupButton);
        }

        //+++++++++++++Scheduler Tests++++++++++++++++++//

        [Test, Category("Scheduler")]
        public void LockTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.LockApplication();
            });
        }

        [Test, Category("Scheduler")]
        public void DragAndDropToWaitList()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.Scheduler_Page.CreateMeetingOnTodayCell();
                Pages.Scheduler_Page.DragAndDropTemporaryList();
            });
        }

        [Test, Category("Scheduler")]
        public void DragAndDropToStandby()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.Scheduler_Page.CreateMeetingOnTodayCell();
                Pages.Scheduler_Page.DragAndDropStandbyList();

            }, Pages.Scheduler_Page.CancelledMeetingWindow);
 

        }

        [Test, Category("Scheduler")]
        public void ReportDailyTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.EnterDailyReportScreen();
                Pages.Scheduler_Page.SchedulerEventPrintCancel.ClickOn();
            });
        }

        [Test, Category("Scheduler")]
        public void ReportCancelledMeetingTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.EnterCancelledMeetingWindow();
                Pages.CancelledMeeting_Page.CloseWindow.ClickOn();
            });
        }

        [Test, Category("Scheduler")]
        public void OpenBlockListWindowTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.EnterOpenBlockWindow();
                Pages.BlockOpen_Page.CloseWindow.ClickOn();
            });
        }

        [Test, Category("Scheduler")]
        public void StandbyListWindowTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.EnterStanbyWindow();
                Pages.StandbyList_Page.CloseWindow.ClickOn();
            });
        }

        [Test, Category("Scheduler")]
        public void BlockCreateEmptyTest()
        {
            UITest(() =>
            {
                Pages.BlockOpen_Page.BlockCreateEmptyApplication();
            });
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
                Pages.Meeting_Page.CreateMeetingApplication();
            }, Pages.Meeting_Page.CancelMeeting);

        }

        [Test, Category("Scheduler")]
        public void StandbyCreateTest()
        {
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.Standby_Page.CreateStandbyApplication();
            });
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

        [Ignore("no ready")]
        [Test, Category("Authorization")]
        public void ManagerLoginTest()
        {
            UITest(() =>
            {
                Pages.Login_Page.LoginApplication();
            });
        }


        [Test, Category("Authorization")]
        public void TherapistLoginTest()
        {
            UITest(() =>
            {
                Pages.Login_Page.TherapistLogin();
            });

        }

        [Test, Category("Authorization")]
        public void ClerkLoginTest()
        {
            UITest(() =>
            {
                Pages.Login_Page.ClerkApplication();
            });
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
                Pages.Home_Page.EnterAvailbleTime();
                Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
                Pages.Meeting_Page.CreateMeetingApplication();
            });
        }

        [Test, Category("Smoke"), Order(1)]
        public void SmokeTesting()
        {
            UITest(() =>
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
            });
        }
    }

}
