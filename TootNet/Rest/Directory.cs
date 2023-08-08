using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Directory : ApiBase
    {
        internal Directory(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns profile directory.</para>
        /// <para>allowed values of order: "active", "new"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// <para>- <c>string</c> order (optional)</para>
        /// <para>- <c>bool</c> local (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Account>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Account>>(MethodType.Get, "directory", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns profile directory.</para>
        /// <para>allowed values of order: "active", "new"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// <para>- <c>string</c> order (optional)</para>
        /// <para>- <c>bool</c> local (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Account>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Account>>(MethodType.Get, "directory", parameters);
        }
    }
}
