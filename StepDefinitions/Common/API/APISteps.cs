using SampleAPITestProject.Core.API;
using Reqnroll;

namespace SampleAPITestProject
{
    [Binding]
    class APISteps
    {
        private readonly APIClient _apiClient;
        public APISteps(APIClient apiClient) { _apiClient = apiClient; }

        [StepDefinition(@"I set the API baseURL to '(.*)'")]
        public void ISetAPIUrl(string apiURL)
        {
            _apiClient.SetBaseURL(apiURL);
        }
    }
}
