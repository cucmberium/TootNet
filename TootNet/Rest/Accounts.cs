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
        /// <para>Register an account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> username (required)</para>
        /// <para>- <c>string</c> email (required)</para>
        /// <para>- <c>string</c> password (required)</para>
        /// <para>- <c>bool</c> agreement (required)</para>
        /// <para>- <c>string</c> locale (required)</para>
        /// <para>- <c>string</c> reason (optional)</para>
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

        /// <inheritdoc cref="PostAsync(Expression{Func{string, object}}[])"/>
        public Task<Token> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Token>(MethodType.Post, "accounts", parameters);
        }

        /// <summary>
        /// <para>Verify account credentials.</para>
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

        /// <inheritdoc cref="VerifyCredentialsAsync(Expression{Func{string, object}}[])"/>
        public Task<Account> VerifyCredentialsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Get, "accounts/verify_credentials", parameters);
        }

        /// <summary>
        /// <para>Update account credentials.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> display_name (optional)</para>
        /// <para>- <c>string</c> note (optional)</para>
        /// <para>- <c>string</c> avatar (base64Encoded image string) (optional)</para>
        /// <para>- <c>string</c> header (base64Encoded image string) (optional)</para>
        /// <para>- <c>bool</c> locked (optional)</para>
        /// <para>- <c>bool</c> bot (optional)</para>
        /// <para>- <c>bool</c> discoverable (optional)</para>
        /// <para>- <c>string</c> fields_attributes[0][name] ([0]-[3] is allowed) (optional)</para>
        /// <para>- <c>string</c> fields_attributes[0][value] ([0]-[3] is allowed) (optional)</para>
        /// <para>- <c>string</c> source[privacy] (optional)</para>
        /// <para>- <c>string</c> source[sensitive] (optional)</para>
        /// <para>- <c>string</c> source[language] (optional)</para>
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

        /// <inheritdoc cref="UpdateCredentialsAsync(Expression{Func{string, object}}[])"/>
        public Task<Account> UpdateCredentialsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Patch, "accounts/update_credentials", parameters);
        }

        /// <summary>
        /// <para>Return a variety of information about the user specified by the required id parameter.</para>
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

        /// <inheritdoc cref="IdAsync(Expression{Func{string, object}}[])"/>
        public Task<Account> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Account>(MethodType.Get, "accounts/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Get account's statuses.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// <para>- <c>bool</c> exclude_replies (optional)</para>
        /// <para>- <c>bool</c> exclude_reblogs (optional)</para>
        /// <para>- <c>bool</c> pinned (optional)</para>
        /// <para>- <c>string</c> tagged (optional)</para>
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

        /// <inheritdoc cref="StatusesAsync(Expression{Func{string, object}}[])"/>
        public Task<Linked<Status>> StatusesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Get, "accounts/{id}/statuses", "id", parameters);
        }

        /// <summary>
        /// <para>Get account's followers.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
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

        /// <inheritdoc cref="FollowersAsync(Expression{Func{string, object}}[])"/>
        public Task<Linked<Account>> FollowersAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/followers", "id", parameters);
        }

        /// <summary>
        /// <para>Get account's following.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>long</c> max_id (optional)</para>
        /// <para>- <c>long</c> since_id (optional)</para>
        /// <para>- <c>long</c> min_id (optional)</para>
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

        /// <inheritdoc cref="FollowingAsync(Expression{Func{string, object}}[])"/>
        public Task<Linked<Account>> FollowingAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/following", "id", parameters);
        }

        /// <summary>
        /// <para>Get list containing target account.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of list object.</para>
        /// </returns>
        public Task<IEnumerable<List>> ListsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<IEnumerable<List>>(MethodType.Get, "accounts/{id}/lists", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="ListsAsync(Expression{Func{string, object}}[])"/>
        public Task<IEnumerable<List>> ListsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<IEnumerable<List>>(MethodType.Get, "accounts/{id}/lists", "id", parameters);
        }

        /// <summary>
        /// <para>Follow account.</para>
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

        /// <inheritdoc cref="FollowAsync(Expression{Func{string, object}}[])"/>
        public Task<Relationship> FollowAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/follow", "id", parameters);
        }

        /// <summary>
        /// <para>Unfollow account.</para>
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

        /// <inheritdoc cref="UnfollowAsync(Expression{Func{string, object}}[])"/>
        public Task<Relationship> UnfollowAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/unfollow", "id", parameters);
        }

        /// <summary>
        /// <para>Remove account from followers.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> RemoveFromFollowersAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/remove_from_followers", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="RemoveFromFollowersAsync(Expression{Func{string, object}}[])"/>
        public Task<Relationship> RemoveFromFollowersAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/remove_from_followers", "id", parameters);
        }

        /// <summary>
        /// <para>Set private note on profile.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> comment (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the relationship object.</para>
        /// </returns>
        public Task<Relationship> NoteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/note", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="NoteAsync(Expression{Func{string, object}}[])"/>
        public Task<Relationship> NoteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Relationship>(MethodType.Post, "accounts/{id}/note", "id", parameters);
        }

        /// <summary>
        /// <para>Return relationship between current user and user specified by the required id parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of relationship object.</para>
        /// </returns>
        public Task<IEnumerable<Relationship>> RelationshipsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Relationship>>(MethodType.Get, "accounts/relationships", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="RelationshipsAsync(Expression{Func{string, object}}[])"/>
        public Task<IEnumerable<Relationship>> RelationshipsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Relationship>>(MethodType.Get, "accounts/relationships", parameters);
        }

        /// <summary>
        /// <para>Find familiar followers.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of familiar follower object.</para>
        /// </returns>
        public Task<IEnumerable<FamiliarFollower>> FamiliarFollowersAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<FamiliarFollower>>(MethodType.Get, "accounts/familiar_followers", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="FamiliarFollowersAsync(Expression{Func{string, object}}[])"/>
        public Task<IEnumerable<FamiliarFollower>> FamiliarFollowersAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<FamiliarFollower>>(MethodType.Get, "accounts/familiar_followers", parameters);
        }

        /// <summary>
        /// <para>Search account specified by the required q parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// <para>- <c>bool</c> resolve (optional)</para>
        /// <para>- <c>bool</c> following (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Account>> SearchAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Account>>(MethodType.Get, "accounts/search", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Search account specified by the required q parameter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> q (required)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// <para>- <c>int</c> offset (optional)</para>
        /// <para>- <c>bool</c> resolve (optional)</para>
        /// <para>- <c>bool</c> following (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of account object.</para>
        /// </returns>
        public Task<IEnumerable<Account>> SearchAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Account>>(MethodType.Get, "accounts/search", parameters);
        }

        /// <summary>
        /// <para>Lookup account ID from Webfinger address.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> acct (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> LookupAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Get, "accounts/lookup", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Lookup account ID from Webfinger address.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> acct (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the account object.</para>
        /// </returns>
        public Task<Account> LookupAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Account>(MethodType.Get, "accounts/lookup", parameters);
        }
    }
}
