using FluentAssertions;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using ThaiApiTesting.Models;
using ThaiApiTesting.RequestsCore;

namespace ThaiApiTesting.TestCases
{
    [CodedWebTest]
    public class SortChecking : BaseWebTest
    {
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            //Validate that default sort is Fuzzy

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, radius:100, sort: null));
            var response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.sort_strategy.ShouldBeEquivalentTo("f");
            AddCommentToResult(Context.LastResponse.BodyString);


            //Validate that default sort is Fuzzy

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, radius: 100, sort: "f"));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.sort_strategy.ShouldBeEquivalentTo("f");
            AddCommentToResult(Context.LastResponse.BodyString);


            //Validate that server response contains distance sort when send sort = d

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, radius: 100, sort: "d"));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.sort_strategy.ShouldBeEquivalentTo("d");
            AddCommentToResult(Context.LastResponse.BodyString);


            //Validate correct server response when send inexistent type of sort

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, sort: "y"), 400);


            //Validate correct server response when send inexistent type of sort

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, sort: "99"), 400);
        }
    }
}
