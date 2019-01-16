using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.Utility
{
    public class UtilityFunction
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();

        public int ListCount(string element) {
            int count = Browser.Driver.FindElements(By.XPath(element + "/tr")).Count;
            return count;
        }

        public string ElementText(string element) {
            string text = Browser.Driver.FindElement(By.XPath(element)).Text;
            return text;
        }
    }
}
