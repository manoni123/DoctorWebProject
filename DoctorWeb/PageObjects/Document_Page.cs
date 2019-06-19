using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Document_Page
    {
         
        AssertionExtent softAssert = new AssertionExtent();
      
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        [FindsBy(How = How.XPath, Using = "//*[@id=\"mainTabStrip\"]/ul/li[2]")]
        [CacheLookup]
        public IWebElement NewPatiantTabClick { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "העלאת קובץ")]
        [CacheLookup]
        public IWebElement UplaodFileBtn { get; set; }

        [FindsBy(How = How.Name, Using = "fileUploader")]
        [CacheLookup]
        public IWebElement SelectFile { get; set; }

        [FindsBy(How = How.Name, Using = "btnCancelUploadDocuments")]
        [CacheLookup]
        public IWebElement btnCancelUploadDocuments { get; set; }

        [FindsBy(How = How.Name, Using = "btnUploadDocuments")]
        [CacheLookup]
        public IWebElement UploadWindowSave { get; set; }

        public void UploadFileApplication()
        {
            Pages.Patient_Page.NewPatientApplication();
            Thread.Sleep(1500);
            Pages.Patient_Page.PatientDocument.ClickWait();
            var patientDataID = Browser.Driver.FindElement(By.ClassName("mainTabPrefix")).GetAttribute("data-entity-id");
            Thread.Sleep(1000);
            IWebElement UplaodBtn = Browser.Driver.FindElement(By.Id("tab3_btnAddCustomerDocument_" + patientDataID));
            UplaodBtn.ClickOn();
            SelectFile.SendKeys("\\\\RON-PC\\Ron-Shared\\AutomationUpload\\file.txt");
            UploadWindowSave.ClickOn();
            softAssert.VerifyElementIsPresent(Browser.Driver.FindElement(By.XPath("//*[@id='tab3_gridCustomerDocuments_" + patientDataID + "']/div[2]/div[1]/table/tbody/tr/td[8]/a[2]")));
        }
    }
}
