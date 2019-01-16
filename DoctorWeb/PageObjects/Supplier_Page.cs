using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class Supplier_Page
    {
        AssertionExtent softAsserts = new AssertionExtent();

        [FindsBy(How = How.Id, Using = "tab2_Name")]
        [CacheLookup]
        public IWebElement SupplierName { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_btnSaveSupplierDetails0")]
        [CacheLookup]
        public IWebElement SupplierSave { get; set; }

        [FindsBy(How = How.Id, Using = "tab2_btnSaveSupplierDetails0")]
        [CacheLookup]
        public IWebElement SuppleirAfterSave { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tab3_supplierTabStrip > ul > li.k-item.k-state-default.k-last")]
        [CacheLookup]
        public IWebElement SupplierContactTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tab3_SelectSupplierContactsGrid > div.k-header.k-grid-toolbar > a")]
        [CacheLookup]
        public IWebElement CreateSupplierContact { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        [CacheLookup]
        public IWebElement SuppContName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        [CacheLookup]
        public IWebElement SuppContLast { get; set; }

        [FindsBy(How = How.Id, Using = "Mobile")]
        [CacheLookup]
        public IWebElement SuppContPhone { get; set; }

        [FindsBy(How = How.Id, Using = "tab2.Name_validationMessage")]
        [CacheLookup]
        public IWebElement supplierNameValidate { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName_validationMessage")]
        [CacheLookup]
        public IWebElement supplierContactNameValidate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_SelectSupplierContactsGrid']/div[3]/table/tbody/tr[1]/td[9]/a[1]")]
        [CacheLookup]
        public IWebElement SaveNewSupplierContact { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainTabStrip > ul > li.k-item.k-state-default.k-tab-on-top.k-state-active > span.k-link > span.k-link > span")]
        [CacheLookup]
        public IWebElement CloseSupplierTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tab3_SelectSupplierContactsGrid']/div[3]/table/tbody/tr/td[9]/a[1]")]
        [CacheLookup]
        public IWebElement SupplierContactEdit { get; set; }

        //create new supplier
        public void NewSupplierCreateApplication()
        {

            //call Home Page to create supplier
            //open entity list and press the new supplier
            Pages.Home_Page.OpenEntityDropdown.ClickOn();
            Pages.Home_Page.CreateNewSupplier.ClickOn();
            SupplierName.SendKeys("1");
            SupplierSave.ClickOn();
            softAsserts.VerifyElementIsPresent(supplierNameValidate);
            SupplierName.EnterClearText(Constant.supplierName, "SupplierName");
            SupplierSave.ClickOn();
            SupplierContactTab.ClickWait(500);
            softAsserts.VerifyElementIsPresent(CreateSupplierContact);
        }

        //create new supplier contact
        public void NewSupplierContactApplication()
        {
            CreateSupplierContact.Click();
            softAsserts.VerifyElementIsPresent(SuppContName);
            SuppContName.SendKeys("1");
            SaveNewSupplierContact.ClickOn();
            softAsserts.VerifyElementIsPresent(supplierContactNameValidate);
            SuppContName.EnterClearText(Constant.suppContactName, "SuppName");
            SuppContLast.EnterClearText(Constant.suppContactLast, "SuppLastName");
            SuppContPhone.EnterClearText(Constant.suppContactPhone, "SuppPhone");
            SaveNewSupplierContact.ClickOn();
            softAsserts.VerifyElementIsPresent(SupplierContactEdit);
           
        }
    }
}
