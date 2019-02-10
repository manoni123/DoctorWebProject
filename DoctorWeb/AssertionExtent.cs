using DoctorWeb.Utility;
using log4net;
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
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                Assert.Fail();
            }
        }

        public void WarningOnErrorMsg()
        {
             Warn.If(Pages.Home_Page.ErrorPopup.Displayed);
        }

        public void VerifyElementIsPresent(IWebElement element)
        {
            try
            {
                Assert.IsTrue(element.Displayed, Constant.stackTraceFalse);
                Log.Info("Element : " + element.Text + " IS Present");
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                Log.Error("Element : " + element.Text + " IS NOT Present");
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
                Log.Info("Verify " + element.GetAttribute("name") + " is present");
                
            }
            catch (AssertionException e)
            {
                CloseWindowssIfDisplayed(_window);
                Debug.WriteLine(e + Constant.stackTraceTrue);
                Log.Error("Verify " + element.GetAttribute("name") + " is NOT present");
            }
        }

        public void VerifyElementInPopupOverWindow(IWebElement element, IWebElement _popup, IWebElement _window)
        {
            try
            {
                Assert.IsTrue(element.Displayed);
                Log.Info("Verify " + element.Text + " IS present inside window");
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                CloseWindowsForPopupInWindow(_popup, _window);
                Log.Info("Verify " + element.Text + " IS NOT present inside window");
                Debug.WriteLine(e + Constant.stackTraceTrue);
            }
        }

        public void VerifyElementHasEqual(String element, String str) {
            try
            {
                Assert.AreEqual(element, str);
                Log.Info("Verify " + element + " Has Equal");
                Thread.Sleep(_time);
            }
            catch (AssertionException e) {
                Log.Info("Verify " + element + " DOES NOT Has Equal");
                Debug.WriteLine(e);
            }
        }

        public void VerifyElemenNotHaveEqual(IWebElement element, String str)
        {
            try
            {
                Log.Info("Verify " + element + " Has No Equal");
                Assert.AreNotEqual(element, str);
                Thread.Sleep(_time);
            }
            catch (AssertionException e)
            {
                Log.Info("Verify " + element + " Has Equal - Fail");
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

        public void WarningMsg() {
            Assert.Warn("TEST FAILED DUE TO WRONG CODE");
        }



        //verify at what table the Browser.webDriver is currently in
        public void CloseWindowssIfDisplayed(IWebElement element)
        {
            if (element.Displayed) {
                element.ClickOn();
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