
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;

namespace HyWorksAutomationSuite
{
    public class ExtendReports
    {
        public ExtentReports extent;
        public ExtentTest test;
        [SetUp]
        public void StartReportHandler()
        {
            string reportPath = @"C:\\Users\\NAND.TANDULJE\\Documents\\Nand\\Auto\\HyWorksAutomationSuite\\HyWorksAutomationSuite\\Reports\\TestReport.html";
            extent = new ExtentReports(reportPath, true);
            extent.AddSystemInfo("Host Name", "Your Host Name")
                  .AddSystemInfo("Environment", "YourQAEnvironment")
                  .AddSystemInfo("Username", "Your User Name");
            string xmlPath = @"C:\\Users\\NAND.TANDULJE\\Documents\\Nand\Auto\\HyWorksAutomationSuite\\HyWorksAutomationSuite\\XMAValue.xml";
            extent.LoadConfig(xmlPath);
            //return extent;
        }

        [Test]
        public void StartTestLogs(string str)
        {
            test = extent.StartTest(str, "test case started...!!!");

            //test.Log(LogStatus.Pass, "Successfully Login into agency Portal");
            //test.Log(LogStatus.Info, "Click on UI button link");
            //test.Log(LogStatus.Fail, "Error Occurred while creating document");
            //test.Log(LogStatus.Pass, "Task Released Succssfully");
            //test.Log(LogStatus.Warning, "Workflow saved with warning");
            //test.Log(LogStatus.Error, "Error occurred while releasing task.");
            //test.Log(LogStatus.Unknown, "Dont know what is happning.");
            //test.Log(LogStatus.Fatal, "Unhandled exception occured.");
            //extent.EndTest(test);
            //extent.Flush();
            //extent.Close();
        }

        [Test]
        public void InfoLog(string str)
        {
            test.Log(LogStatus.Info, str);
        }

        [Test]
        public void WarnLog(string str)
        {
            test.Log(LogStatus.Warning, str);
        }

        [Test]
        public void PassLog(string str)
        {
            test.Log(LogStatus.Pass, str);
        }

        [Test]
        public void FailLog(string str)
        {
            test.Log(LogStatus.Fail, str);
        }

        [Test]
        public void ErrorLog(string str)
        {
            test.Log(LogStatus.Error, str);
        }

        [Test]
        public void FatalLog(string str)
        {
            test.Log(LogStatus.Fatal, str);
        }

        [Test]
        public void SkipLog(string str)
        {
            test.Log(LogStatus.Skip, str);
        }

        [Test]
        public void UnknownLog(string str)
        {
            test.Log(LogStatus.Unknown, str);
        }

        [Test]
        public void EndTestLog()
        {
            test.Log(LogStatus.Info, "End hare test case...!!!");
            extent.EndTest(test);
            extent.Flush();
            extent.Close();
        }

        [Test]
        public void FlushCloseLog(string str)
        {
            test.Log(LogStatus.Info, "Flush and close log here...!!!");
            extent.Flush();
            extent.Close();
        }

        public string ScreenShotTest(IWebDriver driver, string imgName)
        {
            string ScreenShotFolderName = @"C:\\Users\\NAND.TANDULJE\\Documents\\Nand\\Auto\\HyWorksAutomationSuite\\HyWorksAutomationSuite\\Reports\\ScreenShot";
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string localpath = ScreenShotFolderName + imgName + ".png";
            file.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            PrintImg(localpath);
            return localpath;

        }

        public void PrintImg(string path)
        {
            test.Log(LogStatus.Info, "Thsi is screen attached " + test.AddBase64ScreenCapture(path));
        }
    }
}
