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
    public class StandbyList_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();

        [FindsBy(How = How.ClassName, Using = "popup-close-button")]
        [CacheLookup]
        public IWebElement CloseWindow { get; set; }

        [FindsBy(How = How.Id, Using = "btnCreateStandBy")]
        [CacheLookup]
        public IWebElement CreateStandby { get; set; }
    }
}
