using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class CustomEmoji : ApiBase
    {
        internal CustomEmoji(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Custom emojis that are available on the server.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Emoji> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Emoji>(MethodType.Get, "custom_emojis", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Custom emojis that are available on the server.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Emoji> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Emoji>(MethodType.Get, "custom_emojis", parameters);
        }
    }
}
