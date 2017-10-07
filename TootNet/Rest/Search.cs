using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Search : ApiBase
    {
        internal Search(Tokens e) : base(e) { }

        /// <summary>
        /// <para>If q is a URL, Mastodon will attempt to fetch the provided account or status.</para>
        /// <para>Otherwise, it will do a local account and hashtag search.</para>
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
            return Tokens.AccessApiAsync<Results>(MethodType.Get, "search", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>If q is a URL, Mastodon will attempt to fetch the provided account or status.</para>
        /// <para>Otherwise, it will do a local account and hashtag search.</para>
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
            return Tokens.AccessApiAsync<Results>(MethodType.Get, "search", parameters);
        }
    }
}
