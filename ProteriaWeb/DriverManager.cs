using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteriaWeb
{
    class DriverManager
    {

        ChromeDriver crDriver = null;

        public void CRDriver()
        {

        }

        /*public WebDriver wdLaunchChrome()
        {
            String strPath = System.getProperty("user.dir");
            System.setProperty("webdriver.chrome.driver", (strPath + ("\\src\\main\\\resources" + "\\Chrome\\chromedriver.exe")));
            this.crDriver = new ChromeDriver();
            this.crDriver.manage().window().maximize();
            return this.crDriver;
        }*/
    }
}
