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
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the attachment object.</para>
        /// </returns>
        public Task<Attachment> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Attachment>(MethodType.Post, "media", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Upload a media attachment.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>Stream</c> / <c>IEnumerable&lt;byte&gt;</c> file (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the attachment object.</para>
        /// </returns>
        public Task<Attachment> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Attachment>(MethodType.Post, "media", parameters);
        }
    }
}
