using OpenQA.Selenium;

namespace AutomationWorkshop.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement CreateAccountLink => driver.FindElement(By.LinkText("Create an Account"));

        public CreateAccountPage GoToCreateAccountPage()
        {
            CreateAccountLink.Click();

            return new CreateAccountPage(driver);
        }
    }
}
