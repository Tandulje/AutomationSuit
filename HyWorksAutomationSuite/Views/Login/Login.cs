using HyWorksAutomationSuite.Views.CommonToTheme;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyWorksAutomationSuite.Views.Login
{
     public  class Login
    {
        public void LoginTest()
        {
            ExtendReports ExtRep = new ExtendReports();

            IWebDriver driverFF;

            var op = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            driverFF = new FirefoxDriver(op);
            try
            {
                ExtRep.StartReportHandler();
                ExtRep.StartTestLogs("Hyworks Login");

                ExtRep.InfoLog("Start login test case");
                ExtRep.InfoLog("Go to login page.");
               
                driverFF.Navigate().GoToUrl("https://172.27.1.81/Admin/en-US/Account/SignIn");
                var imgPath = ExtRep.ScreenShotTest(driverFF, "Login");
                Thread.Sleep(3000);
                ExtRep.PassLog("Login page open successfuly...!!!");
                driverFF.FindElement(By.Id("usernameInputBox")).SendKeys("hyworksadmin");
                ExtRep.InfoLog("Entered user name");
                driverFF.FindElement(By.Id("passwordInputBox")).SendKeys("123");
                ExtRep.InfoLog("Entered password");

                var Dropselector = driverFF.FindElement(By.Name("PortalOrganization"));

                var selectElement = new SelectElement(Dropselector);
                // select by text
                selectElement.SelectByText("Default");
                ExtRep.InfoLog("Organization selection done");

                driverFF.FindElement(By.Id("loginButton")).Click();
                ExtRep.InfoLog("Clicked login button");
                ExtRep.PassLog("Logedin successfully");

                driverFF.Navigate().GoToUrl("https://172.27.1.81/Admin/en-US/Dashboard/DashboardHome");
                ExtRep.ScreenShotTest(driverFF, "After Login");
                Thread.Sleep(3000);
                ExtRep.InfoLog("Login test case over");

                ExtRep.EndTestLog();
                Thread.Sleep(3000);
                driverFF.Quit();
            }
            catch (Exception ex)
            {
                ExtRep.FailLog("Fail due to ..." + ex.Message);
            }

            driverFF.Quit();


        }
    }
}
