using DoctorWeb.Utility;
using log4net;
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
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string BaseUrl = Constant.drWebUrl;
        private static readonly string TestUrl = Constant.drWebTestUrl;
        public static IWebDriver chromebDriver = new ChromeDriver();

        // public static IWebDriver firefoxDriver = new FirefoxDriver();
        public static void Initialize()
        {
            Log.Info("Driver Used is:" + Driver.ToString());
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
            get {return chromebDriver;}
            
        }

        public static void Goto(string url)
        {
            int selectEnviornment = 2;
            
            switch (selectEnviornment) {
                case 1:
                     chromebDriver.Url = BaseUrl + url;
                     Log.Info("URL Used for Testing is: " + BaseUrl + Environment.NewLine);
                break;

                case 2:
                    chromebDriver.Url = TestUrl + url;
                    Log.Info("URL Used for Testing is: " + TestUrl + Environment.NewLine);
                    break;
            }
        }

        public static void Close()
        {
            chromebDriver.Close();
        }
    }
}
