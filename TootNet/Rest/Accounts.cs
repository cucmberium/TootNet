using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Accounts : ApiBase
    {
        internal Accounts(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns a variety of information about the user specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Account>(MethodType.Get, "accounts/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a variety of information about the user specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Account>(MethodType.Get, "accounts/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Returns a representation of the requesting user if authentication was successful.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters avaiable in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> VerifyCredentialsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Get, "accounts/verify_credentials", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a representation of the requesting user if authentication was successful.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters avaiable in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> VerifyCredentialsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Get, "accounts/verify_credentials", parameters);
        }
    }
}
