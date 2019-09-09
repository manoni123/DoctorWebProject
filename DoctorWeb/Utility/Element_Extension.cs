using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
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

        public static IWebElement FindElementOnPage(this IWebDriver webDriver, By by)
        {
            RemoteWebElement element = (RemoteWebElement)webDriver.FindElement(by);
            var hack = element.LocationOnScreenOnceScrolledIntoView;
            return element;
        }

        //enter Text method with log
        public static void WaitElementClickble(By by, IWebElement element, int time)
        {
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
            log.Info(text + " is entered in the " + element.GetAttribute("name"));
        }

        //Time in Miliseconds for user actionss
        public static void ClickOn(this IWebElement element) {
            try
            {
                string valueName = element.Text;
                string valueID = element.GetAttribute("name");
                string valueTag = element.GetAttribute("id");
                string valueText = element.GetAttribute("data-tag");
                utility.NameInElement(element, valueName, valueID, valueTag, valueText);
                element.Click();
                Task.Delay(_time).Wait();
         //       Thread.Sleep(_time);
            }
            catch (Exception) {
                log.Error("Could not Click Element");
            }
        }

        //self determine the wait time
        public static void ClickWait(this IWebElement element)
        {
            try
            {
                string valueName = element.GetAttribute("name");
                string valueID = element.GetAttribute("id");
                string valueTag = element.GetAttribute("data-tag");
                string valueText = element.Text;
                utility.NameInElement(element, valueName, valueID, valueTag, valueText);
                element.Click();
                Task.Delay(1500).Wait();
 //               Thread.Sleep(1500);
            }
            catch (Exception)
            {
                log.Error("Could not Click Element");
            }
        }

        //isDisplayd Method with log
        public static bool IsDisplayed(this IWebElement element, string ElementName) {
            bool result;
            try {
                result = element.Displayed;
                log.Info(ElementName + " is Displayed successfuly");
            } catch (NoSuchElementException) {
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

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeInMiliseconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(drv => drv.FindElement(by));
            }
            finally {
                Thread.Sleep(timeInMiliseconds);
            }
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

        //test elementWait
        public static void FindElementNotPresent(this ISearchContext driver, By locator) {
            driver.TimerLoop(() => driver.FindElement(locator).Displayed, true, "Timeout: Elemenot didnt go away at: " + locator);
        }

        public static void FindElementToApepar(this ISearchContext driver, By locator) {
            driver.TimerLoop(() => driver.FindElement(locator).Displayed, false, "Element Not Visible at: " +locator);
        }

        public static void TimerLoop(this ISearchContext driver, Func<bool> isComplete, bool exceptionCompleteResult, string timeoutMsg)
        {

            const int timeoutinteger = 10;

            for (int second = 0; ; second++)
            {
                try
                {
                    if (isComplete())
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg);
                }
                catch (Exception ex)
                {
                    if (exceptionCompleteResult)
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg, ex);
                }
                Thread.Sleep(100);
            }
        }
    }
}


