using System;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
namespace HyWorksAutomationSuite.Views.CommonToTheme
{
    public class GotoPageFooterControl
    {
        public void GotoPageFooterTest()
        {
            IWebDriver driverFF;
            driverFF = new FirefoxDriver();

            string UrlConstant = "https://172.16.16.26/Admin/en-US/";

            string[] PageArr =
                {
                "UserSession/UserSessionHome", "ApplicationSession/ApplicationSessionHome", "Session/SessionHome", "Device/DeviceHome", "Desktop/DesktopHome", "UserDetails/UserDetailsHome",
                "AnnouncementSettings/AnnouncementHome", "HostedApp/HostedAppHome", "DesktopPools/DesktopPoolsHome", "System/SystemHome?Name=Connection", "Entitlement/UserHome", "Entitlement/GroupHome",
                "Entitlement/OUHome", "Entitlement/PoolHome", "Server/ServerHome?Name=ProviderTeam", "LocalDb/UserHome", "LocalDb/GroupHome", "AccessControl/UserRoleMappingHome",
                "AccessControl/privilegeHome", "AccessPolicy/ClientGroupsHome", "Logs/LogsHome"
             };

            driverFF.Navigate().GoToUrl("http://localhost:61544/Admin/en-US/Account/SignIn");

            Thread.Sleep(3000);

            driverFF.FindElement(By.Id("usernameInputBox")).SendKeys("panoadmin");
            driverFF.FindElement(By.Id("passwordInputBox")).SendKeys("adminpano");
            driverFF.FindElement(By.Id("loginButton")).Click();

            Thread.Sleep(3000);
           
            if (PageArr.Length > 0)
            {
                for (int j = 0; j < PageArr.Length; j++)
                {
                    driverFF.Navigate().GoToUrl(UrlConstant + PageArr[j]);
                    Thread.Sleep(3000);

                    var pageCount = driverFF.FindElement(By.Id("tottalnumberofPages")).GetAttribute("textContent");
                    Thread.Sleep(3000);

                    int totalPage = Convert.ToInt32(pageCount);
                    if (totalPage > 1)
                    {
                        for (int i = 1; i < totalPage; i++)
                        {
                            string num = Convert.ToString(i);
                            driverFF.FindElement(By.Id("gotopageInput")).Clear();
                            Thread.Sleep(3000);
                            driverFF.FindElement(By.Id("gotopageInput")).SendKeys(num);
                            Thread.Sleep(3000);
                            driverFF.FindElement(By.Id("GotoPageButton")).Click();
                            Thread.Sleep(3000);
                        }
                    }
                    Thread.Sleep(3000);
                }
            }


            driverFF.Quit();

        }
    }
}
