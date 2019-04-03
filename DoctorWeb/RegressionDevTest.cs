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
            }, Pages.Patient_Page.ClosePatientTab);
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
            }, Pages.Home_Page.PopupClose);
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
        public void AnamnezaCreateTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.CreateNewAnamnezaApplication();
            }, Pages.PatientMedical_Page.CloseAnamnezaTable);
        }

        [Ignore("ff")]
        [Test, Category("Medical")]
        public void AnamnezaSaveWhenCreate()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.CreateNewAnamnezaWhenSaveApplication();
            },  Pages.PatientMedical_Page.CloseAnamnezaTable);
        }

        [Test, Category("Medical")]
        public void AnamnezaEditTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EditNewAnamnezaApplication();
            }, Pages.PatientMedical_Page.CloseAnamnezaTable);
        }

        [Test, Category("Medical")]
        public void AnamnezaDeleteTest()
        {
            UITest(() =>
            {
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
        public void NoteCreateTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.CreateNewNoteApplication();
            }, Pages.PatientMedical_Page.CloseNotesTable);
        }

        [Test, Category("Medical")]
        public void NoteEditTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EditNoteApplication();
            }, Pages.PatientMedical_Page.CloseNotesTable);
        }

        [Test, Category("Medical")]
        public void NoteDeleteTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.DeleteNoteApplication();
            }, Pages.PatientMedical_Page.CloseNotesTable);
        }
        //medicine
        [Test, Category("Medical")]
        public void MedicineCreateTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
            }, Pages.PatientMedical_Page.CancelMedicineTable);
        }

        [Test, Category("Medical")]
        public void MedicineEditTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.EditMedicineApplication();
            }, Pages.PatientMedical_Page.CancelMedicineTable);
        }

        [Test, Category("Medical")]
        public void MedicineDeleteTest()
        {
            UITest(() =>
            {
                Pages.PatientMedical_Page.DeleteMedicineApplication();
            }, Pages.PatientMedical_Page.CancelMedicineTable);
        }


        [Test, Category("Medical")]
        public void MedicalWarningTest()
        {
            UITest(() =>
            {
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
        public void ExpertiseCreateTest()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.CreatePracticeApplication();
            }, Pages.UsersManagement_Page.PracticeWindowClose);
        }

        [Test, Category("Settings")]
        public void ExpertiseEditTest()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.EditPracticeApplication();
            }, Pages.UsersManagement_Page.PracticeWindowClose);
        }

        [Test, Category("Settings")]
        public void ExpertiseDeleteTest()
        {
            UITest(() =>
            {
                Pages.UsersManagement_Page.DeletePracticeApplication();
            }, Pages.UsersManagement_Page.PracticeWindowClose);
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
        public void DepartmentCreateTest()
        {
            UITest(() =>
            {
                Pages.Business_Page.CreateDepartmentApplication();
            }, Pages.Business_Page.DepartmentCloseButton);
        }

        [Test, Category("Settings")]
        public void DepartmentDeleteTest()
        {
            UITest(() =>
            {
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
        public void DepartmentEditTest()
        {
            UITest(() =>
            {
                Pages.Business_Page.EditDepartmentApplicaiton();
                Pages.Business_Page.DepartmentCloseButton.ClickOn();
            }, Pages.Business_Page.DepartmentCloseButton);

        }

        [Test, Category("Settings")]
        public void CategoryCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.CreateCategoryApplication();
            });
        }

        [Test, Category("Settings")]
        public void CategoryDeleteTest()
        {
            UITest(() =>
            {
                Pages.PriceList_Page.DeleteCategoryApplication();
            });
        }

        [Test, Category("Settings")]
        public void CategoryEditTest()
        {
            UITest(() =>
            {
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
            }, Pages.Business_Page.BusinessClose);
        }

        [Test, Category("Settings")]
        public void BranchCreateTest()
        {
            UITest(() =>
            {   
                Pages.Business_Page.CreateBranchApplication();
            }, Pages.Business_Page.BranchCancelButton);
        }

        [Test, Category("Settings")]
        public void GroupCreateTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.CreateGroupApplication();
            }, Pages.Authorization_Page.GroupCancel);
        }

        [Test, Category("Settings")]
        public void GroupEditTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.EditGroupApplication();
            }, Pages.Authorization_Page.GroupCancel);
        }

        [Test, Category("Settings")]
        public void GroupDeleteTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.DeleteGroupApplication();
            }, Pages.Authorization_Page.GroupCancel);
        }

        [Test, Category("Settings")]
        public void GroupImportTest()
        {
            UITest(() =>
            {
                Pages.Authorization_Page.ImportUsersToSecretaryGroupApplication();
            });
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
            }, Pages.Home_Page.PopupClose);
        }

        [Test, Category("Settings")]
        public void PriceListTypeCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceListType_Page.PriceListTypeCreateApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTypeDeleteTest()
        {
            UITest(() =>
            {
                Pages.PriceListType_Page.PriceListTypeDeleteApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTypeEditTest()
        {
            UITest(() =>
            {
                Pages.PriceListType_Page.PriceListTypeEditApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTaxCreateTest()
        {
            UITest(() =>
            {
                Pages.PriceListTax_Page.PriceListTaxCreateApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTaxDeleteTest()
        {
            UITest(() =>
            {
                Pages.PriceListTax_Page.PriceListTaxDeleteApplication();
            });
        }

        [Test, Category("Settings")]
        public void PriceListTaxEditTest()
        {
            UITest(() =>
            {
                Pages.PriceListTax_Page.PriceListTaxEditApplication();
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
                Pages.Reports_Page.PatientReportApplication();
            }, Pages.Reports_Page.PopupButton);
        }

        [Test, Category("Reports")]
        public void ReportContactTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.ContactReportApplication();
            }, Pages.Reports_Page.PopupButton);
        }

        [Test, Category("Reports")]
        public void ReportMeetingTest()
        {
            UITest(() =>
            {
                Pages.Reports_Page.MeetingReportApplication();
            }, Pages.Reports_Page.PopupButton);
        }

        [Test, Category("Reports")]
        public void ReportNotificationTest()
        {
            UITest(() =>
            {
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
            }, Pages.Scheduler_Page.CancelledMeetingWindow, Pages.Home_Page.PopupClose);
        }

        [Test, Category("Scheduler")]

        public void DragAndDropToStandbyTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.DragAndDropStandbyList();
            }, Pages.Scheduler_Page.CancelledMeetingWindow, Pages.Home_Page.PopupClose);
         }

        [Test, Category("Scheduler")]
        public void StandbyMeetingSetTest()
        {
            UITest(() =>
            {
                Pages.Scheduler_Page.StandbySetMeetingApplication();
            }, Pages.Standby_Page.CancelStandby);
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
                Pages.Standby_Page.CreateStandbyApplication();
            }, Pages.Scheduler_Page.StandbyAppointmentCancel, Pages.Home_Page.PopupClose);
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
                Pages.PatientMedical_Page.CreateNewMedicineApplication();
                Pages.PatientMedical_Page.EnterNoteTable();
                Pages.PatientMedical_Page.CreateNewNoteApplication();
                Pages.Home_Page.CloseTab.ClickOn();
                Pages.Home_Page.EnterAvailbleTime();
                Pages.AvailbleTime_Page.SearchAvailbleTimeApplication();
                Pages.Meeting_Page.CreateMeetingApplication();
            }, Pages.Home_Page.PopupClose, Pages.Home_Page.PopupClose);
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
                Pages.Home_Page.DevPricelistScreen.ClickWait();
                Constant.priceListExistCode = Browser.Driver.FindElement(By.XPath("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody/tr[1]/td[1]")).Text;
                Pages.Home_Page.GeneralScreen.ClickWait();
                Pages.Patient_Page.NewPatientApplication();
                Pages.Patient_Page.ClosePatientTab.ClickOn();
                Pages.Scheduler_Page.AvailbleTime_Btn.ClickOn();
                Pages.Home_Page.PopupClose.ClickOn();
            },Pages.Home_Page.PopupClose, Pages.Home_Page.PopupClose);
        }
    }
}
