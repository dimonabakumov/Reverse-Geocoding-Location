using Microsoft.VisualStudio.TestTools.WebTesting;
using System.Collections.Generic;
using ThaiApiTesting.RequestsCore;

namespace ThaiApiTesting.TestCases
{
    [CodedWebTest]
    public class LanguageChecking : BaseWebTest
    {
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            //Validate correct server response when send lang=en

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f));


            //Validate correct server response when send lang=th

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, "th"));


            //Validate correct server response when send lang=en,th

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, "en,th"));


            //Validate correct server response when send foreign language

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, "ru"));


            //Validate correct server response when send foreign language

            yield return requests.Get(ThaiUrls.ReverseGeocode(5.668142f, 101.144964f, 1000, "sweden"));
        }
    }
}
