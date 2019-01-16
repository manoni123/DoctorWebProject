using System;

using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

using NUnit.Framework;

namespace AventStack.ExtentReports.Tests.Parallel
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentManager()
        {
            DateTime date = DateTime.Now; // will give the date for today
            string dateWithFormat = date.ToString("dd"+"-"+"MM"+"-"+ "yyyy" + "-" + "HH" + "-" + "mm");

            var htmlReporter = new ExtentHtmlReporter(TestContext.CurrentContext.TestDirectory + "\\Reports\\Report Date"  + dateWithFormat + ".html");
            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().DocumentTitle = "Extent/NUnit Samples";
            htmlReporter.Configuration().ReportName = "Extent/NUnit Samples";
            htmlReporter.Configuration().Theme = Theme.Standard;

            Instance.AttachReporter(htmlReporter);
        }

        private ExtentManager()
        {
        }
    }
}