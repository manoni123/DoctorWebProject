﻿using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class TreatmentPlan_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        [FindsBy(How = How.Id, Using = "btnTreatmentPlanTemplateCreateNew")]
        [CacheLookup]
        public IWebElement CreateTreatmentPlan { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridTreatmentPlanTemplates']/div[2]/table/tbody/tr/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement EditTreatmentPlan { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gridTreatmentPlanTemplates']/div[2]/table/tbody/tr/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement DeleteTreatmentPlan { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement TreatmentPlanName { get; set; }
        
        [FindsBy(How = How.Id, Using = "btnTreatmentPlanTemplateEditSave")]
        [CacheLookup]
        public IWebElement TreatmentPlanSave { get; set; }

        [FindsBy(How = How.Id, Using = "btnTreatmentPlanTemplateEditCancel")]
        [CacheLookup]
        public IWebElement TreatmentPlanCancel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Code_AutoComplete_PriceListCode']")]
        [CacheLookup]
        public IWebElement CodeSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='generalTabstrip']/ul/li[7]/span")]
        [CacheLookup]
        public IWebElement TreatmentPlanPage { get; set; }

        public void EnterTreatmentPlanPage()
        {
            Pages.Home_Page.SettingScreen.ClickWait();
            Pages.Home_Page.DevGeneralScreen.ClickWait();
            TreatmentPlanPage.ClickWait();
        }

        public void CreateNewTreatmentPlanApplication() {
            Pages.PriceList_Page.PriceListFirstCodeName();;
            Pages.Home_Page.SettingScreen.ClickWait();
            Pages.Home_Page.DevGeneralScreen.ClickWait();
            TreatmentPlanPage.ClickWait();
            var countBefore = utility.TableCount("//*[@id='gridTreatmentPlanTemplates']/div[2]/table/tbody");
            CreateTreatmentPlan.ClickWait();
            TreatmentPlanName.EnterClearText(Constant.treatmentPlan);
            utility.SelectCodeOnCodeBroswer("//*[@id='gridCodeBrowser']/div[2]/table/tbody/tr[1]/td[5]/div/input");
            TreatmentPlanSave.ClickOn();
            var countAfter = utility.TableCount("//*[@id='gridTreatmentPlanTemplates']/div[2]/table/tbody");
            softAssert.VerifyElemenNotHaveEqual(countBefore, countAfter);
        }
    }
}
