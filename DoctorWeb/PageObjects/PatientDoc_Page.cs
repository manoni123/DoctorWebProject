using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DoctorWeb.PageObjects
{
    public class PatientDoc_Page
    {


        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();
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

        public void UploadFileApplication() {
            var patientDataID = Browser.Driver.FindElement(By.ClassName("mainTabPrefix")).GetAttribute("data-entity-id");
            var countBefore = utility.TableCount("//*[@id='tab11_gridCustomerDocuments_" + patientDataID + "']/div[2]/div[1]/table/tbody");
            UplaodFileBtn.ClickOn();
            SelectFile.ClickOn();
            String script = "document.getElementById('SelectFile').value='" + "C:\\\\temp\\\\file.txt" + "';";
            ((IJavaScriptExecutor)Browser.Driver).ExecuteScript(script);
            UploadWindowSave.ClickOn();
            var countAfter = utility.TableCount("//*[@id='tab11_gridCustomerDocuments_" + patientDataID + "']/div[2]/div[1]/table/tbody");
            Assert.AreNotEqual(countBefore, countAfter);
        }
    }
}
