using DoctorWeb.Utility;
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
    public class PriceListUpdate_Page
    {
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.CssSelector, Using = "#priceListTabStrip > ul > li.k-item.k-state-default.k-last > span.k-link")]
        [CacheLookup]
        public IWebElement PriceListUpdateScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "//*[@id='UpdatePricesForm']/div/div[3]/label[1]")]
        [CacheLookup]
        public IWebElement ChangePriceByNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='UpdatePricesForm']/div/div[2]/label")]
        [CacheLookup]
        public IWebElement BasicPricelistCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='updateDueChangePrices']/span[2]/span/input[1]")]
        [CacheLookup]
        public IWebElement PercentageBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "//*[@id='UpdatePricesForm']/div/div[3]/label[2]")]
        [CacheLookup]
        public IWebElement ChangePriceByTax { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ChangePricesPercent")]
        [CacheLookup]
        public IWebElement PercentValue { get; set; }

        [FindsBy(How = How.Id, Using = "UpdatePricesButtonID")]
        [CacheLookup]
        public IWebElement UpdateByBasicPriceType { get; set; }

        public void EnterPriceLisUpdateScreen()
        {
            Pages.Home_Page.EntePriceListTab();
            PriceListUpdateScreen.ClickWait();
            softAssert.VerifyElementIsPresent(ChangePriceByTax);
        }

        public void UpdateBasePriceListApplication() {
       //     Pages.PriceList_Page.DevCreatePriceListDevApplication();
            string PriceToUpdate = utility.ElementText("//*[@id='gridPriceListPrices']/div[2]/div[1]/table/tbody/tr/td[5]");
            string percentageToUpdate = "25";

            PriceListUpdateScreen.ClickWait();
            BasicPricelistCheck.ClickOn();
            PercentageBox.SendKeys(percentageToUpdate);
            UpdateByBasicPriceType.ClickOn();

            var endResult = utility.PricelistTaxCal(decimal.Parse(PriceToUpdate), decimal.Parse(percentageToUpdate));

            Pages.PriceList_Page.PriceListWindow.ClickOn();
            Assert.AreNotEqual(PriceToUpdate, endResult);

        }
    }
}
