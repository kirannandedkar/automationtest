using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ProteriaWeb.DevAuto.PageObject.Login;
using ProteriaWeb.DevAuto.PageObject.NyBrevetikett;
using ProteriaWeb.DevAuto.PageObject.NyBring;
using ProteriaWeb.DevAuto.PageObject.NyNord;
using ProteriaWeb.DevAuto.Services.Resources;

namespace ProteriaWeb
{
    internal class ProteriaLogin
    {
        private IWebDriver driver;
        private IWebElement element;
        private CNyBring pgBring;
        private CBrevetikett pgCBrevetikett;
        private CLogin pgLogin;
        private CNyPostNord pgNyNord;
        private WithMultipleReceiver wmrBring;
        private readonly CProject_Recources rCProject_Recources = new CProject_Recources();

        [OneTimeSetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Manage().Window.FullScreen();
            pgLogin = new CLogin(driver);
            pgBring = new CNyBring(driver);
            pgCBrevetikett = new CBrevetikett(driver);
            pgNyNord = new CNyPostNord(driver);
            wmrBring = new WithMultipleReceiver(driver);
            rCProject_Recources.buildURL = "https://app.proteria.com/ProTeria.Auth/Account/Login";
            rCProject_Recources.userName = "kiran@proteria.com";
            rCProject_Recources.password = "May2018#";
        }

        [Test]
        [Order(1)]
        public void login_User()
        {
            driver.Url = rCProject_Recources.buildURL;
            element = pgLogin.Get_Email_TB();
            element.SendKeys(rCProject_Recources.userName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            element = pgLogin.Get_Password_TB();
            element.SendKeys(rCProject_Recources.password);
            element = pgLogin.Get_Login_BT();
            element.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var bFlag = driver.FindElement(By.Id("NavBarContainerLoggedInUser")).Displayed;
            Assert.IsTrue(bFlag, "Logged in fail");
        }

        //[Test]
        //[Order(2)]
        //public void Post_Nord()
        //{
        //    var actions = new Actions(driver);

        //    var element = driver.FindElement(By.XPath(".//*[@id='TopNav_NewShipmentLink']/span"));
        //    actions.MoveToElement(element).Perform();
        //    element = driver.FindElement(By.XPath(".//*[@id='mainTopNav']/li[2]/ul/li[5]/a"));
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        //    element.Click();
        //    pgNyNord.Get_Mottaker_TB().SendKeys("Prot");
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    pgNyNord.Get_Proteria_Val().Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    pgNyNord.Get_Weight_TB().SendKeys("2");
        //    pgNyNord.Get_Length_TB().SendKeys("3");
        //    pgNyNord.Get_Width_TB().SendKeys("4");
        //    pgNyNord.Get_Height_TB().SendKeys("5");
        //    pgNyNord.Get_NyPostNord_BT().SendKeys(Keys.ArrowUp);
        //    pgNyNord.Get_NyPostNord_BT().SendKeys(Keys.ArrowUp);
        //    pgNyNord.Get_NyPostNord_BT().SendKeys(Keys.ArrowUp);
        //    pgNyNord.Get_NyPostNord_BT().SendKeys(Keys.ArrowUp);
        //    Thread.Sleep(10000);
        //    pgNyNord.Get_NyPostNord_BT().Click();
        //}

        //[Test]
        //[Order(3)]
        //public void NY_Bring()
        //{
        //    var actions = new Actions(driver);
        //    var element = driver.FindElement(By.XPath(".//*[@id='TopNav_NewShipmentLink']/span"));
        //    actions.MoveToElement(element).Perform();
        //    element = driver.FindElement(By.XPath(".//*[@id='mainTopNav']/li[2]/ul/li[1]/a"));
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //    element.Click();
        //    element = pgBring.Get_Mottaker_TB();
        //    element.SendKeys("Prot");
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    element = pgBring.Get_Proteria_Val();
        //    element.Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    pgBring.Get_Weight_TB().SendKeys("2");
        //    pgBring.Get_Length_TB().SendKeys("3");
        //    pgBring.Get_Width_TB().SendKeys("4");
        //    pgBring.Get_Height_TB().SendKeys("5");
        //    pgBring.Get_ByBring_BT();
        //    pgBring.Get_ByBring_BT().SendKeys(Keys.ArrowUp);
        //    pgBring.Get_ByBring_BT().SendKeys(Keys.ArrowUp);
        //    pgBring.Get_ByBring_BT().SendKeys(Keys.ArrowUp);
        //    Thread.Sleep(10000);
        //    pgBring.Get_ByBring_BT().Click();
        //}


        [Test]
        [Order(3)]
        public void NY_Bring()
        {
            var actions = new Actions(driver);
            var element = driver.FindElement(By.XPath(".//*[@id='TopNav_NewShipmentLink']/span"));
            actions.MoveToElement(element).Perform();
            element = driver.FindElement(By.XPath(".//*[@id='mainTopNav']/li[2]/ul/li[1]/a"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            element.Click();
            element = pgBring.Get_Mottaker_TB();
            element.SendKeys("Proteriaas");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = wmrBring.Get_Proteria_Val();
            element.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = wmrBring.Get_Value_FromDropdown();
            element.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            pgBring.Get_Weight_TB().SendKeys("2");
            pgBring.Get_Length_TB().SendKeys("3");
            pgBring.Get_Width_TB().SendKeys("4");
            pgBring.Get_Height_TB().SendKeys("5");
            pgBring.Get_ByBring_BT();
            pgBring.Get_ByBring_BT().SendKeys(Keys.ArrowUp);
            pgBring.Get_ByBring_BT().SendKeys(Keys.ArrowUp);
            pgBring.Get_ByBring_BT().SendKeys(Keys.ArrowUp);
            Thread.Sleep(10000);
            pgBring.Get_ByBring_BT().Click();
        }

        [Test]
        [Order(4)]
        public void NY_Brevetikett()
        {
            var actions = new Actions(driver);
            var element = driver.FindElement(By.XPath(".//*[@id='TopNav_NewShipmentLink']/span"));
            actions.MoveToElement(element).Perform();
            element = driver.FindElement(By.XPath(".//*[@id='mainTopNav']/li[2]/ul/li[2]/a"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            element.Click();
            element = pgCBrevetikett.Get_Mottaker_TB();
            element.SendKeys("Prot");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            element = pgCBrevetikett.Get_Proteria_Val();
            element.Click();
            Thread.Sleep(5000);
            pgCBrevetikett.Get_SMSTrackig_CB().Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            pgCBrevetikett.Get_Printer_BT();
            pgCBrevetikett.Get_Printer_BT().SendKeys(Keys.ArrowUp);
            pgCBrevetikett.Get_Printer_BT().SendKeys(Keys.ArrowUp);
            pgCBrevetikett.Get_Printer_BT().SendKeys(Keys.ArrowUp);
            Thread.Sleep(10000);
            pgCBrevetikett.Get_Printer_BT().Click();
        }

        [Test]
        [Order(5)]
        public void logout_User()
        {
            pgLogin.Get_Navigation_Br().Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            pgLogin.Get_Logout_Link().Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var bFlag = driver.FindElement(By.Id("Email")).Displayed;
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