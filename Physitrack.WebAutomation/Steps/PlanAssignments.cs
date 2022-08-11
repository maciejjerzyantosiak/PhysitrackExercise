using Physitrack.AutomationFramework.Drivers;
using Physitrack.WebAutomation.Pages;
using TechTalk.SpecFlow;
using Physitrack.AutomationFramework.Helpers;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace Physitrack.WebAutomation.Steps
{
    [Binding]
    public class PlanAssignments
    {
        private SeleniumDriver _seleniumDriver;
        private readonly ScenarioContext _scenarioContext;
        private Home home;
        private Servers servers;
        private Login login;
        private Exercises exercises;
        private ExercisePrograms exercisePrograms;
        private Clients clients;
        public PlanAssignments(ScenarioContext scenarioContext, SeleniumDriver seleniumDriver)
        {
            _scenarioContext = scenarioContext;
            _seleniumDriver = seleniumDriver;
        }
        [Given(@"user is country selection page")]
        public void GivenUserIsCountrySelectionPage()
        {
            _seleniumDriver.Driver.Url = ConfigurationManager.AppSetting["testedAppUrl"];
            home = new Home(_scenarioContext, _seleniumDriver);
            home.ClickLogin();
            _seleniumDriver.Driver.SwitchTo().Window(_seleniumDriver.Driver.WindowHandles[1]);
        }
        
        [When(@"user selects '(.*)'")]
        public void WhenUserSelects(string p0)
        {   if(_seleniumDriver.Driver.Url.Contains("physitrack.com/servers"))
            {
                servers = new Servers(_scenarioContext, _seleniumDriver);
                servers.ClickCountryRadioButton(p0);
                servers.ClickContinue();
            }
            login = new Login(_scenarioContext, _seleniumDriver);
            login.ClickDemo();
        }
        
        [When(@"user adds exercise to the plan")]
        public void WhenUserAddsExerciseToThePlan(Table table)
        {
            dynamic _exercise = table.CreateDynamicInstance();
            exercises = new Exercises(_scenarioContext, _seleniumDriver);
            exercises.CloseModal();
            exercises.Search((string)_exercise.Exercise);
            exercises.CloseModal();
            exercises.AddExerciseToPlan(0);
            exercises.OpenBasket();
        }
        
        [When(@"user assigns plan to a '(.*)' patient")]
        public void WhenUserAssignsPlanToAPatient(string p0)
        {
            exercisePrograms = new ExercisePrograms(_scenarioContext, _seleniumDriver);
            exercisePrograms.CloseModal();
            exercisePrograms.Assign();
            exercisePrograms.AssignPatient(p0);
        }
        
        [Then(@"plan is assigned to a '(.*)' patient")]
        public void ThenPlanIsAssignedToAPatient(string p0)
        {
            Assert.True(exercisePrograms.PatientAssigned());
            var code = exercisePrograms.GetCode();
            exercisePrograms.OpenPatient();
            clients = new Clients(_scenarioContext, _seleniumDriver);
            clients.CloseModal();
            Assert.True(clients.ClientAssignedToProgram(code));
        }
    }
}
