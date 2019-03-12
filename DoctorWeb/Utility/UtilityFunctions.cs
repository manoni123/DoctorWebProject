using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Linq.Expressions;
using System.Threading;

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

        public int TableDataCount(string element)
        {
            int count = Browser.Driver.FindElements(By.XPath(element + "/tr/td")).Count;
            return count;
        }

        public int ListCount(string element)
        {
            int count = Browser.Driver.FindElements(By.XPath(element + "/li")).Count;
            return count;
        }

        public void ClickElementName() {
            Log.Info("Click On: ");
        }

        public void NameInElement(IWebElement element, string valueOne = null, string valueTwo = null, string valueThree = null, string valueFour = null) {
            if (!String.IsNullOrEmpty(valueOne))
            {
                Log.Info("Click On : " + valueOne);
            }
            else if (!String.IsNullOrEmpty(valueTwo))
            {
                Log.Info("Click On : " + valueTwo);
            }
            else if (!String.IsNullOrEmpty(valueThree))
            {
                Log.Info("Click On : " + valueThree);
            }
            else if (!String.IsNullOrEmpty(valueFour))
            {
                Log.Info("Click On : " + valueFour);
            }
            else
            {
                Log.Info("Click On : Icon (Element w/ no name)");
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

        public void TextClearDropdownAndEnter(IWebElement element, string text)
        {
            Thread.Sleep(500);
            element.EnterClearText(text);
            Thread.Sleep(500);
            element.SendKeys(Keys.Down);
            Thread.Sleep(500);
            element.SendKeys(Keys.Enter);
        }

        public void TextDropdownAndEnter(IWebElement element, string text)
        {
            element.SendKeys(text);
            Thread.Sleep(500);
            element.SendKeys(Keys.Down);
            Thread.Sleep(500);
            element.SendKeys(Keys.Enter);
        }

        public void ClickDropdownAndEnter(IWebElement element)
        {
            element.ClickOn();
            Thread.Sleep(500);
            element.SendKeys(Keys.Down);
            Thread.Sleep(500);
            element.SendKeys(Keys.Enter);
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

        public void SelectCodeOnCodeBroswer(string element) {
            Browser.Driver.FindElement(By.ClassName("btn_codeBrowser")).ClickOn();
            Browser.Driver.FindElement(By.XPath(element)).ClickOn();
        }

        public bool IsElementVisible(IWebDriver driver, By element)
        {
            return driver.FindElements(element).Count > 0
                && driver.FindElement(element).Displayed;
        }
    }
}
