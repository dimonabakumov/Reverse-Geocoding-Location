using Microsoft.VisualStudio.TestTools.WebTesting;
using ThaiApiTesting.ValidationRules;

namespace ThaiApiTesting.RequestsCore
{
    public class Requests
    {
        public WebTestRequest Get(string url, int expectedCode = 200, int responseTimeGoal = 1)
        {
            var request = new WebTestRequest(url)
            {
                Method = "GET",
                ExpectedHttpStatusCode = expectedCode,
                ResponseTimeGoal = responseTimeGoal,
            };

            if (expectedCode == 200)
                request.ValidateResponse += new ModelValitionRule().Validate;

            return request;
        }
    }
}
