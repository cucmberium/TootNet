using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class FeaturedTags : ApiBase
    {
        internal FeaturedTags(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Get your featured tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of featured tag object.</para>
        /// </returns>
        public Task<IEnumerable<FeaturedTag>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<FeaturedTag>>(MethodType.Get, "featured_tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get your featured tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of featured tag object.</para>
        /// </returns>
        public Task<IEnumerable<FeaturedTag>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<FeaturedTag>>(MethodType.Get, "featured_tags", parameters);
        }

        /// <summary>
        /// <para>Feature a tag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> name (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the featured tag object.</para>
        /// </returns>
        public Task<FeaturedTag> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<FeaturedTag>(MethodType.Post, "featured_tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Feature a tag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> name (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the featured tag object.</para>
        /// </returns>
        public Task<FeaturedTag> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<FeaturedTag>(MethodType.Post, "featured_tags", parameters);
        }

        /// <summary>
        /// <para>Unfeature a tag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the featured tag object.</para>
        /// </returns>
        public Task DeleteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Delete, "featured_tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Unfeature a tag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the featured tag object.</para>
        /// </returns>
        public Task DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Delete, "featured_tags", parameters);
        }

        /// <summary>
        /// <para>Get suggested tags to feature.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of tag object.</para>
        /// </returns>
        public Task<IEnumerable<Tag>> SuggestionAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Tag>>(MethodType.Get, "featured_tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get suggested tags to feature.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of tag object.</para>
        /// </returns>
        public Task<IEnumerable<Tag>> SuggestionAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Tag>>(MethodType.Get, "featured_tags", parameters);
        }

        /// <summary>
        /// <para>Get account's featured tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of featured tag object.</para>
        /// </returns>
        public Task<IEnumerable<FeaturedTag>> AccountAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<IEnumerable<FeaturedTag>>(MethodType.Get, "accounts/{id}/featured_tags", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get account's featured tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of featured tag object.</para>
        /// </returns>
        public Task<IEnumerable<FeaturedTag>> AccountAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<IEnumerable<FeaturedTag>>(MethodType.Get, "accounts/{id}/featured_tags", "id", parameters);
        }
    }
}
