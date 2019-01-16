using DoctorWeb.PageObjects;
using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb.SettingTests
{
    public class PriceListTest
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(PriceListTest));

        public void LoggingTests()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [Test]
        public void priceListTest()
        {
            //instantiate the driver
            IWebDriver driver = new ChromeDriver();
            //call the website
            driver.Url = Constant.drWebUrl;

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //call Login page to begin login application
            Login_Page login_Page = new Login_Page(driver);
            login_Page.LoginApplication();
            log.Info("login Complete");

            //call the create category application
            PriceList_Page priceList_Page = new PriceList_Page(driver);
            priceList_Page.CreateCategoryApplication();
            log.Info("Create Category Complete");

            //call the cteate new price list code
            priceList_Page.CreatePriceListApplication();
            log.Info("create PriceList Code Complete");

            driver.Quit();
        }
    }
}
