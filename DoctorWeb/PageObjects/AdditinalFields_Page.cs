using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using DoctorWeb.Utility;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace DoctorWeb.PageObjects
{
    public class AdditinalFields_Page
    {
        
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();


        [FindsBy(How = How.CssSelector, Using = "#generalTabstrip > ul > li:nth-child(2)")]
        [CacheLookup]
        public IWebElement AdditionalFieldsScreen { get; set; }
        
        [FindsBy(How = How.Id, Using = "btnManageMoreFields")]
        [CacheLookup]
        public IWebElement OpenFieldManager { get; set; }

        [FindsBy(How = How.Id, Using = "btnMoreFieldsManagerCreateNew")]
        [CacheLookup]
        public IWebElement CreateNewField { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement FieldName { get; set; }

        [FindsBy(How = How.Id, Using = "FieldValues_0_")]
        public IWebElement DropdownValue { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveMoreField")]
        [CacheLookup]
        public IWebElement FieldSave { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"addMoreFieldsForm\"]/table/tbody/tr[2]/td[2]/div/span")]
        [CacheLookup]
        public IWebElement SelectFieldType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.k-widget.k-window.k-rtl.k-window-titleless.blue-border > span")]
        [CacheLookup]
        public IWebElement CloseFieldWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"moreFieldsManagmentGrid2\"]/div[2]/table/tbody/tr[11]/td[3]/a[2]/span")]
        [CacheLookup]
        public IWebElement DeleteIcon { get; set; }

        //create new additional Field application

        public void EnterAdditionalFieldsScreen() {
            //call home page to enter general setting
            Pages.Home_Page.SettingScreen.ClickWait("setting");
            Pages.Home_Page.GeneralScreen.ClickWait("General");
            AdditionalFieldsScreen.ClickWait("AdditionalField");
        }

        public void DevEnterAdditionalFieldsScreen()
        {
            Pages.Home_Page.SettingScreen.ClickWait("setting");
            Pages.Home_Page.DevGeneralScreen.ClickWait("General");
            AdditionalFieldsScreen.ClickWait("AdditionalField");
        }

        public void OpenFieldsManager() {
            OpenFieldManager.ClickOn("FieldManager");
        }

        public void AdditionalFieldApplication()
        {
            softAssert.VerifyElementPresentInsideWindow(CreateNewField, CloseFieldWindow);
            CreateNewField.ClickOn("CreateFeild");
            FieldSave.ClickOn("FieldSave");
            softAssert.VerifyElementPresentInsideWindow(FieldName, CloseFieldWindow);
            FieldName.EnterClearText(Constant.fieldName);
            FieldSave.ClickOn("FieldSave");
           // softAssert.VerifyElementNotPresent(FieldSave);
            CloseFieldWindow.ClickOn(Constant.CloseWindow);            
        }
    }
}
