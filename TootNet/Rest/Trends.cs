using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Trends : ApiBase
    {
        internal Trends(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns trending tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of tag object.</para>
        /// </returns>
        public Task<IEnumerable<Tag>> TagsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Tag>>(MethodType.Get, "trends/tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns trending tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of tag object.</para>
        /// </returns>
        public Task<IEnumerable<Tag>> TagsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Tag>>(MethodType.Get, "trends/tags", parameters);
        }

        /// <summary>
        /// <para>Returns trending statuses.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status object.</para>
        /// </returns>
        public Task<IEnumerable<Status>> StatusesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Status>>(MethodType.Get, "trends/statuses", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns trending statuses.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status object.</para>
        /// </returns>
        public Task<IEnumerable<Status>> StatusesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Status>>(MethodType.Get, "trends/statuses", parameters);
        }

        /// <summary>
        /// <para>Returns trending links.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of prewview card object.</para>
        /// </returns>
        public Task<IEnumerable<PreviewCard>> LinksAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<PreviewCard>>(MethodType.Get, "trends/links", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns trending links.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of prewview card object.</para>
        /// </returns>
        public Task<IEnumerable<PreviewCard>> LinksAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<PreviewCard>>(MethodType.Get, "trends/links", parameters);
        }
    }
}
