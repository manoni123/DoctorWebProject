using DoctorWeb.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb
{
    public class AssertionExtent
    {
        private StringBuilder verificationErrors;
        private int _time = 300;

        public AssertionExtent()
        {
            verificationErrors = new StringBuilder();
        }

        public void VerifySuccessMsg() {
            try {
                Assert.IsTrue(Pages.Home_Page.SuccessPopup.Enabled);
            } catch (AssertionException e) {
                Debug.WriteLine(e);
                Assert.Fail();
            }
        }

        public void VerifyErrorMsg()
        {
            try
            {
                Assert.IsTrue(Pages.Home_Page.ErrorPopup.Displayed);
            }
            catch (AssertionException e)
            {
                Debug.WriteLine(e);
            }
        }

        public void VerifyElementIsPresent(IWebElement element)
        {
            try
            {
                Assert.IsTrue(element.Displayed, Constant.stackTraceTrue);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                Debug.WriteLine(e);
            }
        }

        public void VerifyElementNotPresent(IWebElement element)
        {
            try
            {
                Assert.IsFalse(element.Displayed, Constant.stackTraceFalse);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                Debug.WriteLine(e);
            }
        }

        public void VerifyElementNotPresentInsideWindow(IWebElement element, IWebElement _window)
        {
            try
            {
                Assert.IsFalse(element.Displayed);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                CloseWindowssIfDisplayed(_window);
                Debug.WriteLine(e);
            }
        }

        public void VerifyElementPresentInsideWindow(IWebElement element, IWebElement _window)
        {
            try
            {
                Assert.IsTrue(element.Displayed);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                CloseWindowssIfDisplayed(_window);
                Debug.WriteLine(e + Constant.stackTraceTrue);
            }
        }

        public void VerifyElementInPopupOverWindow(IWebElement element, IWebElement _popup, IWebElement _window)
        {
            try
            {
                Assert.IsTrue(element.Displayed);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                CloseWindowsForPopupInWindow(_popup, _window);
                Debug.WriteLine(e + Constant.stackTraceTrue);
            }
        }

        public void VerifyElementHasEqual(String element, String str) {
            try
            {
                Assert.AreEqual(element, str);
                Thread.Sleep(_time);
            }
            catch (AssertionException e) {
                Debug.WriteLine(e);
            }
        }

        public void VerifyElemenNotHaveEqual(IWebElement element, String str)
        {
            try
            {
                Assert.AreNotEqual(element, str);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                Debug.WriteLine(e);

            }
        }

        public void VerifyElemenNotHaveEqualInteger(IWebElement element, int number)
        {
            try
            {
                Assert.AreNotEqual(element, number);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                Debug.WriteLine(e);

            }
        }

        public void VerifyElementHasEqualInsideWindow(IWebElement element, String str, IWebElement _window)
        {
            try
            {
                Assert.AreEqual(element, str);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                CloseWindowssIfDisplayed(_window);
                Debug.WriteLine(e);
            }
        }

        public void VerifyElementIsNotNull(string element, IWebElement _window)
        {
            try
            {
                Assert.IsNotNull(element, Constant.stackTraceNotNull);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                CloseWindowssIfDisplayed(_window);
                Debug.WriteLine(e);
            }
        }

        public void VerifyElementIsNull(string element, IWebElement _window){
            try
            {
                Assert.IsNull(element, Constant.stackTraceNull);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                CloseWindowssIfDisplayed(_window);
                Debug.WriteLine(e);
            }
        }

        //verify at what table the Browser.webDriver is currently in
        public void CloseWindowssIfDisplayed(IWebElement element)
        {
            if (element.Displayed) {
                element.Click();
            }
        }

        public void CloseWindowsForPopupInWindow(IWebElement popup, IWebElement window)
        {
            if (popup.Displayed)
            {
                window.ClickOn();
                popup.ClickOn();
            }
        }
    }
}