using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace HyWorksAutomationSuite.Views.SessionTeams
{
    public class SessionTeam
    {
        public void SessionTeamAdd()
        {
            ExtendReports ExtRep = new ExtendReports();
            IWebDriver driverFF;

            var op = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            try
            {
                ExtRep.StartReportHandler();
                ExtRep.StartTestLogs("Hyworks Session Team test case started");

                driverFF = new FirefoxDriver(op);
                driverFF.Navigate().GoToUrl("https://172.27.1.81/Admin/en-US/Account/SignIn");

                Thread.Sleep(3000);
                driverFF.FindElement(By.Id("usernameInputBox")).SendKeys("hyworksadmin");
                driverFF.FindElement(By.Id("passwordInputBox")).SendKeys("123");
                driverFF.FindElement(By.Id("loginButton")).Click();

                Thread.Sleep(3000);

                driverFF.FindElement(By.Id("server")).Click();
                Thread.Sleep(3000);
                driverFF.FindElement(By.Name("ProviderTeam")).Click();
                Thread.Sleep(3000);

                driverFF.FindElement(By.Id("rdsteam_provider")).Click();
                Thread.Sleep(3000);

                driverFF.FindElement(By.Id("TeamName")).SendKeys("Teams-Aumation");
                Thread.Sleep(1000);
                driverFF.FindElement(By.Id("LoadBalancingTab")).Click();
                Thread.Sleep(1000);

                driverFF.FindElement(By.Id("TeamLoadBalancingTypeSelect")).Click();
                Thread.Sleep(3000);

                SelectElement se = new SelectElement(driverFF.FindElement(By.Id("TeamLoadBalancingTypeSelect"))); //Locating select list
                se.SelectByText("Weighted Round Robin");
                Thread.Sleep(2000);

                IWebElement webEle = driverFF.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[2]/form/div/div/div[2]/div/div[1]/div[2]/div[2]/div/div[1]/div/div[5]/div/label"));
                webEle.Click();

               // Actions act = new Actions(test);
               // act.Click();
                Thread.Sleep(2000);

                driverFF.FindElement(By.Id("CPUMaxLimit")).SendKeys("10");
                Thread.Sleep(1000);
                driverFF.FindElement(By.Id("RAMMaxLimit")).SendKeys("10");
                Thread.Sleep(1000);


                driverFF.FindElement(By.Id("AppMappingTab")).Click();
                Thread.Sleep(1000);


                driverFF.FindElement(By.Id("SessionTeam_AppAddApps")).Click();
                Thread.Sleep(4000);

                driverFF.FindElement(By.CssSelector(".width1per > label:nth-child(2)")).Click();
                Thread.Sleep(4000);

                driverFF.FindElement(By.Id("btn-addAvailableAppsSelection")).Click();
                Thread.Sleep(3000);


                driverFF.FindElement(By.Id("SaveUpdateRDSTeamT")).Click();
                Thread.Sleep(4000);
                driverFF.Quit();

            }
            catch (Exception ex)
            {
                ExtRep.FailLog("Fail due to ..." + ex.Message);
            }
        }
    }
}
