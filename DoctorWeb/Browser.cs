using DoctorWeb.Utility;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DoctorWeb
{
    public static class Browser
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string BaseUrl = Constant.drWebUrl;
        private static readonly string TestUrl = Constant.drWebTestUrl;
        private static readonly string MobileUrl = Constant.drwebMobileUrl;
        private static readonly string newClient = Constant.newClientUrl;


        public static IWebDriver chromebDriver = new ChromeDriver();

        // public static IWebDriver firefoxDriver = new FirefoxDriver();
        public static void Initialize()
        {
            Log.Info("Driver Used is:" + Driver.ToString());
            Log.Info("Bug Images are Located in:" + Constant.bugImageCaptured.ToString());
            Log.Info("Log are located in: " + Constant.logDirectory.ToString());
            Log.Info("html reports are located in: " + Constant.reportDirectory.ToString());
            Log.Info("Versions are: //1 = prod // 2 = stage // 3 = mobile // 4 = hotfix");
            Log.Info("Test enviornment is:" + Constant.VersionNumber);
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
            int selectEnviornment = Constant.VersionNumber;
            string usedURL = "URL Used for Testing is: ";
            switch (selectEnviornment) {
                case 1:
                     chromebDriver.Url = BaseUrl + url;
                     Log.Info(usedURL + BaseUrl + Environment.NewLine);
                break;

                case 2:
                    chromebDriver.Url = TestUrl + url;
                    Log.Info(usedURL + TestUrl + Environment.NewLine);
                break;

                case 3:
                    chromebDriver.Url = MobileUrl + url;
                    Log.Info(usedURL + MobileUrl + Environment.NewLine);
                break;

                case 4:
                    chromebDriver.Url = newClient + url;
                    Log.Info(usedURL + newClient + Environment.NewLine);
                 break;
            }
        }

        public static void Close()
        {
            chromebDriver.Close();
        }
    }
}
