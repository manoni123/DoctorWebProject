using DoctorWeb.Utility;
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
    public class BlockOpen_Page
    {
         
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();

        [FindsBy(How = How.Id, Using = "btnCreateSlot")]
        [CacheLookup]
        public IWebElement CreateNewSlot { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='createSlotMenu_mn_active']")]
        [CacheLookup]
        public IWebElement CreateNewOpen { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='createSlotMenu']/li[2]")]
        [CacheLookup]
        public IWebElement CreateNewBlock { get; set; }

        [FindsBy(How = How.ClassName, Using = "popup-close-button")]
        [CacheLookup]
        public IWebElement CloseWindow { get; set; }

        [FindsBy(How = How.Id, Using = "btnSlotItemEditSave")]
        [CacheLookup]
        public IWebElement SaveAndClose { get; set; }

        [FindsBy(How = How.Id, Using = "btnSlotItemEditCancel")]
        [CacheLookup]
        public IWebElement CancelOpenBlock { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=slotItemAddForm']/div/div[2]/div[1]/div/div[1]/div/span[1]/span/input")]
        [CacheLookup]
        public IWebElement SelectScheduler { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='slotItemAddForm']/div/div[2]/div[1]/div/div[2]/div/span[1]/span")]
        [CacheLookup]
        public IWebElement SelectFirstBranch { get; set; }

        [FindsBy(How = How.Id, Using = "End")]
        [CacheLookup]
        public IWebElement EndDate { get; set; }

        [FindsBy(How = How.Id, Using = "Start")]
        [CacheLookup]
        public IWebElement StartDate { get; set; }

        public void BlockCreateEmptyApplication() {
            Pages.Scheduler_Page.EnterOpenBlockWindow();
            CreateNewSlot.ClickOn();
            CreateNewBlock.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(SaveAndClose, CancelOpenBlock);
            SaveAndClose.Click();
            softAssert.VerifyErrorMsg();
            CancelOpenBlock.ClickOn();
            CloseWindow.ClickOn();
        }
    }
}
