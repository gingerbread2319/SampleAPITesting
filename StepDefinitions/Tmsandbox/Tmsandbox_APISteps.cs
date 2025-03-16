using SampleAPITestProject.Core.API;
using Reqnroll;
using RestSharp;
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace SampleAPITestProject
{
    [Binding]
    class Tmsandbox_APISteps
    {
        private readonly APIClient _apiClient;
        public Tmsandbox_APISteps(APIClient apiClient) { _apiClient = apiClient; }
        
        public APIUtils APIUtils = new APIUtils();

        private RestResponse response;

        #region HELPERS

        public RestResponse ExecuteCategoriesEndpoint(string categoryID)
        {
            string categoriesEndpoint = $"v1/Categories/{categoryID}/Details.json";
            response = _apiClient.ExecuteRequest(categoriesEndpoint);
            return response;
        }

        #endregion

        #region STEPS

        [StepDefinition(@"I get the details for Category ID: (.*)")]
        public void IGetTheDetailsForCategoryIDN(string categoryID)
        {
            ExecuteCategoriesEndpoint(categoryID);
        }

        [StepDefinition(@"I verify that the Item name is '(.*)'")]
        public void IVerifyThatTheItemNameIs(string name)
        {
            string itemName = APIUtils.GetJSONValue<string>(response, "Name");

            itemName.Should().Be(name);
        }

        [StepDefinition(@"I verify that the '(.*)' JSON property has a value of '(.*)'")]
        public void IVerifyThatTheJSONPropHasValueOf(string name, string value)
        {
            string jsonValue = APIUtils.GetJSONValue<string>(response, name);

            jsonValue.Should().Be(value);
        }

        [StepDefinition(@"I verify that the list of Promotions has an element named '(.*)' with a Description: '(.*)'")]
        public void IVerifyThatThePromotionsListHasElementAndDescription(string elementName, string description)
        {
            bool elementFound = false;
            JArray promotions = APIUtils.GetJSONValue<JArray>(response, "Promotions");

            foreach (JToken promotion in promotions)
            {
                string? name = promotion["Name"]?.ToString();
                string? desc = promotion["Description"]?.ToString();

                if (!string.IsNullOrEmpty(name) && name.Equals(elementName, StringComparison.OrdinalIgnoreCase))
                {
                    elementFound = true;
                    name.Should().Be(elementName);
                    desc.Should().Be(description);
                    break;
                }
            }

            if (!elementFound)
            {
                throw new InvalidOperationException($"Element with Name '{elementName}' not found in Promotions.");
            }
        }

        #endregion
    }
}


