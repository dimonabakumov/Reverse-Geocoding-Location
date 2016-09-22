using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThaiApiTesting
{
    public static class ThaiUrls
    {
        public static string thaiApi = "http://thai-api-staging.mapsynq.com/reverse_geocode?";
        public static string ReverseGeocode(float? lat, float? lng, float? radius = 5, string lang = "en")
        {
            StringBuilder url = new StringBuilder(thaiApi);

            if (lat.HasValue)
                url.Append($"lat={lat}&");

            if (lng.HasValue)
                url.Append($"lng={lng}&");

            return url.Append($"radius={radius}&lang={lang}").ToString();
        }
    }
}
