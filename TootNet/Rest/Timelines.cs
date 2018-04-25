using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Timelines : ApiBase
    {
        internal Timelines(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Retrieve home timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> HomeAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Status>>(MethodType.Get, "timelines/home", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Retrieve home timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> HomeAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Status>>(MethodType.Get, "timelines/home", parameters);
        }

        /// <summary>
        /// <para>Retrieve public timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> local (optional)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> PublicAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Status>>(MethodType.Get, "timelines/public", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Retrieve public timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> local (optional)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> PublicAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Status>>(MethodType.Get, "timelines/public", parameters);
        }

        /// <summary>
        /// <para>Retrieve tag timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> hashtag (required)</para>
        /// <para>- <c>bool</c> local (optional)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> TagAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Get, "timelines/tag/{hashtag}", "hashtag", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Retrieve tag timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> hashtag (required)</para>
        /// <para>- <c>bool</c> local (optional)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> TagAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Get, "timelines/tag/{hashtag}", "hashtag", parameters);
        }

        /// <summary>
        /// <para>Retrieve list timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> list_id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> ListAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Get, "timelines/list/{list_id}", "list_id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Retrieve list timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> list_id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> ListAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Get, "timelines/list/{list_id}", "list_id", parameters);
        }
    }
}
