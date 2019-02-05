using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class ScheduledStatuses : ApiBase
    {
        internal ScheduledStatuses(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Get scheduled statuses.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of report object.</para>
        /// </returns>
        public Task<IEnumerable<ScheduledStatus>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<ScheduledStatus>>(MethodType.Get, "scheduled_statuses", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get scheduled statuses.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of report object.</para>
        /// </returns>
        public Task<IEnumerable<ScheduledStatus>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<ScheduledStatus>>(MethodType.Get, "scheduled_statuses", parameters);
        }

        /// <summary>
        /// <para>Get scheduled status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<ScheduledStatus> IdAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ScheduledStatus>(MethodType.Get, "scheduled_statuses/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get scheduled status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<ScheduledStatus> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ScheduledStatus>(MethodType.Get, "scheduled_statuses/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Update Scheduled status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> scheduled_at (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<ScheduledStatus> UpdateAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ScheduledStatus>(MethodType.Put, "scheduled_statuses/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Update Scheduled status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> scheduled_at (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<ScheduledStatus> UpdateAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ScheduledStatus>(MethodType.Put, "scheduled_statuses/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Remove Scheduled status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task DeleteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ScheduledStatus>(MethodType.Delete, "scheduled_statuses/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Remove Scheduled status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ScheduledStatus>(MethodType.Delete, "scheduled_statuses/{id}", "id", parameters);
        }
    }
}
