using NUnit.Framework;
using Physitrack.AutomationFramework.Drivers;
using Physitrack.AutomationFramework.Setup;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Physitrack.WebAutomation.Hooks
{
	[Binding]
	public class HookInitialization: SeleniumDriver
    {
        private SeleniumDriver _seleniumDriver;
		private readonly ScenarioContext _scenarioContext;

		public HookInitialization(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
		{
			_scenarioContext = scenarioContext;
			_seleniumDriver = seleniumDriver;
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			Driver driver = new Driver(_scenarioContext, _seleniumDriver);
			_scenarioContext.Set(driver, "SeleniumDriver");
			driver.Driver = _scenarioContext.Get<Driver>("SeleniumDriver").Setup("");
		}

		[AfterScenario]
		public void AfterScenario()
		{
			_scenarioContext.Get<Driver>("SeleniumDriver").Driver.Quit();
		}
	}
}
