﻿using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace SampleAPITestProject.Core
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string testResultPath = dir.Replace("bin\\Debug\\net8.0", "TestResults");

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            DateTime currentDateTime = DateTime.Now;
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.DocumentTitle = "Automation Test Report - " + currentDateTime;
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTeardown()
        {
            _extentReports.Flush();
        }
    }
}
