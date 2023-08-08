using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Push : ApiBase
    {
        internal Push(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Adds push subscription.</para>
        /// <para>allowed values of policy: "all", "followed", "follower", "none"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> subscription[endpoint] (required)</para>
        /// <para>- <c>string</c> subscription[keys][p256dh] (required)</para>
        /// <para>- <c>string</c> subscription[keys][auth] (required)</para>
        /// <para>- <c>bool</c> data[alerts][mention] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][status] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow_request] (mention)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][poll] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][update] (optional)</para>
        /// <para>- <c>string</c> policy (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<WebPushSubscription> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<WebPushSubscription>(MethodType.Post, "push/subscription", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Adds push subscription.</para>
        /// <para>allowed values of policy: "all", "followed", "follower", "none"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> subscription[endpoint] (required)</para>
        /// <para>- <c>string</c> subscription[keys][p256dh] (required)</para>
        /// <para>- <c>string</c> subscription[keys][auth] (required)</para>
        /// <para>- <c>bool</c> data[alerts][mention] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][status] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow_request] (mention)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][poll] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][update] (optional)</para>
        /// <para>- <c>string</c> policy (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<WebPushSubscription> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<WebPushSubscription>(MethodType.Post, "push/subscription", parameters);
        }

        /// <summary>
        /// <para>Returns current push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<WebPushSubscription> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<WebPushSubscription>(MethodType.Get, "push/subscription", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns current push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<WebPushSubscription> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<WebPushSubscription>(MethodType.Get, "push/subscription", parameters);
        }

        /// <summary>
        /// <para>Updates push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> data[alerts][mention] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][status] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow_request] (mention)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][poll] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][update] (optional)</para>
        /// <para>- <c>string</c> policy (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<WebPushSubscription> PutAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<WebPushSubscription>(MethodType.Put, "push/subscription", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Updates push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> data[alerts][mention] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][status] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow_request] (mention)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][poll] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][update] (optional)</para>
        /// <para>- <c>string</c> policy (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<WebPushSubscription> PutAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<WebPushSubscription>(MethodType.Put, "push/subscription", parameters);
        }

        /// <summary>
        /// <para>Removes current push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Delete, "push/subscription", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Removes current push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Delete, "push/subscription", parameters);
        }
    }
}
