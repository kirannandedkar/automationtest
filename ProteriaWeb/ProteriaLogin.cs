using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ProteriaWeb
{
    class ProteriaLogin
    {        
        IWebDriver driver;
        
        [OneTimeSetUp]
        public void startBrowser()
        {  
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Manage().Window.FullScreen();
        }
       
        [Test, Order(1)]
       public void login_User()
       {           
           driver.Url = "https://app.proteria.com/ProTeria.Auth/Account/Login";
           IWebElement element = driver.FindElement(By.Id("Email"));
           element.SendKeys("kiran@proteria.com");
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
           element = driver.FindElement(By.Id("Password"));
           element.SendKeys("May2018#");
           element = driver.FindElement(By.XPath(".//*[@id='loginForm']/div/div[3]/div[1]/button"));
           element.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Boolean bFlag = driver.FindElement(By.Id("NavBarContainerLoggedInUser")).Displayed;
           Assert.IsTrue(bFlag, "Logged in fail");

       }

       [Test, Order(2)]
       public void Post_Nord()
       {
           OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);
           
           IWebElement element = driver.FindElement(By.XPath(".//*[@id='TopNav_NewShipmentLink']/span"));
           String text = element.Text;
           Assert.AreEqual(text, "Ny PostNord");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);         
            element.Click();
           driver.FindElement(By.Id("Receiver-autosearch")).SendKeys("Prot");
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           driver.FindElement(By.XPath(".//*[@id='overviewBox']/div[1]/div[1]/div[3]/div[1]/ul/li[2]/a/div/div[2]")).Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           driver.FindElement(By.Id("parcelsTable_Weight_0")).SendKeys("2");
           driver.FindElement(By.Id("parcelsTable_Length_0")).SendKeys("3");
           driver.FindElement(By.Id("parcelsTable_Width_0")).SendKeys("4");
           driver.FindElement(By.Id("parcelsTable_Height_0")).SendKeys("5");
           
           element = driver.FindElement(By.XPath(".//*[@id='btnSaveSend']"));            
            element.SendKeys(Keys.ArrowUp);
            element.SendKeys(Keys.ArrowUp);            
            element.SendKeys(Keys.ArrowUp);            
            element.SendKeys(Keys.ArrowUp);            
            Thread.Sleep(10000);
            element.Click();


       }

       [Test, Order(3)]
       public void logout_User()
       {

           IWebElement element = driver.FindElement(By.Id("NavBarContainerLoggedInUser"));
           element.Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
           element = driver.FindElement(By.XPath(".//*[@id='NavBarContainerLoggedInUserDroppedDown']/li[6]/a"));
           element.Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
           Boolean bFlag = driver.FindElement(By.Id("Email")).Displayed;
           Assert.IsTrue(bFlag, "Logged out fail");

       }

        [OneTimeTearDown]
        public void closeBrowser()
        {           
            driver.Close();
            driver.Quit();
        }
        
    }
}
