using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using ThaiApiTesting.Models;

namespace ThaiApiTesting.ValidationRules
{
    public class ModelValitionRule : ValidationRule
    {
        public override void Validate(object sender, ValidationEventArgs e)
        {
            var serverResponse = JsonConvert.DeserializeObject<Response>(e.Response.BodyString);
            var validationResult = new ResponseModelValidator().Validate(serverResponse);
            e.IsValid = validationResult.IsValid;

            if (validationResult.IsValid) return;

            foreach (var result in validationResult.Errors)
                e.WebTest.AddCommentToResult("Property " + result.PropertyName + " failed validation. Error was: " + result.ErrorMessage);
        }
    }
}
