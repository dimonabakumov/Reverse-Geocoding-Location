using FluentAssertions;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThaiApiTesting.Models;
using ThaiApiTesting.RequestsCore;

namespace ThaiApiTesting.TestCases
{
    [CodedWebTest]
    public class LatAndLngChecking : BaseWebTest
    {
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            //Validate that it works with correct coordinate
            //And validate that response contains the same coordinate
              
            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f));
            var response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.lat.ShouldBeEquivalentTo(5.668142);
            response.lng.ShouldBeEquivalentTo(Math.Round(101.144964, 3));


            //Validate that it works with correct coordinate(integer type)
            //And validate that response contains the same coordinate

            yield return requests.Get(ThaiUrls.ReverseGeocode(5, 101));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.lat.ShouldBeEquivalentTo(5);
            response.lng.ShouldBeEquivalentTo(101);


            //Validate that it works with correct coordinate(latitude < 0)
            //And validate that response contains the same coordinate

            yield return requests.Get(ThaiUrls.ReverseGeocode(-15, 101));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.lat.ShouldBeEquivalentTo(-15);
            response.lng.ShouldBeEquivalentTo(101);


            //Validate that it works with correct coordinate(longitude < 0)
            //And validate that response contains the same coordinate

            yield return requests.Get(ThaiUrls.ReverseGeocode(5, -101));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.lat.ShouldBeEquivalentTo(5);
            response.lng.ShouldBeEquivalentTo(-101);


            //Validate that it works with correct coordinate(latitude < 0 & longitude < 0)
            //And validate that response contains the same coordinate

            yield return requests.Get(ThaiUrls.ReverseGeocode(-15, -101));
            response = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            response.lat.ShouldBeEquivalentTo(-15);
            response.lng.ShouldBeEquivalentTo(-101);


            //Validate correct server response when latitude is missing

            yield return requests.Get(ThaiUrls.ReverseGeocode(null, -101), 400);


            //Validate correct server response when longitude is missing

            yield return requests.Get(ThaiUrls.ReverseGeocode(-15, null), 400);


            //Validate correct server response when latitude is incorrect (latitude > 90 )

            yield return requests.Get(ThaiUrls.ReverseGeocode(100, -101), 400);


            //Validate correct server response when latitude is incorrect (latitude < -90 )

            yield return requests.Get(ThaiUrls.ReverseGeocode(-100, -101), 400);


            //Validate correct server response when longitude is incorrect (longitude > 180 )

            yield return requests.Get(ThaiUrls.ReverseGeocode(10, 200), 400);


            //Validate correct server response when longitude is incorrect (longitude < -180 )

            yield return requests.Get(ThaiUrls.ReverseGeocode(10, -200), 400);
        }
    }
}
