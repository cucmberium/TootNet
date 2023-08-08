using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Polls : ApiBase
    {
        internal Polls(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Get a poll.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the poll object.</para>
        /// </returns>
        public Task<Poll> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Poll>(MethodType.Get, "polls/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get a poll.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the poll object.</para>
        /// </returns>
        public Task<Poll> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Poll>(MethodType.Get, "polls/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Vote on a poll.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>IEnumerable&lt;int&gt;</c> choices (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the poll object.</para>
        /// </returns>
        public Task<Relationship> VotesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "polls/{id}/votes", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Vote on a poll.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>IEnumerable&lt;int&gt;</c> choices (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the poll object.</para>
        /// </returns>
        public Task<Relationship> VotesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "polls/{id}/votes", "id", parameters);
        }
    }
}
