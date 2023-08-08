﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Notifications : ApiBase
    {
        internal Notifications(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns notification objects related current account.</para>
        /// <para>allowed values of types: "mention", "status", "reblog", "follow", "follow_request", "favourite", "poll", "update"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> types (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> exclude_types (optional)</para>
        /// <para>- <c>long</c> account_id (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of notification object.</para>
        /// </returns>
        public Task<Linked<Notification>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Notification>>(MethodType.Get, "notifications", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns notification objects related current account.</para>
        /// <para>allowed values of types: "mention", "status", "reblog", "follow", "follow_request", "favourite", "poll", "update"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> types (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> exclude_types (optional)</para>
        /// <para>- <c>long</c> account_id (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of notification object.</para>
        /// </returns>
        public Task<Linked<Notification>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Notification>>(MethodType.Get, "notifications", parameters);
        }

        /// <summary>
        /// <para>Returns single notification object specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the notification object.</para>
        /// </returns>
        public Task<Notification> IdAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Notification>(MethodType.Get, "notifications/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns single notification object specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the notification object.</para>
        /// </returns>
        public Task<Notification> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Notification>(MethodType.Get, "notifications/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Deletes all notifications from the Mastodon server for the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task ClearAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Post, "notifications/clear", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Deletes all notifications from the Mastodon server for the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task ClearAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Post, "notifications/clear", parameters);
        }

        /// <summary>
        /// <para>Deletes a single notification from the Mastodon server for the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DismissAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Notification>(MethodType.Post, "notifications/{id}/dismiss", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Deletes a single notification from the Mastodon server for the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DismissAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Notification>(MethodType.Post, "notifications/{id}/dismiss", "id", parameters);
        }
    }
}
