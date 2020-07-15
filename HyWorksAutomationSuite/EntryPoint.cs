using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using HyWorksAutomationSuite.Views;
using HyWorksAutomationSuite.Views.CommonToTheme;
using HyWorksAutomationSuite.Views.Login;
using HyWorksAutomationSuite.Views.SessionTeams;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using HyWorksAutomationSuite;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

class Program
{
    public static void Main()
    {

        LoginDetails LoginDetails = new LoginDetails();
        try
        {
            string HyConfigFile = "C:\\Users\\NAND.TANDULJE\\Documents\\Nand\\Auto\\HyWorksAutomationSuite\\HyWorksAutomationSuite\\ConfigHyWorks.xml";

            Serializer ser = new Serializer();
            string path = string.Empty;
            string xmlInputData = string.Empty;
            string xmlOutputData = string.Empty;

            xmlInputData = File.ReadAllText(HyConfigFile);


            //HyWorksConfig customer = ser.Deserialize<HyWorksConfig>(xmlInputData);
            //xmlOutputData = ser.Serialize<HyWorksConfig>(customer);

            HyWorksConfig config = new HyWorksConfig();
            using (TextReader reader = new StreamReader(HyConfigFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HyWorksConfig));
                config =  (HyWorksConfig)serializer.Deserialize(reader);
            }

            //Login to HyWorks
            Login loginHyW = new Login();
            loginHyW.LoginTest();
            Thread.Sleep(3000);

            //Test goto page  
            //GotoPageFooterControl gpfooter = new GotoPageFooterControl();
            //gpfooter.GotoPageFooterTest();

            //SessionTeam
            SessionTeam sessionTeam = new SessionTeam();
            sessionTeam.SessionTeamAdd();


            Thread.Sleep(3000);
        }
        catch (Exception ex)
        {
           
        }
    }
}
