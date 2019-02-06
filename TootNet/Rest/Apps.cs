using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Apps : ApiBase
    {
        internal Apps(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Create a new application to obtain OAuth2 credentials.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> client_name (required)</para>
        /// <para>- <c>string</c> redirect_uris (required)</para>
        /// <para>- <c>string</c> scopes (required)</para>
        /// <para>- <c>string</c> website (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the app object.</para>
        /// </returns>
        public Task<App> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<App>(MethodType.Post, "apps", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Create a new application to obtain OAuth2 credentials.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> client_name (required)</para>
        /// <para>- <c>string</c> redirect_uris (required)</para>
        /// <para>- <c>string</c> scopes (required)</para>
        /// <para>- <c>string</c> website (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the app object.</para>
        /// </returns>
        public Task<App> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<App>(MethodType.Post, "apps", parameters);
        }

        /// <summary>
        /// <para>Confirm that the app’s OAuth2 credentials work.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the app object.</para>
        /// </returns>
        public Task<Application> VerifyCredentialsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Application>(MethodType.Get, "apps/verify_credentials", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Confirm that the app’s OAuth2 credentials work.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the app object.</para>
        /// </returns>
        public Task<Application> VerifyCredentialsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Application>(MethodType.Get, "apps/verify_credentials", parameters);
        }
    }
}
