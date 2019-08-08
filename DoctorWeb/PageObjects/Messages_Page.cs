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
    public class Messages_Page
    {
         
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
    
        [FindsBy(How = How.XPath, Using = "//[contains(text(), 'מועד שליחה)]")]
        [CacheLookup]
        public IWebElement PatientValidation { get; set; }

        public void PatientMessageApplication() {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.EnterPatientMessages();
        }

        public void PatientMessageApplicationProd()
        {
            Pages.Patient_Page.NewPatientApplication();
            Pages.Patient_Page.EnterPatientMessagesProd();
        }
    }
}
