using Reqnroll;
using SampleAPITestProject.Core;
using AventStack.ExtentReports.Gherkin.Model;

namespace SampleAPITestProject.Hooks
{
    [Binding]
    public class ReqNRollHooks : ExtentReport
    {
        private readonly ScenarioContext _scenarioContext;

        public ReqNRollHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeFeature]
        public static void BeforeFeaturew(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                if (stepType.ToLower() == "given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType.ToLower() == "when")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType.ToLower() == "then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
            }

            if (scenarioContext.TestError != null)
            {
                if (stepType.ToLower() == "given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType.ToLower() == "when")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message); ;
                }
                else if (stepType.ToLower() == "then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message); ;
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine($"Scenario: {_scenarioContext.ScenarioInfo.Title} execution completed.");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReport.ExtentReportTeardown();
        }
    }
}