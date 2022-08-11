using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Physitrack.AutomationFramework.Drivers;
using Physitrack.AutomationFramework.Helpers;
using TechTalk.SpecFlow;

namespace Physitrack.AutomationFramework.Setup
{
    public class Driver: SeleniumDriver
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        public Driver(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _scenarioContext = scenarioContext;
            _seleniumDriver = seleniumDriver;
        }
        public IWebDriver Setup(string browserName)
        {
            _seleniumDriver.Driver = GetDriver(browserName);
            _seleniumDriver.Driver.Manage().Window.Maximize();          
            return _seleniumDriver.Driver;
        }
        private IWebDriver GetDriver(string browserName)
        {
            if(browserName.Length == 0)
            {
                if (ConfigurationManager.AppSetting["defaultBrowser"].ToLower() == "remote")
                {
                    if(ConfigurationManager.AppSetting["defaultDriver"].ToLower() == "chrome")
                    {
                        var options = new ChromeOptions();
                        options.AddArguments("--incognito");
                        return new RemoteWebDriver(new Uri(ConfigurationManager.AppSetting["seleniumServerUrl"]), options);
                    } 
                    return new RemoteWebDriver(new Uri(ConfigurationManager.AppSetting["seleniumServerUrl"]), new FirefoxOptions());
                }
                if (ConfigurationManager.AppSetting["defaultBrowser"].ToLower() == "chrome")
                    return new ChromeDriver();
                else return new FirefoxDriver();
            }
            else
            {
                if (browserName.ToLower() == "chrome")
                    return new ChromeDriver();
                else return new FirefoxDriver();
            }
        }
    }
}
