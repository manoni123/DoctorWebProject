using DoctorWeb.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb
{
    public static class Browser
    {
        private static readonly string BaseUrl = Constant.drWebUrl;
        private static readonly string TestUrl = Constant.drWebTestUrl;
        public static IWebDriver chromebDriver = new ChromeDriver();

        // public static IWebDriver firefoxDriver = new FirefoxDriver();
        public static void Initialize()
        {
            Goto("");
            chromebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromebDriver.Manage().Window.Maximize();
        }

        public static string Title
        {
            get { return chromebDriver.Title; }
        }

        public static ISearchContext Driver
        {
            get { return chromebDriver; }
        }

        public static void Goto(string url)
        {
            int selectEnviornment = 2;
            
            switch (selectEnviornment) {
                case 1:
                     chromebDriver.Url = BaseUrl + url;
                break;

                case 2:
                    chromebDriver.Url = TestUrl + url;
                break;
            }
        }

        public static void Close()
        {
            chromebDriver.Close();
        }
    }
}
