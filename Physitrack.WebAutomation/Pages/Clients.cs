using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Physitrack.AutomationFramework.Drivers;
using TechTalk.SpecFlow;

namespace Physitrack.WebAutomation.Pages
{
    public class Clients
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        private WebDriverWait _wait;
        public Clients(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(_seleniumDriver.Driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement closeButton => _seleniumDriver.Driver.FindElement(By.CssSelector("button[title='Quit Tour']"));
        public void CloseModal()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("iframe[title='Tour']")));
            _seleniumDriver.Driver.SwitchTo().Frame(_seleniumDriver.Driver.FindElement(By.CssSelector("iframe[title='Tour']")));
            closeButton.Click();
            _seleniumDriver.Driver.SwitchTo().DefaultContent();
        }
        public bool ClientAssignedToProgram(string programCode)
        {
            if (_seleniumDriver.Driver.FindElements(By.XPath("//*[contains(text(), '" + programCode + "')]")).Count > 0)
                return true;
            return false;
        }
    }
}
