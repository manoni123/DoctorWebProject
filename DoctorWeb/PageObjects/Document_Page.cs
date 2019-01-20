using DoctorWeb.Utility;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
   public class Document_Page
    {
         
        AssertionExtent softAssert = new AssertionExtent();

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.Id, Using = "tab2_btnAddCustomerDocument_1")]
        [CacheLookup]
        public IWebElement UploadDocument { get; set; }

        [FindsBy(How = How.ClassName, Using = "control-label")]
        [CacheLookup]
        public IWebElement CreateUploadDate { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelUploadDocuments-label")]
        [CacheLookup]
        public IWebElement CancelUpload { get; set; }

        [FindsBy(How = How.ClassName, Using = "control-label")]
        [CacheLookup]
        public IWebElement ConfirmUpload { get; set; }

        [FindsBy(How = How.ClassName, Using = "k-button k-upload-button")]
        [CacheLookup]
        public IWebElement OpenUpload { get; set; }

        public void PatientUploadApplication() {
            OpenUpload.ClickOn(Constant.Click);
            softAssert.VerifyElementPresentInsideWindow(CreateUploadDate, CancelUpload);
        }

    }
}
