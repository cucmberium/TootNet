using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Mutes : ApiBase
    {
        internal Mutes(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Return current account's mutes.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Account>>(MethodType.Get, "mutes", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Return current account's mutes.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Account>>(MethodType.Get, "mutes", parameters);
        }

        /// <summary>
        /// <para>Mute an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>bool</c> notifications (optional)</para>
        /// <para>- <c>int</c> duration (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> MuteAccountAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/mute", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Mute an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>bool</c> notifications (optional)</para>
        /// <para>- <c>int</c> duration (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> MuteAccountAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/mute", "id", parameters);
        }

        /// <summary>
        /// <para>Unmute an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> UnmuteAccountAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/unmute", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Unmute an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> UnmuteAccountAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/unmute", "id", parameters);
        }
        
        /// <summary>
        /// <para>Mute an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> MuteStatusAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/mute", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Mute an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> MuteStatusAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/mute", "id", parameters);
        }

        /// <summary>
        /// <para>Unmute an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnmuteStatusAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unmute", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Unmute an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnmuteStatusAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unmute", "id", parameters);
        }
    }
}
