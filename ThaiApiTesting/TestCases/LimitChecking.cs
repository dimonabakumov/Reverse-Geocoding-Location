using FluentAssertions;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using ThaiApiTesting.Models;
using ThaiApiTesting.RequestsCore;

namespace ThaiApiTesting.TestCases
{
    [CodedWebTest]
    public class LimitChecking : BaseWebTest
    {
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            //Validate that default limit equals 15

            float limit = 15;
            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000));
            var response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.item_per_page.ShouldBeEquivalentTo(limit);
            if (response.item_found > limit)
                response.docs.Count.ShouldBeEquivalentTo(limit);


            //Validate correct behaviour when increase limit to 100

            limit = 100;
            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, limit: limit));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.item_per_page.ShouldBeEquivalentTo(limit);
            if (response.item_found > limit)
                response.docs.Count.ShouldBeEquivalentTo(limit);


            //Validate correct behaviour when increase limit to 1000

            limit = 1000;
            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, limit: limit));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.item_per_page.ShouldBeEquivalentTo(limit);
            if (response.item_found > limit)
                response.docs.Count.ShouldBeEquivalentTo(limit);


            //Validate correct behaviour when set limit as 0

            limit = 0;
            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, limit: limit));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.item_per_page.ShouldBeEquivalentTo(limit);
            if (response.item_found > limit)
                response.docs.Count.ShouldBeEquivalentTo(limit);


            //Validate correct behaviour when set limit as 15.7

            limit = 15.7f;
            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, limit: limit), 400);


            //Validate correct behaviour when set limit as -40

            limit = -40;
            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, limit: limit), 400);
        }
    }
}
