using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Physitrack.AutomationFramework.Drivers;
using Physitrack.WebAutomation.Pages.Common;
using TechTalk.SpecFlow;

namespace Physitrack.WebAutomation.Pages
{
    public class ExercisePrograms
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        private WebDriverWait _wait;
        private Modal modal;
        public ExercisePrograms(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(_seleniumDriver.Driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement closeButton => _seleniumDriver.Driver.FindElement(By.CssSelector("button[title='Quit Tour']"));
        private IWebElement assignButton => _seleniumDriver.Driver.FindElement(By.CssSelector("img[src='https://us.physitrack.com/assets/pt/icon-plane-white-36850c0d5835768be51ed8092d35e1ffd0ce46631e4af7a22e6d03efb1e77004.svg']"));
        private IWebElement submitButton => _seleniumDriver.Driver.FindElement(By.CssSelector("button[type='submit']"));
        private IWebElement assignementForm => _seleniumDriver.Driver.FindElement(By.Id("assign-protocol-form"));
        private IWebElement patientInput => _seleniumDriver.Driver.FindElement(By.Id("react-select-2-input"));
        private IList<IWebElement> links => _seleniumDriver.Driver.FindElements(By.CssSelector("a[class='content-link']"));
        private IList<IWebElement> boldedTexts => _seleniumDriver.Driver.FindElements(By.TagName("strong"));

        public void CloseModal()
        {
            modal = new Modal(_scenarioContext, _seleniumDriver);
            modal.CloseModal();
        }
        public void Assign()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("img[src='https://us.physitrack.com/assets/pt/icon-plane-white-36850c0d5835768be51ed8092d35e1ffd0ce46631e4af7a22e6d03efb1e77004.svg']")));
            assignButton.Click();
        }
        public string GetCode()
        {
            return boldedTexts[9].Text;
        }
        public void OpenPatient() => links[0].Click();
        public void AssignPatient(string patientName)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("div[class='react-select__input']")));
            _seleniumDriver.Driver.FindElement(By.CssSelector("div[class='react-select__value-container css-1hwfws3']")).Click();
            patientInput.SendKeys(patientName);
            Thread.Sleep(1000);
            patientInput.SendKeys(Keys.Enter);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button[type='submit']")));
            submit();
        }
        public void submit() => submitButton.Click();
        public bool PatientAssigned()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div[class='callout assigned'] > strong"), "Program assigned."));
            if (assignementForm.FindElement(By.TagName("strong")).Text == "Program assigned.")
                return true;
            return false;
        }

    }
}
