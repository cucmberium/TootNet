using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TootNet.Internal
{
    internal static class Utils
    {
        public static string CreateUrlParameter(string url, IEnumerable<KeyValuePair<string, object>> param)
        {
            var uri = url + "?" + string.Join("&", 
                param.Select(
                    kvp => string.Format("{0}={1}", kvp.Key, kvp.Value.ToString())));
            return WebUtility.UrlEncode(uri);
        }
    }
}
