using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.Utility
{
    public static class Element_Extension
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static UtilityFunction utility = new UtilityFunction();
        private static int _time = 300;


        //enter Text method with log
        public static void WaitForElement(this IWebElement element, int time)
        {
            Browser.chromebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
            element.Click();
        }

        public static void EnterText(this IWebElement element, string text)
        {
            element.SendKeys(text);
            Thread.Sleep(_time);
          //  log.Info(text + " is entered in the " + elementName + " Field");
        }

        //enter Text method with log
        public static void IsAdmin(this IWebElement element, string text, bool isInUse)
        {
            element.SendKeys(text);
            Thread.Sleep(_time);
            //  log.Info(text + " is entered in the " + elementName + " Field");
        }

        //enter Text method with log
        public static void EnterClearText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            Thread.Sleep(_time);
            log.Info(text + " is entered in the " + element.Text);
        }

        //Time in Miliseconds for user actionss
        public static void ClickOn(this IWebElement element) {
            try {
                element.Click();
                string valueName = element.GetAttribute("name");
                string valueID = element.GetAttribute("id");
                string valueText = element.Text;
                utility.NameInElement(element, valueName, valueID, valueText);
                Thread.Sleep(_time);
            }
            catch (Exception e) {
                Debug.WriteLine(e);
            }
        }

        //self determine the wait time
        public static void ClickWait(this IWebElement element)
        {
            element.Click();
            string valueName = element.GetAttribute("name");
            string valueID = element.GetAttribute("id");
            string valueText = element.Text;
            utility.NameInElement(element, valueName, valueID, valueText);
            Thread.Sleep(1500);
        }

        //isDisplayd Method with log
        public static bool IsDisplayed(this IWebElement element, string ElementName) {
            bool result;
            try {
                result = element.Displayed;
                log.Info(ElementName + " is Displayed successfuly");
            } catch (Exception) {
                result = false;
                log.Error(ElementName + " is not displayed");
            }
            return result;
        }

        public static void SelectByValue(this IWebElement element, string text, string ElementName) {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(text);
            log.Info(text + " is the Value Selected On " + ElementName);
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }
    }
}


