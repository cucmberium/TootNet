using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class FollowRequests : ApiBase
    {
        internal FollowRequests(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns current account's follow requests.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Account>>(MethodType.Get, "follow_requests", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns current account's follow requests.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Account>>(MethodType.Get, "follow_requests", parameters);
        }

        /// <summary>
        /// <para>Authorize follow requests.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns empty object.</para>
        /// </returns>
        public Task AuthorizeAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Post, "follow_requests/{id}/authorize", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Authorize follow requests.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns empty object.</para>
        /// </returns>
        public Task AuthorizeAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Post, "follow_requests/{id}/authorize", "id", parameters);
        }

        /// <summary>
        /// <para>Reject follow requests.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns empty object.</para>
        /// </returns>
        public Task RejectAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Post, "follow_requests/{id}/reject", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Reject follow requests.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns empty object.</para>
        /// </returns>
        public Task RejectAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Post, "follow_requests/{id}/reject", "id", parameters);
        }
    }
}
