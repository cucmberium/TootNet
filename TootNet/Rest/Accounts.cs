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
        public Task<Account> IdAsync(params Expression<Func<string, object>>[] parameters)
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
        public Task<Account> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Account>(MethodType.Get, "accounts/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Create new account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> username (required)</para>
        /// <para>- <c>string</c> email (required)</para>
        /// <para>- <c>string</c> password (required)</para>
        /// <para>- <c>bool</c> agreement (required)</para>
        /// <para>- <c>string</c> locale (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the token object.</para>
        /// </returns>
        public Task<Token> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Token>(MethodType.Post, "accounts", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Create new account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> username (required)</para>
        /// <para>- <c>string</c> email (required)</para>
        /// <para>- <c>string</c> password (required)</para>
        /// <para>- <c>bool</c> agreement (required)</para>
        /// <para>- <c>string</c> locale (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the token object.</para>
        /// </returns>
        public Task<Token> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Token>(MethodType.Post, "accounts", parameters);
        }

        /// <summary>
        /// <para>Returns a representation of the requesting user if authentication was successful.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
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
        /// <para>- No parameters available in this method.</para>
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

        /// <summary>
        /// <para>Updating the current user credentials.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> display_name (optional)</para>
        /// <para>- <c>string</c> note (optional)</para>
        /// <para>- <c>string</c> avatar (base64Encoded image string) (optional)</para>
        /// <para>- <c>string</c> header (base64Encoded image string) (optional)</para>
        /// <para>- <c>bool</c> locked (optional)</para>
        /// <para>- <c>string</c> source[privacy] (optional)</para>
        /// <para>- <c>string</c> source[sensitive] (optional)</para>
        /// <para>- <c>string</c> source[language] (optional)</para>
        /// <para>- <c>string</c> fields_attributes[0][name] ([0]-[3] is allowed) (optional)</para>
        /// <para>- <c>string</c> fields_attributes[0][value] ([0]-[3] is allowed) (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> UpdateCredentialsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Patch, "accounts/update_credentials", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Updating the current user credentials.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> display_name (optional)</para>
        /// <para>- <c>string</c> note (optional)</para>
        /// <para>- <c>string</c> avatar (base64Encoded image string) (optional)</para>
        /// <para>- <c>string</c> header (base64Encoded image string) (optional)</para>
        /// <para>- <c>bool</c> locked (optional)</para>
        /// <para>- <c>string</c> source[privacy] (optional)</para>
        /// <para>- <c>string</c> source[sensitive] (optional)</para>
        /// <para>- <c>string</c> source[language] (optional)</para>
        /// <para>- <c>string</c> fields_attributes[0][name] ([0]-[3] is allowed) (optional)</para>
        /// <para>- <c>string</c> fields_attributes[0][value] ([0]-[3] is allowed) (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> UpdateCredentialsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Patch, "accounts/update_credentials", parameters);
        }

        /// <summary>
        /// <para>Get an account's followers information.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> FollowersAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/followers", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get an account's followers information.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> FollowersAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/followers", "id", parameters);
        }

        /// <summary>
        /// <para>Get who account is following.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> FollowingAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/following", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get who account is following.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> FollowingAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/following", "id", parameters);
        }

        /// <summary>
        /// <para>Get an account's statuses.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// <para>- <c>bool</c> pinned (optional)</para>
        /// <para>- <c>bool</c> exclude_replies (optional)</para>
        /// <para>- <c>bool</c> exclude_reblogs (optional)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> StatusesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Get, "accounts/{id}/statuses", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get an account's statuses.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// <para>- <c>bool</c> pinned (optional)</para>
        /// <para>- <c>bool</c> exclude_replies (optional)</para>
        /// <para>- <c>bool</c> exclude_reblogs (optional)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of status object.</para>
        /// </returns>
        public Task<Linked<Status>> StatusesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Get, "accounts/{id}/statuses", "id", parameters);
        }

        /// <summary>
        /// <para>Follow an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>bool</c> reblogs (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> FollowAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/follow", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Follow an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>bool</c> reblogs (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> FollowAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/follow", "id", parameters);
        }

        /// <summary>
        /// <para>Unfollow an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> UnfollowAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/unfollow", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Unfollow an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> UnfollowAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/unfollow", "id", parameters);
        }
        
        /// <summary>
        /// <para>Returns relationship between current user and user specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of relationship object.</para>
        /// </returns>
        public Task<Linked<Relationship>> RelationshipsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Relationship>>(MethodType.Get, "accounts/relationships", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns relationship between current user and user specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of relationship object.</para>
        /// </returns>
        public Task<Linked<Relationship>> RelationshipsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Relationship>>(MethodType.Get, "accounts/relationships", parameters);
        }

        /// <summary>
        /// <para>Search account specified by the required q parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>bool</c> resolve (optional)</para>
        /// <para>- <c>bool</c> following (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> SearchAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Account>>(MethodType.Get, "accounts/search", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Search account specified by the required q parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>bool</c> resolve (optional)</para>
        /// <para>- <c>bool</c> following (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> SearchAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Account>>(MethodType.Get, "accounts/search", parameters);
        }
    }
}
