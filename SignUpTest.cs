using AutomationWorkshop.Pages;
using AutomationWorkshop.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationWorkshop
{
    [TestClass]
    public class SignUpTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");

            //accept cookies
            driver.FindElement(By.XPath("//p[contains(text(), 'Consent')]")).Click();

            //implicit wait - waits 2 seconds for every instance of the WeDriver
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            driver.Close();
        }

        [TestMethod]
        public void Should_CreateUserAccount_When_ProvidingValidDetails()
        {
            //Go to Create account page
            HomePage homePage = new HomePage(driver);
            CreateAccountPage createAccountPage = homePage.GoToCreateAccountPage();

            //Assert: user has reached correct page
            string expectedTitle = "Create New Customer Account";
            string actualTitle = createAccountPage.GetPageTitle();

            Assert.AreEqual(expectedTitle, actualTitle, "Page title is not the expected one.");

            //Fill in user details
            UserDetails user = new UserDetails()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Email = "firstname_lastname@email.com", //make sure to change this at every run
                Password = "Automation01.",
                ConfirmPassword = "Automation01."
            };

            AccountPage accountDetailsPage = createAccountPage.FillUserDetails(user);

            //Check if account has been created
            Assert.IsTrue(accountDetailsPage.IsMessageDisplayed(), "Account creation failed");
        }
    }
}