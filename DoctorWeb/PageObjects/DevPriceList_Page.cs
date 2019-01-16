using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class DevPriceList_Page
    {
        AssertionExtent softAssert = new AssertionExtent();

        [FindsBy(How = How.CssSelector, Using = "#priceListTabStrip > ul > li.k-item.k-state-default.k-first.k-tab-on-top.k-state-active > span.k-link")]
        [CacheLookup]
        public IWebElement SidePannelBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddPriceListCode")]
        [CacheLookup]
        public IWebElement PriceListCodeCreate { get; set; }

        [FindsBy(How = How.Id, Using = "btnExportPriceList")]
        [CacheLookup]
        public IWebElement PriceListPrint { get; set; }

        [FindsBy(How = How.Id, Using = "//*[@id='gridAppointmentTypes']/div[2]/div[1]/table")]
        [CacheLookup]
        public IWebElement PriceListTable { get; set; }
    }
}
