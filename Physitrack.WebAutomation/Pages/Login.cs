using OpenQA.Selenium;
using Physitrack.AutomationFramework.Drivers;
using TechTalk.SpecFlow;

namespace Physitrack.WebAutomation.Pages
{
    public class Login
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        public Login(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _scenarioContext = scenarioContext;
        }
        IWebElement demoLink => _seleniumDriver.Driver.FindElement(By.CssSelector("a[class='link-back-to-demo']"));

        public void ClickDemo() => demoLink.Click();
    }
}
