using DoctorWeb.Utility;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class PatientFamily_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         

        [FindsBy(How = How.Id, Using = "tab4_AddFamilyMember")]
        public IWebElement OpenFamilyWindow { get; set; }

        [FindsBy(How = How.Id, Using = "filterFamilyMembersByText")]
        public IWebElement PatientSearchBar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SelectFamilyMembersGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(5)")]
        public IWebElement SelectRelation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"SelectFamilyMembersGrid\"]/div[2]/table/tbody/tr[1]/td[6]/label")]
        public IWebElement SelectPatientFamily { get; set; }

        [FindsBy(How = How.Id, Using = "btnSelectedFamilyMembersSave")]
        public IWebElement SaveFamilyRelation { get; set; }


        public void AddFamilyRelationApplication()
        {
                 //load Browser.webDrivers

            Pages.Home_Page.SearchBox.SendKeys(Pages.Patient_Page.PatientUseName);
            Thread.Sleep(500);
            Pages.Home_Page.SearchBox.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Pages.Home_Page.SearchBox.SendKeys(Keys.Enter);

            //open that patiant family tab
            Thread.Sleep(500);
            Pages.Patient_Page.RelationFamilyTab.ClickOn();

            //open the family relation window and add new patiant as family member
            OpenFamilyWindow.ClickOn();
            PatientSearchBar.SendKeys(Pages.Patient_Page.PatientUseName);
            Thread.Sleep(500);
            //click on the dropdown cell to enbable the dropdown
            IWebElement element = Browser.Driver.FindElement(By.CssSelector("#SelectFamilyMembersGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(5)"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.Driver;
            js.ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(500);
            //press down on keyboard to select a value
            Actions actions = new Actions(Browser.chromebDriver);
            actions.KeyDown(Keys.Control).SendKeys(Keys.ArrowDown).Perform();
            Log.Info("press on relative type");
            SelectPatientFamily.ClickOn();
            Log.Info("selected the patient");
            SaveFamilyRelation.ClickOn();
            Log.Info("saved patient ");
        }
    }
}
