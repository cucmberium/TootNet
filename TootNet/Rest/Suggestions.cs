using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Suggestions : ApiBase
    {
        internal Suggestions(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns a list of follow suggestions.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Suggestion>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Suggestion>>(MethodType.Get, "suggestions", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <summary>
        /// <para>Returns a list of follow suggestions.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Suggestion>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Suggestion>>(MethodType.Get, "suggestions", parameters, apiVersion: "v2");
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
