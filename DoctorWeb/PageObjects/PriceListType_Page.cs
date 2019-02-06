using DoctorWeb.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void EnterPriceLisTypeScreen()
        {
            Pages.Home_Page.EntePriceListTab();
            PriceListTypeScreen.ClickWait();
            softAssert.VerifyElementIsPresent(PriceListTypeCreate);
        }

        public void PriceListTypeCreateApplication()
        {
            int priceListCount = utilityFunction.TableCount("//*[@id='PriceListIndexGrid']/div[2]/table/tbody");
            PriceListTypeCreate.ClickOn();
            PriceListTypeApprove.ClickOn();
            softAssert.VerifyElementIsPresent(NameErrorMsg);
            PriceListTypeName.EnterText(Constant.priceListName);
            PriceListTypeApprove.ClickOn();
            int priceListCountAfter = utilityFunction.TableCount("//*[@id='PriceListIndexGrid']/div[2]/table/tbody");
            Thread.Sleep(500);
            Assert.AreNotEqual(priceListCount, priceListCountAfter);
        }

        public void PriceListTypeDeleteApplication()
        {
            int priceListCount = utilityFunction.TableCount("//*[@id='PriceListIndexGrid']/div[2]/table/tbody");
            PriceListTypeDelete.ClickOn();
            DeleteApprove.ClickOn();
            int priceListCountAfter = utilityFunction.TableCount("//*[@id='PriceListIndexGrid']/div[2]/table/tbody");
            Assert.AreNotEqual(priceListCount, priceListCountAfter);

        }

        public void PriceListTypeEditApplication()
        {
            PriceListTypeEdit.ClickOn();
            PriceListTypeName.EnterClearText("Edit");
            PriceListTypeApprove.ClickOn();
            softAssert.VerifyElementIsPresent(Pages.Home_Page.SuccessPopup);
        }
    }
}
