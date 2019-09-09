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
                UtilityFunction utility = new UtilityFunction();

      
        [FindsBy(How = How.XPath, Using = "//*[@id=\"mainTabStrip\"]/ul/li[2]")]
        [CacheLookup]
        public IWebElement NewPatiantTabClick { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-blue-white")]
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
            Pages.Patient_Page.EnterPatientDocument();
            IWebElement UplaodBtn = Browser.Driver.FindElement(By.Id("tab3_btnAddCustomerDocument_" + Constant.patientDataID));
            UplaodBtn.ClickWait();
            SelectFile.SendKeys(Constant.fileForTest);
            UploadWindowSave.ClickOn();
        }
    }
}
