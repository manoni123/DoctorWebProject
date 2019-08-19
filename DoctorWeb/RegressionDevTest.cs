using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

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
            Log.Info(Environment.NewLine + Environment.NewLine + "                          +++++++++++      "
                + TestContext.CurrentContext.Test.MethodName + "      ++++++++++++" + Environment.NewLine);
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
            UITest(() =>
            {
                Pages.Patient_Page.NewPatientApplication();
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
            }, Pages.Patient_Page.ClosePatientTab, Pages.Meeting_Page.CancelMeeting, Pages.AvailbleTime_Page.CloseWindow);
        }

        [Test, Category("Patient")]
        public void PatientMessageTest()
        {
            UITest(() =>
            {
                Pages.Messages_Page.PatientMessageApplication();
            }, Pages.Patient_Page.ClosePatientTab);
        }

        [Test, Category("Patient")]
        public void PatientCreateNewMultipleTest()
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
        public void PatientCloseTabBeforeSaveTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.OpenEntityDropdown.ClickOn();
                Pages.Home_Page.CreateNewPatient.ClickWait();
                softAssert.VerifyElementIsPresent(Pages.Patient_Page.PatientName);
                Pages.Patient_Page.PatientName.SendKeys(Constant.patientName);
                Pages.Home_Page.CloseTab.ClickOn();
                softAssert.VerifyElementPresentInsideWindow(Pages.Home_Page.PopupButtonOk, Pages.Home_Page.PopupButtonCancel);
                Pages.Home_Page.PopupButtonOk.ClickOn();
            }, Pages.Patient_Page.ClosePatientTab);
        }

        [Test, Category("Treatments")]
        public void TreatmentCreateSingleTest()
        {
            UITest(() =>
            {
                Pages.Treatment_Page.CreateNewSingleTreatmentApplication();
            }, Pages.TreatmentPlan_Page.TreatmentPlanCancel);
        }

        [Ignore("")]
        [Test, Category("Users")]
        public void AuthorizationSecretaryTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.SecretaryPermissionApplication();
            });
        }
        //+++++++++++++Medical Tab Tests++++++++++++++++++//

        [Test, Category("Medical")]
        public void AnamnezaCrudTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EnterAnamnezaTable();
                Pages.PatientMedical_Page.CreateNewAnamnezaApplication();
                Pages.PatientMedical_Page.EditNewAnamnezaApplication();
                Pages.PatientMedical_Page.DeleteNewAnamanezaApplication();
            }, Pages.PatientMedical_Page.CloseAnamnezaTable);
        }

        [Ignore("ff")]
        [Test, Category("Medical")]
        public void AnamnezaSaveWhenCreate()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.CreateNewAnamnezaWhenSaveApplication();
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
        public void NoteCrudTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.CreateNewNoteApplication();
                Pages.PatientMedical_Page.EditNoteApplication();
                Pages.PatientMedical_Page.DeleteNoteApplication();
            }, Pages.PatientMedical_Page.CloseNotesTable);
        }

        [Test, Category("Medical")]
        public void MedicineCrudTest()
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
            UITest(() =>
            {
                Pages.Supplier_Page.NewSupplierCreateApplication();
            });
        }

        [Test, Category("Entity")]
        public void SupplierContactCreateTest()
        {
            UITest(() =>
            {
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
                Pages.Home_Page.FilterImageApplication();
            });
        }


        [Test, Category("Settings")]
        public void ExpertiseCrudTest()
        {
            UITest(() =>
            {
                Pages.Home_Page.EnterUserManagmentScreen();
                Pages.UsersManagement_Page.EnterPracticeWindow();
                Pages.UsersManagement_Page.CreatePracticeApplication();
                Pages.UsersManagement_Page.EditPracticeApplication();
                Pages.UsersManagement_Page.DeletePracticeApplication();
            }, Pages.Home_Page.PopupClose, Pages.UsersManagement_Page.PracticeWindowClose);
        }

        [Test, Category("Settings")]
        public void UserTherapistCreate()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.CreateTherapistUserApplication();
            }, Pages.Home_Page.PopupClose);
        }

        [Test, Category("Settings")]
        public void DepartmentCrudTest()
        {
            UITest(() =>
            {
                utility.SuperUserOnlyTest();
                Pages.Business_Page.CreateDepartmentApplication();
                Pages.Business_Page.EditDepartmentApplicaiton();
                Pages.Business_Page.DeleteDepartmentApplication();
                Pages.Business_Page.DepartmentCloseButton.ClickOn();
            }, Pages.Business_Page.DepartmentCloseButton);
        }

        [Ignore("ff")]
        [Test, Category("Settings")]
        public void DepartmentActiveDeleteTest()
        {
            UITest(() =>
            {
                Pages.Business_Page.DeleteActiveDepartmentApplication();
            }, Pages.Business_Page.DepartmentCloseButton);

        }

        [Test, Category("Settings")]
        public void CategoryCrudTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.GoTo();
                Pages.PriceList_Page.CreateCategoryApplication();
                Pages.PriceList_Page.EditCategoryApplication();
                Pages.PriceList_Page.DeleteCategoryApplication();
            });
        }

        [Test, Category("Settings")]
        public void BusinessCreateTest()
        {
            UITest(() =>
            {
                utility.SuperUserOnlyTest();
                Pages.Business_Page.EnterSettingScreen();
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
                utility.SuperUserOnlyTest();
                Pages.Business_Page.EnterSettingScreen();
                Pages.Business_Page.CreateBranchApplication();
            }, Pages.Business_Page.BranchCancelButton);
        }

        [Test, Category("Settings")]
        public void GroupCRUDTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.GoTo();
                Pages.Authorization_Page.CreateGroupApplication();
                Pages.Authorization_Page.EditGroupApplication();
                Pages.Authorization_Page.DeleteGroupApplication();
            }, Pages.Authorization_Page.GroupCancel);
        }

        [Test, Category("Settings")]
        public void GroupImportTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.ImportUsersToSecretaryGroupApplication();
            }, Pages.Authorization_Page.CancelUserImport);
        }

        [Test, Category("Settings")]
        public void TreatmentPlanCreate()
        {
            UITest(() =>
            {
                Pages.TreatmentPlan_Page.CreateNewTreatmentPlanApplication();
            }, Pages.Home_Page.PopupClose, Pages.Home_Page.PopupClose);
        }

        //users
        [Test, Category("Settings")]
        public void UserCreateTest()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.CreateUserApplication();
            }, Pages.Home_Page.PopupClose);
        }

        //users
        [Test, Category("Settings")]
        public void UserEditTest()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.UserEditApplication();
            }, Pages.UsersManagement_Page.UserCancelBtn);
        }

        [Test, Category("Settings")]
        public void PriceListTypeCRUDTest()
        {
            UITest(() =>
            {
                Pages.PriceListType_Page.PriceListTypeCreateApplication();
                Pages.PriceListType_Page.PriceListTypeEditApplication();
                Pages.PriceListType_Page.PriceListTypeDeleteApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTaxCRUDTest()
        {
            UITest(() =>
            {
                Pages.PriceListTax_Page.PriceListTaxCreateApplication();
                Pages.PriceListTax_Page.PriceListTaxEditApplication();
                Pages.PriceListTax_Page.PriceListTaxDeleteApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.DevCreatePriceListApplication();
            }, Pages.PriceList_Page.PriceListCancelDev);
        }

        [Test, Category("Settings")]
        public void PriceListCreateSeriesTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.DevCreatePriceListSeriesApplicaiton();
            }, Pages.PriceList_Page.PriceListCancelDev);
        }

        [Test, Category("Settings")]
        public void PriceListUpdateTest()
        {
            UITest(() =>
            {
                Pages.PriceListUpdate_Page.UpdateBasePriceListApplication();
            });
        }

        //additional fields
        [Test, Category("Settings")]
        public void AdditionalFieldCreateTest()
        {
            UITest(() => 
            {
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
                Pages.Reports_Page.PatientReportTab.ClickWait();
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
        public void DragAndDropToWaitList()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.DragAndDropTemporaryList();
            }, Pages.Scheduler_Page.CancelledMeetingWindow);
        }

        [Test, Category("Scheduler")]

        public void DragAndDropToStandbyTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.DragAndDropStandbyList();
            }, Pages.Scheduler_Page.CancelledMeetingWindow, Pages.Standby_Page.CancelStandby);
         }

        [Test, Category("Scheduler")]
        public void StandbyMeetingSetTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.StandbySetMeetingApplication();
            }, Pages.Standby_Page.CancelStandby, Pages.Home_Page.PopupCloseClass);
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
            }, Pages.Home_Page.PopupClose);
        }

        [Test, Category("Scheduler")]
        public void StandbyListWindowTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.EnterStanbyWindow();
                Pages.StandbyList_Page.CloseWindow.ClickOn();
            }, Pages.Home_Page.PopupClose);
        }

        [Test, Category("Scheduler")]
        public void BlockCreateEmptyTest()
        {
            UITest(() =>
            {
                Pages.BlockOpen_Page.BlockCreateEmptyApplication();
            }, Pages.Home_Page.PopupClose);
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
               //Pages.PriceList_Page.PriceListFirstCodeName();;
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.AvailbleTime_Page.GoTo();
                Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
                Pages.Meeting_Page.CreateMeetingApplication();
            }, Pages.Meeting_Page.CancelMeeting, Pages.Meeting_Page.CancelTreatmentFromPricelist);
        }

        [Test, Category("Scheduler")]
        public void StandbyCreateTest()
        {
            UITest(() =>
            {
                Pages.Standby_Page.CreateStandbyApplication();
            }, Pages.Scheduler_Page.StandbyAppointmentCancel, Pages.Home_Page.PopupClose);
        }

        [Test, Category("Scheduler")]
        public void AvailbleTimeTest()
        {
            UITest(() =>
            {
                Pages.AvailbleTime_Page.GoTo();
                Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
                Pages.Meeting_Page.CancelMeeting.ClickOn();
            }, Pages.AvailbleTime_Page.CloseWindow);
        }

        //Create Patient > Create MEdicine> Create Note > Search Availble Time
        [Ignore("need fix")]
        [Test, Category("EndToEnd")]
        public void PatientMedicineNoteAppointment()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.CreateNewNoteApplication();
                Pages.Home_Page.CloseTab.ClickOn();
                Pages.AvailbleTime_Page.GoTo();
                Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
                Pages.Meeting_Page.CreateMeetingApplication();
            }, Pages.Home_Page.PopupClose, Pages.Home_Page.PopupClose);
        }

        [Test, Category("Smoke"), Order(1)]
        public void SmokeTesting()
        {
            UITest(() =>
            {
                Pages.Home_Page.EnterSettingScreen();
                Pages.Scheduler_Page.GoTo();
                Pages.UsersManagement_Page.GoTo();
                Pages.Scheduler_Page.GoTo();
                Pages.Authorization_Page.GoTo();
                Pages.Scheduler_Page.GoTo();
                Pages.PriceList_Page.GoTo();
                Pages.Scheduler_Page.GoTo();
                Pages.Home_Page.EnterGeneralScreen();
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.AvailbleTime_Page.GoTo();
                Pages.AvailbleTime_Page.CloseWindow.ClickOn();
            },Pages.Home_Page.PopupClose, Pages.Home_Page.PopupClose);
        }
    }
}
