using AventStack.ExtentReports.Tests.Parallel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb
{
    [Ignore("skip Test")]
    [TestFixture, Category("Users")]
    public class UsersTest : BaseFixture
    {   
        [SetUp]
        public void ReturnSchedularScreen()
        {
          //  Pages.Login_Page.LoginApplication();
        }

        [TearDown]
        public void LogoutAfterEachTest()
        {
            Pages.Home_Page.LogoutApplication();
        }
    }
}

