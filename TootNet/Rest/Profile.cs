// Generated by TootNet.Generator.  DO NOT EDIT!

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Profile : ApiBase
    {
        internal Profile(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Deletes the avatar associated with the user's profile</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the credentialaccount object.</para>
        /// </returns>
        public Task<Objects.CredentialAccount> DeleteAvatarAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Objects.CredentialAccount>(MethodType.Delete, "profile/avatar", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="DeleteAvatarAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.CredentialAccount> DeleteAvatarAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Objects.CredentialAccount>(MethodType.Delete, "profile/avatar", parameters);
        }

        /// <summary>
        /// <para>Deletes the header image associated with the user's profile</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the credentialaccount object.</para>
        /// </returns>
        public Task<Objects.CredentialAccount> DeleteHeaderAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Objects.CredentialAccount>(MethodType.Delete, "profile/header", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="DeleteHeaderAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.CredentialAccount> DeleteHeaderAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Objects.CredentialAccount>(MethodType.Delete, "profile/header", parameters);
        }
    }
}
