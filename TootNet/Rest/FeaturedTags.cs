// Generated by TootNet.Generator.  DO NOT EDIT!

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
        /// <para>View your featured tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of featuredtag object.</para>
        /// </returns>
        public Task<ListResponse<Objects.FeaturedTag>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.FeaturedTag>>(MethodType.Get, "featured_tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="GetAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.FeaturedTag>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.FeaturedTag>>(MethodType.Get, "featured_tags", parameters);
        }

        /// <summary>
        /// <para>Feature a tag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> name (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the featuredtag object.</para>
        /// </returns>
        public Task<Objects.FeaturedTag> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Objects.FeaturedTag>(MethodType.Post, "featured_tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PostAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.FeaturedTag> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Objects.FeaturedTag>(MethodType.Post, "featured_tags", parameters);
        }

        /// <summary>
        /// <para>Unfeature a tag.</para>
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
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "featured_tags/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="DeleteAsync(Expression{Func{string, object}}[])"/>
        public Task DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "featured_tags/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>View suggested tags to feature.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of tag object.</para>
        /// </returns>
        public Task<ListResponse<Objects.Tag>> SuggestionsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Tag>>(MethodType.Get, "featured_tags/suggestions", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="SuggestionsAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.Tag>> SuggestionsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Tag>>(MethodType.Get, "featured_tags/suggestions", parameters);
        }
    }
}
