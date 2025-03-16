using Newtonsoft.Json.Linq;
using RestSharp;

namespace SampleAPITestProject.Core.API
{
    class APIUtils
    {
        public T GetJSONValue<T>(RestResponse response, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(response.Content)) { throw new ArgumentException("Response content is empty"); }

            JObject jsonObject = JObject.Parse(response.Content);
            JToken jToken = jsonObject[propertyName];

            if (jToken == null) { throw new ArgumentException($"Property '{propertyName}' not found in JSON"); }

            return jToken.ToObject<T>();
        }
    }
}
