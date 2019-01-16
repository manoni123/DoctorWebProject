using DoctorWeb.Utility;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorWeb.PageObjects
{
    public class UserProfile_Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.Id, Using = "FirstName")]
        [CacheLookup]
        public IWebElement UserFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        [CacheLookup]
        public IWebElement UserLastName { get; set; }

        [FindsBy(How = How.Id, Using = "Identity")]
        [CacheLookup]
        public IWebElement UserIdentity { get; set; }

        [FindsBy(How = How.Id, Using = "PhoneMobile")]
        [CacheLookup]
        public IWebElement UserModile { get; set; }

        [FindsBy(How = How.Id, Using = "btnEditUser")]
        [CacheLookup]
        public IWebElement EditUserButton { get; set; }

        public void EdiProfileApplication()
        {
            Thread.Sleep(500);
            try
            {
                log.Info("Clicked on User Profile list");
            }
            catch (Exception e)
            {
                log.Error("Unable to click user profile list " + Environment.NewLine + e);
            }
            log.Info("opened profile list");

            //check if profile button pressed
            try
            {
                Pages.Home_Page.ProfileButton.Click();
                Thread.Sleep(500);
                log.Info("opened profile window");
            }
            catch (Exception e)
            {
                log.Error("Could not open profile window" + Environment.NewLine + e);
            }

            //fill the user details
            UserFirstName.Clear();
            UserFirstName.SendKeys(Constant.UserNameEdit);
            log.Info("Cleared and changed user name");
            UserLastName.Clear();
            UserLastName.SendKeys(Constant.UserLastnameEdit);
            log.Info("Cleared and changed user last name");
            Thread.Sleep(500);
            EditUserButton.Click();
            log.Info("pressed on Edit user button");
        }
    }
}
