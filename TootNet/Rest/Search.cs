using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;

namespace TootNet.Rest
{
    public class Search : ApiBase
    {
        internal Search(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Search for content in accounts, statuses and hashtags.</para>
        /// <para>allowed values of types: "accounts", "hashtags", "statuses"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// <para>- <c>string</c> type (optional)</para>
        /// <para>- <c>bool</c> resolve (optional)</para>
        /// <para>- <c>bool</c> following (optional)</para>
        /// <para>- <c>long</c> account_id (optional)</para>
        /// <para>- <c>bool</c> exclude_unreviewed (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the results object.</para>
        /// </returns>
        public Task<Objects.Search> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Objects.Search>(MethodType.Get, "search", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <para>Search for content in accounts, statuses and hashtags.</para>
        /// <para>allowed values of types: "accounts", "hashtags", "statuses"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// <para>- <c>string</c> type (optional)</para>
        /// <para>- <c>bool</c> resolve (optional)</para>
        /// <para>- <c>bool</c> following (optional)</para>
        /// <para>- <c>long</c> account_id (optional)</para>
        /// <para>- <c>bool</c> exclude_unreviewed (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the results object.</para>
        /// </returns>
        public Task<Objects.Search> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Objects.Search>(MethodType.Get, "search", parameters, apiVersion: "v2");
        }
    }
}
