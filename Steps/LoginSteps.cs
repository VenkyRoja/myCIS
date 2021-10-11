using myCIS.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace myCIS.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        //----------------------------

        LoginPage loginpage = null;
        HomePage homepage = null;
        IWebDriver driver = new FirefoxDriver(@"C:\Venky\Dev\drivers");
        //IWebDriver driver = new ChromeDriver(@"C:\Venky\Dev\drivers");


        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            var myIni = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddIniFile(path: "my.ini", optional: false, reloadOnChange: true)
                .Build();

            string myurl = myIni.GetValue<String>("WebGroup:URL_DEV");

            Console.WriteLine("----- " + myurl + "-------------");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(myurl);

            loginpage = new LoginPage(driver);
            homepage = new HomePage(driver);
        }


        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string uname = (string)data.UserName;
            string pwd = (string)data.Password;
            loginpage.Type_Login_Details(uname, pwd);
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            loginpage.Click_login_button();
        }


        [Given(@"I should see logo image")]
        public void GivenIShouldSeeLogoImage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Assert.IsTrue(homepage.Is_Logo_Image_Displayed());
        }

        [Given(@"I logout application")]
        public void GivenILogoutApplication()
        {
            homepage.Logout();
        }



        [Given(@"I should see login error message")]
        public void GivenIShouldSeeLoginErrorMessage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Assert.IsTrue(loginpage.Is_error_message_displayed());
        }


        [Then(@"I close application")]
        public void ThenICloseApplication()
        {
            driver.Quit();

            Process[] geckoDriverProcesses = Process.GetProcessesByName("geckodriver");

            foreach (var geckoDriverProcess in geckoDriverProcesses)
            {
                geckoDriverProcess.Kill();
            }

            /*
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
            */
        }


        //------------------------------
    }
}
