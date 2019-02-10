using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class PatientMedical_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();

        //Medicine Table Page Elements

        [FindsBy(How = How.Id, Using = "tab3_AddMedicines")]
        [CacheLookup]
        public IWebElement OpenMedicineTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectMedicineGrid\"]/div[1]/a[2]")]
        [CacheLookup]
        public IWebElement CreateNewMedicine { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tab3_SelectMedicineGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr:nth-child(1) > td:nth-child(1)")]
        [CacheLookup]
        public IWebElement CheckMedicineActive { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement MedicalName { get; set; }

        [FindsBy(How = How.Id, Using = "Description")]
        [CacheLookup]
        public IWebElement MedicalDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectMedicineGrid\"]/div[3]/table/tbody/tr[1]/td[4]/label")]
        [CacheLookup]
        public IWebElement CheckMedicineWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectMedicineGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]")]
        [CacheLookup]
        public IWebElement ConfirmCreateMedicine { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectMedicineGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]")]
        [CacheLookup]
        public IWebElement EditMedicine { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectMedicineGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[2]")]
        [CacheLookup]
        public IWebElement DeleteMedicine { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_MedicineGrid']/table/tbody/tr/td[5]/a[1]")]
        [CacheLookup]
        public IWebElement EditMedicineOnUser { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_MedicineGrid']/table/tbody/tr/td[4]/span[1]")]
        [CacheLookup]
        public IWebElement SelectYesMedicineOnUser { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_imgHasWarning']/img")]
        [CacheLookup]
        public IWebElement MedicalWarningIcon { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveMedicine")]
        [CacheLookup]
        public IWebElement SaveMedicineTable { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelMedicine")]
        [CacheLookup]
        public IWebElement CancelMedicineTable { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement ConfirmDelete { get; set; }

        //Anamneza Table Page Elements

        [FindsBy(How = How.Id, Using = "tab3_AddAnamneza")]
        [CacheLookup]
        public IWebElement OpenAnamnezaTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectAnamnezaGrid\"]/div[1]/a[2]")]
        [CacheLookup]
        public IWebElement CreateNewAnamneza { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_SelectAnamnezaGrid']/div[3]/table/tbody/tr[1]/td[1]/label")]
        [CacheLookup]
        public IWebElement CheckAnamnezaActive { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement AnamnezaName { get; set; }

        [FindsBy(How = How.Id, Using = "Description")]
        [CacheLookup]
        public IWebElement AnamnezaDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectAnamnezaGrid\"]/div[3]/table/tbody/tr[1]/td[4]/label")]
        [CacheLookup]
        public IWebElement CheckAnamnezaWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectAnamnezaGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]")]
        [CacheLookup]
        public IWebElement ConfirmCreateAnamneza { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectAnamnezaGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]")]
        [CacheLookup]
        public IWebElement EditAnamneza { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectAnamnezaGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[2]")]
        [CacheLookup]
        public IWebElement DeleteAnamneza { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveAnamneza")]
        [CacheLookup]
        public IWebElement SaveAnamnezaTable { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelAnamneza")]
        [CacheLookup]
        public IWebElement CloseAnamnezaTable { get; set; }

        [FindsBy(How = How.Id, Using = "btnICD_OpenImportDialog")]
        [CacheLookup]
        public IWebElement ICDWindow { get; set; }

        [FindsBy(How = How.Id, Using = "filterICDByText")]
        [CacheLookup]
        public IWebElement ICDSearch { get; set; }

        [FindsBy(How = How.Id, Using = "btnImportICD")]
        [CacheLookup]
        public IWebElement ICDImport { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelICD")]
        [CacheLookup]
        public IWebElement ICDCancel { get; set; }

        //Add Notes Table Page Elements

        [FindsBy(How = How.Id, Using = "tab3_AddNotes")]
        [CacheLookup]
        public IWebElement OpenNotesTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectNotesGrid\"]/div[1]/a")]
        [CacheLookup]
        public IWebElement CreateNewNote { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectNotesGrid\"]/div[3]/table/tbody/tr/td[1]/label")]
        [CacheLookup]
        public IWebElement CheckNoteActive { get; set; }

        [FindsBy(How = How.Id, Using = "Description")]
        [CacheLookup]
        public IWebElement NoteDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectNotesGrid\"]/div[3]/table/tbody/tr/td[3]/label")]
        [CacheLookup]
        public IWebElement CheckNoteWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectNotesGrid\"]/div[3]/table/tbody/tr/td[4]/a[1]")]
        [CacheLookup]
        public IWebElement ConfirmCreateNote { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectNotesGrid\"]/div[3]/table/tbody/tr[1]/td[4]/a[1]")]
        [CacheLookup]
        public IWebElement EditNote { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab3_SelectNotesGrid\"]/div[3]/table/tbody/tr[1]/td[4]/a[2]")]
        [CacheLookup]
        public IWebElement DeleteNote { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveNotes")]
        [CacheLookup]
        public IWebElement SaveNotesTable { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelNotes")]
        [CacheLookup]
        public IWebElement CloseNotesTable { get; set; }


        [FindsBy(How = How.Id, Using = "Description_validationMessage")]
        [CacheLookup]
        public IWebElement DescriptionValidationError { get; set; }

        [FindsBy(How = How.Id, Using = "Name_validationMessage")]
        [CacheLookup]
        public IWebElement NameValidationError { get; set; }



        public void EnterMedicalTab() {
            Pages.Patient_Page.OpenMedicalTab.ClickWait();
        }

        public void EnterMedicineTable() {
            Thread.Sleep(500);
            OpenMedicineTable.ClickOn();
            softAssert.VerifyElementIsPresent(SaveMedicineTable);

        }

        //create new medicine applicaiton
        public void CreateNewMedicineApplication()
        {
            string MedicienNewName = "Med" + RandomNumber.smallNumber();
            var disButton = SaveMedicineTable.GetAttribute("disabled");
            CreateNewMedicine.ClickOn();
            CreateNewMedicine.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(NameValidationError, CancelMedicineTable);
            MedicalName.EnterClearText(Constant.medicineName + RandomNumber.smallNumber());
            MedicalDescription.EnterClearText(Constant.medicineName);
            Thread.Sleep(500);
            ConfirmCreateMedicine.ClickOn();
            Thread.Sleep(500);
            softAssert.VerifyElementPresentInsideWindow(DeleteMedicine, CancelMedicineTable);
            Thread.Sleep(500);
            CheckMedicineActive.ClickOn();
            Thread.Sleep(500);
            SaveMedicineTable.ClickOn();
            Constant.medicineName = MedicienNewName;
        }

        //edit medicine
        public void EditMedicineApplication()
        {
            EditMedicine.ClickOn();
            MedicalName.EnterClearText("MedEdit");
            ConfirmCreateMedicine.ClickOn();
            softAssert.VerifySuccessMsg();
            CancelMedicineTable.ClickOn();
        }

        //delete medicine
        public void DeleteMedicineApplication() {

            if (DeleteMedicine.IsDisplayed("delete medicine"))
            {
                DeleteMedicine.ClickOn();
                softAssert.VerifyElementIsPresent(ConfirmDelete);
                ConfirmDelete.ClickOn();
                Thread.Sleep(500);
                CancelMedicineTable.ClickOn();
            } else {
                CancelMedicineTable.ClickOn();
            }
            
        }

        public void EnterAnamnezaTable()
        {
            Thread.Sleep(500);
            OpenAnamnezaTable.ClickOn();
            softAssert.VerifyElementIsPresent(CloseAnamnezaTable);
        }

        //create new anamneza applicaiton
        public void CreateNewAnamnezaApplication()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.PatientMedical_Page.EnterMedicalTab();
            Pages.PatientMedical_Page.EnterAnamnezaTable();

            var disButton = SaveAnamnezaTable.GetAttribute("disabled");
            string anamnezaNewName = "Anam" + RandomNumber.smallNumber();
            //call patient page to enter medical Tab

            CreateNewAnamneza.ClickOn();
            AnamnezaName.EnterClearText(Constant.anamnezaName);
            AnamnezaDescription.EnterClearText(Constant.anamnezaName + RandomNumber.smallNumber());
            CheckAnamnezaWarning.ClickOn();
            ConfirmCreateAnamneza.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(DeleteAnamneza, CloseAnamnezaTable);
            softAssert.VerifySuccessMsg();
            Thread.Sleep(500);
            CloseAnamnezaTable.ClickOn();
 
            Constant.anamnezaName = anamnezaNewName;         
        }

        public void CreateNewAnamnezaWhenSaveApplication()
        {
            var disButton = SaveAnamnezaTable.GetAttribute("disabled");
            //call patient page to enter medical Tab
            CreateNewAnamneza.ClickOn();
            SaveAnamnezaTable.ClickOn();
            softAssert.VerifyElementIsNotNull(disButton, CloseAnamnezaTable);
            AnamnezaName.EnterClearText(Constant.anamnezaName + RandomNumber.smallNumber());
            AnamnezaDescription.EnterClearText(Constant.anamnezaName);
            CheckAnamnezaWarning.ClickOn();
            ConfirmCreateAnamneza.ClickOn();
            softAssert.VerifySuccessMsg();
            softAssert.VerifyElementPresentInsideWindow(DeleteAnamneza, CloseAnamnezaTable);
          //  CheckAnamnezaActive.ClickOn();
            CloseAnamnezaTable.ClickOn();
        }

        //edit new anamneza application
        public void EditNewAnamnezaApplication() {
            EditAnamneza.ClickOn();
            AnamnezaName.Clear();
            ConfirmCreateAnamneza.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(NameValidationError, CloseAnamnezaTable);
            AnamnezaName.EnterClearText("Edit");
            ConfirmCreateAnamneza.ClickOn();
            CloseAnamnezaTable.ClickOn();
        }

        //delete new anamneza app
        public void DeleteNewAnamanezaApplication() {
            if (DeleteAnamneza.IsDisplayed("delete anamneza"))
            {
                DeleteAnamneza.ClickOn();
                softAssert.VerifyElementIsPresent(ConfirmDelete);
                ConfirmDelete.ClickOn();
                CloseAnamnezaTable.ClickOn();
            }
            else {
                CloseAnamnezaTable.ClickOn();
            }
        }

        public void AddICDApplication() {
            ICDWindow.ClickOn();
            softAssert.VerifyElementInPopupOverWindow(ICDImport, ICDCancel, CloseAnamnezaTable);
            ICDSearch.SendKeys(Constant.ICDData);
            ICDSearch.SendKeys(Keys.Enter);
            ICDImport.ClickOn();
            CloseAnamnezaTable.ClickOn();;
        }

        //enter note table
        public void EnterNoteTable()
        {
            Thread.Sleep(500);
            OpenNotesTable.ClickOn();
            softAssert.VerifyElementIsPresent(SaveNotesTable);
        }

        //create new note applicaiton
        public void CreateNewNoteApplication()
        {
            string NoteNewName = "note" + RandomNumber.smallNumber();

            CreateNewNote.ClickOn();
            NoteDescription.SendKeys(Constant.noteName);
            ConfirmCreateNote.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(DeleteNote, CloseNotesTable);
            EditNote.ClickOn();
            CheckNoteWarning.ClickOn();
            ConfirmCreateNote.ClickOn();
            softAssert.VerifySuccessMsg();
           // CheckNoteActive.ClickOn();
            CloseNotesTable.ClickOn();

            Constant.noteName = NoteNewName;
        }
        //edit desc
        public void EditNoteApplication()
        {
            EditNote.ClickOn();
            NoteDescription.Clear();
            ConfirmCreateNote.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(DescriptionValidationError, CloseNotesTable);
            NoteDescription.EnterClearText("Description");
            ConfirmCreateNote.ClickOn();
            CloseNotesTable.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        //delete note
        public void DeleteNoteApplication()
        {
            if (DeleteNote.IsDisplayed("deelete note"))
            {
                DeleteNote.ClickOn();
                softAssert.VerifyElementIsPresent(ConfirmDelete);
                ConfirmDelete.ClickOn();
                CloseNotesTable.ClickOn();
            }
            else
            {
                CloseNotesTable.ClickOn();
            }
        }

        public void ValidateWarningIndicator()
        {
            Thread.Sleep(500);
            EditMedicineOnUser.ClickOn();
            SelectYesMedicineOnUser.ClickOn();
            SelectYesMedicineOnUser.SendKeys(Keys.ArrowUp);
            SelectYesMedicineOnUser.SendKeys(Keys.Enter);
            Thread.Sleep(500);
            Pages.PatientMedical_Page.OpenMedicineTable.ClickOn();
            Pages.PatientMedical_Page.CancelMedicineTable.ClickOn();
            softAssert.VerifyElementIsPresent(MedicalWarningIcon);
        }
    } 
}
