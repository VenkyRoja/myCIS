using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCIS.Pages
{
    class LoginPage
    {
        WebDriverWait wait;
        DefaultWait<IWebDriver> fluentWait;

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            fluentWait = new DefaultWait<IWebDriver>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            fluentWait.Message = "Element to be searched not found";
        }

        private IWebDriver Driver { get; }

        public IWebElement txt_UserName => fluentWait.Until(x => x.FindElement(By.XPath("//input[@name='username']")));
        public IWebElement txt_Password => fluentWait.Until(x => x.FindElement(By.XPath("//input[@name='password']")));
        public IWebElement btn_Login => fluentWait.Until(x => x.FindElement(By.XPath("//span[@class='dx-button-text']")));
        
        public IWebElement err_Login => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='error-message']")));


        public void Type_Login_Details(string uname, string pwd)
        {
            txt_UserName.SendKeys(uname);
            Console.WriteLine("----OK with User Name--------");

            txt_Password.SendKeys(pwd);
            Console.WriteLine("----OK with Password--------");
        }

        public void Click_login_button()
        {
            btn_Login.Click();
            Console.WriteLine("----Login button is clicked--------");
        }

        public bool Is_error_message_displayed() {

            //IWebElement err_Login = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='error-message']")));

            Console.WriteLine("----|"+ err_Login.TagName + " ... " + err_Login.Displayed + " ... " + err_Login.GetAttribute("innerText") + "|--------");
            return err_Login.GetAttribute("innerText").Equals("Login authentication failed");
        }

    



        //------------------------


    }
}
