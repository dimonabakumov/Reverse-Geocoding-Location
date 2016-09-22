using FluentAssertions;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using ThaiApiTesting.Models;
using ThaiApiTesting.RequestsCore;

namespace ThaiApiTesting.TestCases
{
    [CodedWebTest]
    public class RadiusChecking : BaseWebTest
    {
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            //Validate that it works with correct coordinate and default radius
            //And validate that response contains the same radius

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f));
            var response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("5");


            //Validate that it works with correct coordinate and radius = 15
            //And validate that response contains the same radius

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 15));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("15");


            //Validate that it works with correct coordinate and float radius = 15.715
            //And validate that response contains the same radius

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 15.715f));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("15.715");


            //Validate that it works with correct coordinate and float radius = 0.715
            //And validate that response contains the same radius

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 0.715f));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("0.715");


            //Validate correct server response when radius = 0

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 0));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("0");


            //Validate correct server response when radius < 0

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, -12), 400);


            //Validate correct server response when radius is null

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, null), 200);
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("5");


            //Validate that item_found1 > item_found2 when radius1 > radius2

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 10000));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("10000");
            var item_found1 = response.item_found;

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.radius.ShouldBeEquivalentTo("1000");
            var item_found2 = response.item_found;

            item_found1.Should().BeGreaterThan(item_found2);
        }
    }
}
