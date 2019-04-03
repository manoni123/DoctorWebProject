using DoctorWeb.Utility;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;


namespace DoctorWeb
{
    public class Scheduler
    {
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();

        public void ClickAvailbleCell() {
            var schedulerRows = utility.TableCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            var schedulerCells = utility.TableDataCount("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody");
            int numOfCellInRow = schedulerCells / schedulerRows;
            for (int td = 1; td < schedulerCells; td++)
            {
                IWebElement singleCell = Browser.Driver.FindElement(By.XPath("//*[@id='scheduler']/table/tbody/tr[2]/td[2]/div/table/tbody/tr[" + td + "]/td[" + td + "]"));
                (new Actions(Browser.chromebDriver)).DoubleClick(singleCell).Perform();
                if (utility.IsElementVisible(Browser.chromebDriver, By.Id("ic_problem")))
                {
                    Pages.Meeting_Page.CreateMeetingKnownPatient();
                    break;
                }
                else if (Browser.Driver.FindElement(By.XPath("//*[@id='btnCreateAppointmentSave']")).GetAttribute("aria-disabled").Equals("true"))
                {
                    //nothing
                }
            }
        }
    }
}
