using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Statuses : ApiBase
    {
        internal Statuses(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Post a new status.</para>
        /// <para>format of scheduled_at: "2019-01-01 12:00:00" (ISO 8601)</para>
        /// <para>format of language: "jpn" (ISO 639-2)"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> status (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> media_ids (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> poll[options] (optional)</para>
        /// <para>- <c>int</c> poll[expires_in] (optional)</para>
        /// <para>- <c>bool</c> poll[multiple] (optional)</para>
        /// <para>- <c>bool</c> poll[hide_totals] (optional)</para>
        /// <para>- <c>long</c> in_reply_to_id (optional)</para>
        /// <para>- <c>bool</c> sensitive (optional)</para>
        /// <para>- <c>bool</c> spoiler_text (optional)</para>
        /// <para>- <c>string</c> visibility (optional)</para>
        /// <para>- <c>string</c> language (optional)</para>
        /// <para>- <c>string</c> scheduled_at (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Status>(MethodType.Post, "statuses", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Post a new status.</para>
        /// <para>format of scheduled_at: "2019-01-01 12:00:00" (ISO 8601)</para>
        /// <para>format of language: "jpn" (ISO 639-2)"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> status (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> media_ids (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> poll[options] (optional)</para>
        /// <para>- <c>int</c> poll[expires_in] (optional)</para>
        /// <para>- <c>bool</c> poll[multiple] (optional)</para>
        /// <para>- <c>bool</c> poll[hide_totals] (optional)</para>
        /// <para>- <c>long</c> in_reply_to_id (optional)</para>
        /// <para>- <c>bool</c> sensitive (optional)</para>
        /// <para>- <c>bool</c> spoiler_text (optional)</para>
        /// <para>- <c>string</c> visibility (optional)</para>
        /// <para>- <c>string</c> language (optional)</para>
        /// <para>- <c>string</c> scheduled_at (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Status>(MethodType.Post, "statuses", parameters);
        }

        /// <summary>
        /// <para>Return a status specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> IdAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Get, "statuses/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Return a status specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Get, "statuses/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Delete a status.</para>
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
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "statuses/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Delete a status.</para>
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
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "statuses/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Returns a context specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the context object.</para>
        /// </returns>
        public Task<Context> ContextAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Context>(MethodType.Get, "statuses/{id}/context", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a context specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the context object.</para>
        /// </returns>
        public Task<Context> ContextAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Context>(MethodType.Get, "statuses/{id}/context", "id", parameters);
        }

        /// <summary>
        /// <para>Get who reblogged a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> RebloggedByAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "statuses/{id}/reblogged_by", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get who reblogged a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> RebloggedByAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "statuses/{id}/reblogged_by", "id", parameters);
        }

        /// <summary>
        /// <para>Get who favourited a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> FavouritedByAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "statuses/{id}/favourited_by", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get who favourited a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> FavouritedByAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "statuses/{id}/favourited_by", "id", parameters);
        }

        /// <summary>
        /// <para>Reblog a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> ReblogAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/reblog", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Reblog a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> ReblogAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/reblog", "id", parameters);
        }

        /// <summary>
        /// <para>Unreblog a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnreblogAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unreblog", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Unreblog a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnreblogAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unreblog", "id", parameters);
        }

        /// <summary>
        /// <para>Pin a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> PinAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/pin", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Pin a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> PinAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/pin", "id", parameters);
        }

        /// <summary>
        /// <para>Unpin a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnpinAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unpin", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Unpin a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnpinAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unpin", "id", parameters);
        }

        /// <summary>
        /// <para>Edit a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> status (optional)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> media_ids (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> poll[options] (optional)</para>
        /// <para>- <c>int</c> poll[expires_in] (optional)</para>
        /// <para>- <c>bool</c> poll[multiple] (optional)</para>
        /// <para>- <c>bool</c> poll[hide_totals] (optional)</para>
        /// <para>- <c>bool</c> sensitive (optional)</para>
        /// <para>- <c>bool</c> spoiler_text (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> PutAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Put, "statuses/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Edit a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> status (optional)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> media_ids (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> poll[options] (optional)</para>
        /// <para>- <c>int</c> poll[expires_in] (optional)</para>
        /// <para>- <c>bool</c> poll[multiple] (optional)</para>
        /// <para>- <c>bool</c> poll[hide_totals] (optional)</para>
        /// <para>- <c>bool</c> sensitive (optional)</para>
        /// <para>- <c>bool</c> spoiler_text (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> PutAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Put, "statuses/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Get edit history of a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status edit object.</para>
        /// </returns>
        public Task<IEnumerable<StatusEdit>> HistoryAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<IEnumerable<StatusEdit>>(MethodType.Get, "statuses/{id}/history", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get edit history of a status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status edit object.</para>
        /// </returns>
        public Task<IEnumerable<StatusEdit>> HistoryAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<IEnumerable<StatusEdit>>(MethodType.Get, "statuses/{id}/history", "id", parameters);
        }

        /// <summary>
        /// <para>Get status source.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status source object.</para>
        /// </returns>
        public Task<StatusSource> SourceAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<StatusSource>(MethodType.Get, "statuses/{id}/source", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get status source.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status source object.</para>
        /// </returns>
        public Task<StatusSource> SourceAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<StatusSource>(MethodType.Get, "statuses/{id}/source", "id", parameters);
        }
    }
}
