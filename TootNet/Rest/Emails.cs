using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;

namespace TootNet.Rest
{
    public class Emails : ApiBase
    {
        internal Emails(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Resend confirmation email.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> email (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task ConfirmationAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Post, "emails/confirmation", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Resend confirmation email.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> email (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task ConfirmationAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync(MethodType.Post, "emails/confirmation", parameters);
        }
    }
}
