using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProteriaWeb.DevAuto.PageObject.Login
{
    /**
         * <summary> This is class will manage login pange objects
         * </summary>
    */

    public class CLogin
    {
        IWebDriver Local_Driver;

        /**
             * <summary> This is a constructor method of CLogin class
             * </summary>
         */

        public CLogin(IWebDriver Global_Driver) {
            this.Local_Driver = Global_Driver;
        }

        /**
         * <summary> This method will return a text field of email address
         * </summary>
         */

        public IWebElement Get_Email_TB() {
          return  Local_Driver.FindElement(By.Id("Email"));
        }

        /**
        * <summary> This method will return a text field of password
        * </summary>
        */

        public IWebElement Get_Password_TB()
        {
            return Local_Driver.FindElement(By.Id("Password"));
        }
        /**
    * <summary> This method will return a text field of Navigation
    * </summary>
    */

        public IWebElement Get_Navigation_Br()
        {
            return Local_Driver.FindElement(By.Id("NavBarContainerLoggedInUser"));
        }
        /**
* <summary> This method will return a text field of Navigation
* </summary>
*/

        public IWebElement Get_Logout_Link()
        {
            return Local_Driver.FindElement(By.XPath(".//*[@id='NavBarContainerLoggedInUserDroppedDown']/li[6]/a"));
        }

        

        /**
        * <summary> This method will return a login button
        * </summary>
        */

        public IWebElement Get_Login_BT()
        {
            return Local_Driver.FindElement(By.XPath(".//*[@id='loginForm']/div/div[3]/div[1]/button"));
        }
    }
}
//--------------------------------------------------------------------------------------------------------------//
//                                       END OF FILE                                                            //
//--------------------------------------------------------------------------------------------------------------//