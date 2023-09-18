using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace TootNet.Internal
{
    internal static class Utils
    {
        internal static string CreateUrlParameter(string url, IEnumerable<KeyValuePair<string, object>> param)
        {
            if (param == null)
                return url;

            return url + "?" + string.Join("&", param.Select(kvp => kvp.Value is bool ? $"{kvp.Key}={kvp.Value.ToString().ToLower()}" : $"{kvp.Key}={WebUtility.UrlEncode(kvp.Value.ToString())}"));
        }

        internal static KeyValuePair<string, object> GetReservedParameter(List<KeyValuePair<string, object>> parameters, string reserved)
        {
            return parameters.Single(kvp => kvp.Key == reserved);
        }


        internal static object GetExpressionValue(Expression<Func<string, object>> expr)
        {
            return expr.Body is ConstantExpression constExpr ? constExpr.Value : expr.Compile()("");
        }

        internal static IDictionary<string, object> ExpressionToDictionary(Expression<Func<string, object>>[] parameters)
        {
            return parameters.Select(x => new KeyValuePair<string, object>(x.Parameters[0].Name, GetExpressionValue(x)))
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
