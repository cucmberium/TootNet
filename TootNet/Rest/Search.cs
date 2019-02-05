using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Search : ApiBase
    {
        internal Search(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Search for content in accounts, statuses and hashtags.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>bool</c> resolve (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the results object.</para>
        /// </returns>
        public Task<Results> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Results>(MethodType.Get, "api/v2/search", Utils.ExpressionToDictionary(parameters), useApiPath: false);
        }

        /// <summary>
        /// <para>Search for content in accounts, statuses and hashtags.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>bool</c> resolve (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the results object.</para>
        /// </returns>
        public Task<Results> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Results>(MethodType.Get, "api/v2/search", parameters, useApiPath: false);
        }
    }
}
