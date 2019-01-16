using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DoctorWeb.PageObjects
{
    public class PatientDoc_Page
    {

        [FindsBy(How = How.XPath, Using = "//*[@id=\"mainTabStrip\"]/ul/li[2]")]
        [CacheLookup]
        public IWebElement NewPatiantTabClick { get; set; }

    }
}
