using FluentAssertions;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using ThaiApiTesting.Models;
using ThaiApiTesting.RequestsCore;
using System;

namespace ThaiApiTesting.TestCases
{
    [CodedWebTest]
    public class PaginationChecking : BaseWebTest
    {
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            //Get first server response and save it with default offset

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.145f, 10000));
            var firstResponse = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);


            //Get next page from current step

            yield return requests.Get(ThaiUrls.thaiApi + firstResponse.next_parameter);
            var nextResponse = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);


            //Get server response with offset = 15 and compare docs collection with nextResponse docs collection. 
            //It should be equals.

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.145f, 10000, offset:15));
            var firstOffserResponse = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            firstOffserResponse.docs.ShouldBeEquivalentTo(nextResponse.docs);


            //Get previous page from firstOffserResponse and docs collection with firstResponse docs collection.
            //It should be equals.

            yield return requests.Get(ThaiUrls.thaiApi + firstOffserResponse.prev_parameter);
            var prevResponse = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            prevResponse.docs.ShouldBeEquivalentTo(firstResponse.docs);


            //Validate correct server response when offset is float (15.7)

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, offset: 0.7f), 200);


            //Validate correct server response when offset < 0

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, offset: -25), 400);


            //Get first server response and previous page after that

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.145f, 10000));
            firstResponse = JsonConvert.DeserializeObject<Response>(Context.LastResponse.BodyString);
            yield return requests.Get(ThaiUrls.thaiApi + firstResponse.prev_parameter);
        }
    }
}
