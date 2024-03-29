﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Physitrack.AutomationFramework.Drivers;
using Physitrack.WebAutomation.Pages.Common;
using TechTalk.SpecFlow;

namespace Physitrack.WebAutomation.Pages
{
    public class Clients
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        private WebDriverWait _wait;
        private Modal modal;
        public Clients(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(_seleniumDriver.Driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement closeButton => _seleniumDriver.Driver.FindElement(By.CssSelector("button[title='Quit Tour']"));
        public void CloseModal()
        {
            modal = new Modal(_scenarioContext, _seleniumDriver);
            modal.CloseModal();
        }
        public bool ClientAssignedToProgram(string programCode)
        {
            if (_seleniumDriver.Driver.FindElements(By.XPath("//*[contains(text(), '" + programCode + "')]")).Count > 0)
                return true;
            return false;
        }
    }
}
