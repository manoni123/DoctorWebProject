﻿using DoctorWeb.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class PriceListType_Page
    {
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utilityFunction = new UtilityFunction();

        [FindsBy(How = How.CssSelector, Using = "#priceListTabStrip > ul > li:nth-child(3) > span")]
        [CacheLookup]
        public IWebElement PriceListTypeScreen { get; set; }

        [FindsBy(How = How.Id, Using = "btnPriceListCreateNew")]
        [CacheLookup]
        public IWebElement PriceListTypeCreate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListIndexGrid']/div[2]/table/tbody/tr[1]/td[4]/a[1]")]
        [CacheLookup]
        public IWebElement PriceListTypeApprove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListIndexGrid']/div[2]/table/tbody/tr[1]/td[4]/a[2]")]
        [CacheLookup]
        public IWebElement PriceListTypeCancel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListIndexGrid']/div[2]/table/tbody/tr[1]/td[4]/a[1]")]
        [CacheLookup]
        public IWebElement PriceListTypeEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PriceListIndexGrid']/div[2]/table/tbody/tr[1]/td[4]/a[2]")]
        [CacheLookup]
        public IWebElement PriceListTypeDelete { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement PriceListTypeName { get; set; }

        [FindsBy(How = How.Id, Using = "Name_validationMessage")]
        [CacheLookup]
        public IWebElement NameErrorMsg { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement DeleteApprove { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-cancel")]
        [CacheLookup]
        public IWebElement DeleteCancel { get; set; }

        public string priceListTable = "//*[@id='PriceListIndexGrid']/div[2]/table/tbody";

        public void EnterPriceLisTypeScreen()
        {
            Pages.Home_Page.EntePriceListTab();
            PriceListTypeScreen.ClickWait();
            softAssert.VerifyElementIsPresent(PriceListTypeCreate);
            Constant.tmpTableCount = utilityFunction.TableCount(priceListTable);
        }

        public void PriceListTypeCreateApplication()
        {
            Pages.PriceListType_Page.EnterPriceLisTypeScreen();
            PriceListTypeCreate.ClickOn();
            PriceListTypeApprove.ClickOn();
            softAssert.VerifyElementIsPresent(NameErrorMsg);
            PriceListTypeName.EnterText(Constant.priceListName);
            PriceListTypeApprove.ClickOn();
            Assert.AreEqual(utilityFunction.TableCount(priceListTable), Constant.tmpTableCount + 1);
        }

        public void PriceListTypeDeleteApplication()
        {
            PriceListTypeDelete.ClickOn();
            DeleteApprove.ClickOn();
            Thread.Sleep(500);
            Assert.AreEqual(utilityFunction.TableCount(priceListTable), Constant.tmpTableCount);

        }

        public void PriceListTypeEditApplication()
        {
            PriceListTypeEdit.ClickOn();
            PriceListTypeName.EnterClearText("Edit" + RandomNumber.smallNumber());
            PriceListTypeApprove.ClickOn();
            softAssert.VerifyElementIsPresent(Pages.Home_Page.SuccessPopup);
        }
    }
}
