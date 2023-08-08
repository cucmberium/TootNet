using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class OEmbed : ApiBase
    {
        internal OEmbed(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Get OEmbed info.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> url (required)</para>
        /// <para>- <c>int</c> maxwidth (optional)</para>
        /// <para>- <c>int</c> maxheight (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the oembed metadata object.</para>
        /// </returns>
        public Task<OEmbedMetadata> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<OEmbedMetadata>(MethodType.Get, "/api/oembed", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get OEmbed info.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> url (required)</para>
        /// <para>- <c>int</c> maxwidth (optional)</para>
        /// <para>- <c>int</c> maxheight (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the oembed metadata object.</para>
        /// </returns>
        public Task<OEmbedMetadata> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<OEmbedMetadata>(MethodType.Get, "/api/oembed", parameters);
        }
    }
}
