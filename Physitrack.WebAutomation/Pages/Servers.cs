using OpenQA.Selenium;
using Physitrack.AutomationFramework.Drivers;
using TechTalk.SpecFlow;

namespace Physitrack.WebAutomation.Pages
{
    public class Servers
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        public Servers(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _scenarioContext = scenarioContext;
        }
        private IWebElement continueButton => _seleniumDriver.Driver.FindElement(By.CssSelector("button[class='btn-link pad-top choose-server']"));
        public void ClickContinue() => continueButton.Click();

        public void ClickCountryRadioButton(string countryCode) => _seleniumDriver.Driver.FindElement(By.Id("country_" + countryCode)).Click();
    }
}
