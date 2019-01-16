﻿using DoctorWeb.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class PriceListTax_Page
    {
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.CssSelector, Using = "#priceListTabStrip > ul > li:nth-child(4) > span")]
        [CacheLookup]
        public IWebElement PriceListTaxScreen { get; set; }

        [FindsBy(How = How.Id, Using = "btnPriceListTaxationSettingsCreateNew")]
        [CacheLookup]
        public IWebElement PriceListTaxCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListTaxationGrid']/div[2]/table/tbody/tr[1]/td[5]/a[1]")]
        [CacheLookup]
        public IWebElement PriceListTaxApprove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListTaxationGrid']/div[2]/table/tbody/tr[1]/td[5]/a[2]")]
        [CacheLookup]
        public IWebElement PriceListTaxCancel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListTaxationGrid']/div[2]/table/tbody/tr[1]/td[5]/a[1]")]
        [CacheLookup]
        public IWebElement PriceListTaxEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListTaxationGrid']/div[2]/table/tbody/tr[1]/td[5]/a[2]")]
        [CacheLookup]
        public IWebElement PriceListTaxDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListTaxationGrid']/div[2]/table/tbody/tr[1]/td[2]/span[1]/span/input[1]")]
        [CacheLookup]
        public IWebElement PriceListTaxName { get; set; }

        [FindsBy(How = How.Id, Using = "Percent_validationMessage")]
        [CacheLookup]
        public IWebElement NameErrorMsg { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement DeleteApprove { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-cancel")]
        [CacheLookup]
        public IWebElement DeleteCancel { get; set; }

        public void EnterPriceListTaxScreen() {
            Pages.Home_Page.EntePriceListTab();
            PriceListTaxScreen.ClickOn();
            softAssert.VerifyElementIsPresent(PriceListTaxCreate);
        }

        public void PriceListTaxCreateApplication() {
            try
            {
                int countBefore = utility.ListCount("//*[@id='PriceListTaxationGrid']/div[2]/table/tbody");
                PriceListTaxCreate.Click();
                PriceListTaxApprove.Click();
                softAssert.VerifyElementIsPresent(NameErrorMsg);
                PriceListTaxName.EnterText(Constant.priceListTax);
                PriceListTaxApprove.Click();
                int countAfter = utility.ListCount("//*[@id='PriceListTaxationGrid']/div[2]/table/tbody");
            }
            catch (IndexOutOfRangeException)
            {
                softAssert.VerifyElementIsPresent(Pages.Home_Page.ErrorPopup);
                Assert.Fail("test OK - repeated numbers");
            }
        }

        public void PriceListTaxDeleteApplication()
        {
            int countBefore = utility.ListCount("//*[@id='PriceListTaxationGrid']/div[2]/table/tbody");
            PriceListTaxDelete.ClickOn();
            DeleteApprove.ClickOn();
            softAssert.VerifyElementIsPresent(Pages.Home_Page.SuccessPopup);
            int countAfter = utility.ListCount("//*[@id='PriceListTaxationGrid']/div[2]/table/tbody");
        }

        public void PriceListTaxEditApplication()
        {
            try
            {
                PriceListTaxEdit.ClickOn();
                PriceListTaxName.EnterClearText(Constant.priceListTax, "edit");
                PriceListTaxApprove.ClickOn();
            }
            catch (IndexOutOfRangeException)
            {
                softAssert.VerifyElementIsPresent(Pages.Home_Page.ErrorPopup);
                Assert.Fail("test OK - repeated numbers");
            }
        }
    }
}
