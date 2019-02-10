using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.Utility
{
    public class UtilityFunction
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();

        public int TableCount(string element) {
            int count = Browser.Driver.FindElements(By.XPath(element + "/tr")).Count;
            return count;
        }

        public int ListCount(string element)
        {
            int count = Browser.Driver.FindElements(By.XPath(element + "/li")).Count;
            return count;
        }

        public void NameInElement(IWebElement element, string valueOne, string valueTwo, string valueThree){
            if (valueOne != null)
            {
                Log.Info("Click On : " + element.GetAttribute("name"));
            }
            else if (valueTwo != null)
            {
                Log.Info("Click On : " + element.GetAttribute("id"));
            }
            else if (valueThree != null)
            {
                Log.Info("Click On : " + valueThree);
            }
            else 
            {
                Log.Info("Click On : Icon (element has no name)");
            }
        }

        public string ElementText(string element) {
            string text = Browser.Driver.FindElement(By.XPath(element)).Text;
            return text;
        }

        public static class MemberInfoGetting
        {
            public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                return expressionBody.Member.Name;
            }
        }

        public decimal PricelistTaxCal(decimal price, decimal tax)
        {
            decimal ResultAfterPercentage = (tax / 100) * price + price;
            return ResultAfterPercentage;
        }

        public void TestWrap(Action method, IWebElement CloseWindow = null)
        {
            try {
                method();
            } catch (Exception) {
                CloseWindow.ClickOn();
                softAssert.WarningMsg();
            }
        }

        public void ServerErrorCheck()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            Browser.chromebDriver = new ChromeDriver(options);

            IList logs;
            logs = Browser.chromebDriver.Manage().Logs.GetLog(LogType.Browser);
            try
            {
                Assert.True(logs.Count == 0);
            }
            catch (AssertionException e)
            {
                Console.WriteLine("Assert Failed: " + e.Message);
                foreach (LogEntry log in logs)
                {
                    Console.WriteLine(log.Message);
                }
            }
        }
    }
}
