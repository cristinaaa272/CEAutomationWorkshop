using AutomationWorkshop.Utils;
using OpenQA.Selenium;

namespace AutomationWorkshop.Pages
{
    public class CreateAccountPage
    {
        private IWebDriver driver;

        public CreateAccountPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement PageTitle => driver.FindElement(By.ClassName("base"));

        private IWebElement FirstName => driver.FindElement(By.Id("firstname"));

        private IWebElement LastName => driver.FindElement(By.Id("lastname"));

        private IWebElement Email => driver.FindElement(By.Id("email_address"));

        private IWebElement Password => driver.FindElement(By.CssSelector("input#password"));

        private IWebElement ConfirmPassword => driver.FindElement(By.Id("password-confirmation"));

        private IWebElement Submit => driver.FindElement(By.CssSelector("[title='Create an Account']"));

        public string GetPageTitle()
        {
            return PageTitle.Text;
        }

        public AccountPage FillUserDetails(UserDetails userDetails)
        {
            FirstName.SendKeys(userDetails.FirstName);
            LastName.SendKeys(userDetails.LastName);
            Email.SendKeys(userDetails.Email);
            Password.SendKeys(userDetails.Password);
            ConfirmPassword.SendKeys(userDetails.ConfirmPassword);

            Submit.Click();

            return new AccountPage(driver);
        }
    }
}
