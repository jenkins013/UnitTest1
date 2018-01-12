using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace IISappUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        InternetExplorerOptions options = new InternetExplorerOptions();
         String path = @"C:\Program Files (x86)\Jenkins\workspace\UnitTestJob\IISappUnitTestProject";

        IWebDriver IEDriver = null;
        [TestInitialize]
        public void initialize()
        {
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
           // IEDriver = new InternetExplorerDriver(options);
            IEDriver = new InternetExplorerDriver(path,options);
            IEDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));

        }
        [TestMethod]
        public void TestMethod1()
        {
            IEDriver.Navigate().GoToUrl("https://applicationjenkins.azurewebsites.net ");
            IEDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            IEDriver.Manage().Window.Maximize();
            IWebElement verifyText = IEDriver.FindElement(By.XPath("//*[@class='btn btn-primary btn-lg']"));
            //IWebElement verifyText = IEDriver.FindElement(By.XPath("/ html / body / div[2] / div[1] / p[1]]"));
            if (verifyText.GetAttribute("innerHTML").Trim().Equals("Learn more »"))
            {
                Console.WriteLine("Text matched");
            }
            else
            {
                Console.WriteLine("Text is not matched");
                Assert.Fail();
            }
            //IWebElement verifyText = IEDriver.FindElement(By.XPath("/ html / body / div[2] / div[1] / p[1]]"));
            //if (verifyText.GetAttribute("innerHTML").Trim().Equals("ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript. modify1"))
            //{
            //    Console.WriteLine("Text matched");
            //}
            //else
            //{
            //    Console.WriteLine("Text is not matched");
            //    Assert.Fail();
            //}
        }
        [TestCleanup]
        public void Testcleanup()
        {
            IEDriver.Close();
        }
    }
}
