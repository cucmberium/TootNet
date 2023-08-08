using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Bookmarks : ApiBase
    {
        internal Bookmarks(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Return current account's bookmarks.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Status>>(MethodType.Get, "bookmarks", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Return current account's bookmarks.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Status>>(MethodType.Get, "bookmarks", parameters);
        }

        /// <summary>
        /// <para>Bookmark an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> BookmarkAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/bookmark", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Bookmark an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> BookmarkAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/bookmark", "id", parameters);
        }

        /// <summary>
        /// <para>Unbookmark an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnbookmarkAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unbookmark", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Unbookmark an status.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the status object.</para>
        /// </returns>
        public Task<Status> UnbookmarkAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Status>(MethodType.Post, "statuses/{id}/unbookmark", "id", parameters);
        }
    }
}
