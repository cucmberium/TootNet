using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Media : ApiBase
    {
        internal Media(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Upload a media attachment.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>Stream</c> / <c>IEnumerable&lt;byte&gt;</c> file (required)</para>
        /// <para>- <c>Stream</c> / <c>IEnumerable&lt;byte&gt;</c> thumbnail (optional)</para>
        /// <para>- <c>string</c> description (optional)</para>
        /// <para>- <c>string</c> focus (focal point: two floating points, comma-delimited) (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the media attachment object.</para>
        /// </returns>
        public Task<MediaAttachment> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<MediaAttachment>(MethodType.Post, "media", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <summary>
        /// <para>Upload a media attachment.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>Stream</c> / <c>IEnumerable&lt;byte&gt;</c> file (required)</para>
        /// <para>- <c>Stream</c> / <c>IEnumerable&lt;byte&gt;</c> thumbnail (optional)</para>
        /// <para>- <c>string</c> description (optional)</para>
        /// <para>- <c>string</c> focus (focal point: two floating points, comma-delimited) (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the media attachment object.</para>
        /// </returns>
        public Task<MediaAttachment> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<MediaAttachment>(MethodType.Post, "media", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Get media attachment.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the media attachment object.</para>
        /// </returns>
        public Task<MediaAttachment> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<MediaAttachment>(MethodType.Get, "media/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get media attachment.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the media attachment object.</para>
        /// </returns>
        public Task<MediaAttachment> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<MediaAttachment>(MethodType.Get, "media/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Update a media attachment.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> description (optional)</para>
        /// <para>- <c>string</c> focus (focal point: two floating points, comma-delimited) (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the media attachment object.</para>
        /// </returns>
        public Task<MediaAttachment> UpdateAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<MediaAttachment>(MethodType.Put, "media/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Update a media attachment.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> description (optional)</para>
        /// <para>- <c>string</c> focus (focal point: two floating points, comma-delimited) (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the media attachment object.</para>
        /// </returns>
        public Task<MediaAttachment> UpdateAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<MediaAttachment>(MethodType.Put, "media/{id}", "id", parameters);
        }
    }
}
