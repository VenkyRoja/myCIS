using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCIS.Pages
{
    class HomePage
    {
        WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        }

        private IWebDriver Driver { get; }

        public IWebElement img_Logo => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//img[@alt='CIS Infinity 5']")));

        public IWebElement img_Avatar => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//img[@alt='Avatar']")));

        public IWebElement mnu_Logout => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[contains(text(),'Logout')]")));

        public bool Is_Logo_Image_Displayed() => img_Logo.Displayed;

        public void Logout()
        {
            img_Avatar.Click();
            mnu_Logout.Click();
        }

    }
}

