using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Filters : ApiBase
    {
        internal Filters(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Text filters the user has configured that potentially must be applied client-side.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of filter object.</para>
        /// </returns>
        public Task<IEnumerable<Filter>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Filter>>(MethodType.Get, "filters", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Text filters the user has configured that potentially must be applied client-side.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of filter object.</para>
        /// </returns>
        public Task<IEnumerable<Filter>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Filter>>(MethodType.Get, "filters", parameters);
        }

        /// <summary>
        /// <para>Create a new filter.</para>
        /// <para>allowed values of context: "home", "notifications", "public", "thread"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> phrase (required)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> context (required)</para>
        /// <para>- <c>bool</c> irreversible (optional)</para>
        /// <para>- <c>bool</c> whole_word (optional)</para>
        /// <para>- <c>int</c> expires_in (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Filter> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Filter>(MethodType.Post, "filters", parameters);
        }

        /// <summary>
        /// <para>Create a new filter.</para>
        /// <para>allowed values of context: "home", "notifications", "public", "thread"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> phrase (required)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> context (required)</para>
        /// <para>- <c>bool</c> irreversible (optional)</para>
        /// <para>- <c>bool</c> whole_word (optional)</para>
        /// <para>- <c>int</c> expires_in (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Filter> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Filter>(MethodType.Post, "filters", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Filter> IdAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Filter>(MethodType.Get, "filters/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Filter> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Filter>(MethodType.Get, "filters/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Updates a filter.</para>
        /// <para>allowed values of context: "home", "notifications", "public", "thread"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> phrase (required)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> context (required)</para>
        /// <para>- <c>bool</c> irreversible (optional)</para>
        /// <para>- <c>bool</c> whole_word (optional)</para>
        /// <para>- <c>int</c> expires_in (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Filter> UpdateAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Filter>(MethodType.Put, "filters/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Updates a filter.</para>
        /// <para>allowed values of context: "home", "notifications", "public", "thread"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> phrase (required)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> context (required)</para>
        /// <para>- <c>bool</c> irreversible (optional)</para>
        /// <para>- <c>bool</c> whole_word (optional)</para>
        /// <para>- <c>int</c> expires_in (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Filter> UpdateAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Filter>(MethodType.Put, "filters/{id}", "id", parameters);
        }
        
        /// <summary>
        /// <para>Deletes a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "filters/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Deletes a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "filters/{id}", "id", parameters);
        }
    }
}
