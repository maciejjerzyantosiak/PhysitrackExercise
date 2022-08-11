using OpenQA.Selenium;
using Physitrack.AutomationFramework.Drivers;
using TechTalk.SpecFlow;

namespace Physitrack.WebAutomation.Pages
{
    public class Home
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        public Home(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _scenarioContext = scenarioContext;
        }
        IWebElement loginButton => _seleniumDriver.Driver.FindElement(By.CssSelector("a[class='button-secondary button-small margin-left w-button']"));

        public void ClickLogin() => loginButton.Click();
    }
}
