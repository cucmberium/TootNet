using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class CustomEmojis : ApiBase
    {
        internal CustomEmojis(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns custom emojis that are available on the server.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of emoji object.</para>
        /// </returns>
        public Task<IEnumerable<CustomEmoji>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<CustomEmoji>>(MethodType.Get, "custom_emojis", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns custom emojis that are available on the server.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of emoji object.</para>
        /// </returns>
        public Task<IEnumerable<CustomEmoji>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<CustomEmoji>>(MethodType.Get, "custom_emojis", parameters);
        }
    }
}
