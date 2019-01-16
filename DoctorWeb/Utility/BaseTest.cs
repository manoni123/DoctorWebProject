using DoctorWeb.PageObjects;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb.Utility
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(@"C:\TEMP\Screenshot.jpg", ScreenshotImageFormat.Jpeg);

                log.Error("Automation Log: " + Environment.NewLine + ex + Environment.NewLine);

                // This would be a good place to log the exception message and
                // save together with the screenshot

                throw;
            }
        }
    }
}
