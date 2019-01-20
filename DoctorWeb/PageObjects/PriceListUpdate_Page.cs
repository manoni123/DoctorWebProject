using DoctorWeb.Utility;
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

        [FindsBy(How = How.CssSelector, Using = "#priceListTabStrip > ul > li.k-item.k-state-default.k-last.k-state-hover > span.k-link")]
        [CacheLookup]
        public IWebElement PriceListUpdateScreen { get; set; }

        [FindsBy(How = How.CssSelector, Using = "//*[@id='UpdatePricesForm']/div/div[3]/label[1]")]
        [CacheLookup]
        public IWebElement ChangePriceByNumber { get; set; }

        [FindsBy(How = How.CssSelector, Using = "//*[@id='UpdatePricesForm']/div/div[3]/label[2]")]
        [CacheLookup]
        public IWebElement ChangePriceByTax { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ChangePricesPercent")]
        [CacheLookup]
        public IWebElement PercentValue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "//*[@id='updateDueChangePrices']/label")]
        [CacheLookup]
        public IWebElement UpdateByBasicPriceType { get; set; }

        public void EnterPriceLisUpdateScreen()
        {
            Pages.Home_Page.EntePriceListTab();
            PriceListUpdateScreen.ClickWait("UpdateScreen");
            softAssert.VerifyElementIsPresent(ChangePriceByTax);
        }
    }
}
