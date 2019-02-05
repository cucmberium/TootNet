using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class FollowSuggestions : ApiBase
    {
        internal FollowSuggestions(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns a list of follow suggestions.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Account>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Account>>(MethodType.Get, "suggestions", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a list of follow suggestions.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Account>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Account>>(MethodType.Get, "suggestions", parameters);
        }

        /// <summary>
        /// <para>Deletes a user from follow suggestions.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> account_id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "suggestions/{account_id}", "account_id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Deletes a user from follow suggestions.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> account_id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "suggestions/{account_id}", "account_id", parameters);
        }
    }
}
