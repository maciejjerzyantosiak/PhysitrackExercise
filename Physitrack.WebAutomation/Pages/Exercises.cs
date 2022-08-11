using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Physitrack.AutomationFramework.Drivers;
using Physitrack.WebAutomation.Pages.Common;
using TechTalk.SpecFlow;

namespace Physitrack.WebAutomation.Pages
{
    public class Exercises
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        private WebDriverWait _wait;
        private Modal modal;
        public Exercises(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(_seleniumDriver.Driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement closeButton => _seleniumDriver.Driver.FindElement(By.CssSelector("button[title='Quit Tour']"));
        private IWebElement basketButton => _seleniumDriver.Driver.FindElement(By.CssSelector("img[src='https://us.physitrack.com/assets/pt/basket_active-4f79c87cb256d416cdeee4d4fcdea3ff2e06a85cbdfadb291894037b7b5250ea.svg']"));
        private IWebElement searchBar => _seleniumDriver.Driver.FindElement(By.CssSelector("input[class='input search main w-input']"));
        private IList<IWebElement> exercisesList => _seleniumDriver.Driver.FindElements(By.CssSelector("div[class='list-content-container']"));

        public void CloseModal()
        {
            modal = new Modal(_scenarioContext, _seleniumDriver);
            modal.CloseModal();
        }
        public void AddExerciseToPlan(int index)
        {
            _seleniumDriver.Driver.SwitchTo().DefaultContent();
            exercisesList[index].FindElement(By.CssSelector("img[class='cb exercise-checkbox']")).Click();
        }
        public void Search(string exercise)
        {
            searchBar.SendKeys(exercise);
            searchBar.SendKeys(Keys.Enter);
        }
        public void OpenBasket()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("img[src='https://us.physitrack.com/assets/pt/basket_active-4f79c87cb256d416cdeee4d4fcdea3ff2e06a85cbdfadb291894037b7b5250ea.svg']")));
            basketButton.Click();
        }
    }
}
