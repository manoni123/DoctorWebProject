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
        
        public IWebElement NewPatiantTabClick { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-blue-white")]
        
        public IWebElement UploadFileBtn { get; set; }

        [FindsBy(How = How.Name, Using = "fileUploader")]
        
        public IWebElement SelectFile { get; set; }

        [FindsBy(How = How.Name, Using = "btnCancelUploadDocuments")]
        
        public IWebElement btnCancelUploadDocuments { get; set; }

        [FindsBy(How = How.Name, Using = "btnUploadDocuments")]
        
        public IWebElement UploadWindowSave { get; set; }

        public void UploadFileApplication()
        {
            Pages.Patient_Page.NewPatientApplication();
            Thread.Sleep(1500);
            Pages.Patient_Page.EnterPatientDocument();
            UploadFileBtn.ClickOn();
            SelectFile.SendKeys(Constant.fileForTest);
            UploadWindowSave.ClickOn();
        }
    }
}
