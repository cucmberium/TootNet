// Generated by TootNet.Generator.  DO NOT EDIT!

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Tags : ApiBase
    {
        internal Tags(Tokens e) : base(e) { }

        /// <summary>
        /// <para>View information about a single tag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the tag object.</para>
        /// </returns>
        public Task<Objects.Tag> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Tag>(MethodType.Get, "tags/{tag}", "tag", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="GetAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.Tag> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Tag>(MethodType.Get, "tags/{tag}", "tag", parameters);
        }

        /// <summary>
        /// <para>View all followed tags.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of tag object.</para>
        /// </returns>
        public Task<Linked<Objects.Tag>> FollowedTagsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Objects.Tag>>(MethodType.Get, "followed_tags", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="FollowedTagsAsync(Expression{Func{string, object}}[])"/>
        public Task<Linked<Objects.Tag>> FollowedTagsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Objects.Tag>>(MethodType.Get, "followed_tags", parameters);
        }

        /// <summary>
        /// <para>Follow a hashtag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the tag object.</para>
        /// </returns>
        public Task<Objects.Tag> FollowAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Tag>(MethodType.Post, "tags/{tag}/follow", "tag", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="FollowAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.Tag> FollowAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Tag>(MethodType.Post, "tags/{tag}/follow", "tag", parameters);
        }

        /// <summary>
        /// <para>Unfollow a hashtag.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the tag object.</para>
        /// </returns>
        public Task<Objects.Tag> UnfollowAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Tag>(MethodType.Post, "tags/{tag}/unfollow", "tag", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="UnfollowAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.Tag> UnfollowAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Tag>(MethodType.Post, "tags/{tag}/unfollow", "tag", parameters);
        }
    }
}
