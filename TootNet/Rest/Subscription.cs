using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Subscription : ApiBase
    {
        internal Subscription(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Adds push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> subscription[endpoint] (required)</para>
        /// <para>- <c>string</c> subscription[keys][p256dh] (required)</para>
        /// <para>- <c>string</c> subscription[keys][auth] (required)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (mention)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<PushSubscription> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<PushSubscription>(MethodType.Post, "push/subscription", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Adds push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> subscription[endpoint] (required)</para>
        /// <para>- <c>string</c> subscription[keys][p256dh] (required)</para>
        /// <para>- <c>string</c> subscription[keys][auth] (required)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (mention)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<PushSubscription> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<PushSubscription>(MethodType.Post, "push/subscription", parameters);
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
        public Task<PushSubscription> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<PushSubscription>(MethodType.Get, "push/subscription", Utils.ExpressionToDictionary(parameters));
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
        public Task<PushSubscription> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<PushSubscription>(MethodType.Get, "push/subscription", parameters);
        }

        /// <summary>
        /// <para>Updates push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> subscription[endpoint] (required)</para>
        /// <para>- <c>string</c> subscription[keys][p256dh] (required)</para>
        /// <para>- <c>string</c> subscription[keys][auth] (required)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (mention)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<PushSubscription> UpdateAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<PushSubscription>(MethodType.Put, "push/subscription", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Updates push subscription.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> subscription[endpoint] (required)</para>
        /// <para>- <c>string</c> subscription[keys][p256dh] (required)</para>
        /// <para>- <c>string</c> subscription[keys][auth] (required)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][favourite] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][reblog] (optional)</para>
        /// <para>- <c>bool</c> data[alerts][follow] (mention)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the pushsubscription object.</para>
        /// </returns>
        public Task<PushSubscription> UpdateAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<PushSubscription>(MethodType.Put, "push/subscription", parameters);
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
