using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationWorkshop.Pages
{
    public class AccountPage
    {
        private IWebDriver driver;

        public AccountPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement SuccessMessage => driver.FindElement(By.CssSelector("[data-ui-id='message-success']"));

        //assert
        public bool IsMessageDisplayed()
        {
            //wait 3 seconds for the message to be displayed
            WaitForElementToBeDisplayed(SuccessMessage, 3);

            return SuccessMessage.Displayed;
        }

        //explicit wait
        public void WaitForElementToBeDisplayed(IWebElement element, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            //waits the specified condition to be true, throws exception otherwise
            wait.Until(driver => element.Displayed);
        }
    }
}
