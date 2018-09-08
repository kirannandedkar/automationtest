using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProteriaWeb.DevAuto.PageObject.NyBrevetikett
{
    class CBrevetikett
    {
        IWebDriver Local_Driver;

        /**
             * <summary> This is a constructor method of CNyBring class
             * </summary>
         */

        public CBrevetikett(IWebDriver Global_Driver)
        {
            this.Local_Driver = Global_Driver;
        }
        

        /**
        * <summary> This method will return a text field of Mottaker
        * </summary>
        */

        public IWebElement Get_Mottaker_TB()
        {
            return Local_Driver.FindElement(By.Id("Receiver-autosearch"));
        }

        /**
     * <summary> This method will return a drop down value for Proteria
     * </summary>
     */

        public IWebElement Get_Proteria_Val()
        {
            return Local_Driver.FindElement(By.XPath(".//*[@id='overviewBox']/div/div[1]/div[3]/div[1]/ul/li[2]/a/div/div[1]"));
        }
        /**
   
        /**
          * <summary> This method will return a text field of Text values
          * </summary>
          */

        public IWebElement Get_SMSTrackig_CB()
        {
            return Local_Driver.FindElement(By.Id("SMSTrackingChecked"));
        }


        /**
        * <summary> This method will return a login button
        * </summary>
        */

        public IWebElement Get_Printer_BT()
        {
            return Local_Driver.FindElement(By.Id("btnToPrinterQueue"));
        }
    }
}
//--------------------------------------------------------------------------------------------------------------//
//                                       END OF FILE                                                            //
//--------------------------------------------------------------------------------------------------------------//    

