using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Lists : ApiBase
    {
        internal Lists(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Retrieving lists.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of list object.</para>
        /// </returns>
        public Task<Linked<List>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<List>>(MethodType.Get, "lists", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Retrieving lists.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of list object.</para>
        /// </returns>
        public Task<Linked<List>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<List>>(MethodType.Get, "lists", parameters);
        }

        /// <summary>
        /// <para>Retrieving accounts in a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> AccountsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/lists", "id", Utils.ExpressionToDictionary(parameters));
        }


        /// <summary>
        /// <para>Retrieving accounts in a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>int</c> limit (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list of account object.</para>
        /// </returns>
        public Task<Linked<Account>> AccountsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Get, "accounts/{id}/lists", "id", parameters);
        }

        /// <summary>
        /// <para>Retrieving a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> IdAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<List>(MethodType.Get, "lists/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Retrieving a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<List>(MethodType.Get, "lists/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Creating a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> title (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> CreateAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<List>(MethodType.Post, "lists", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Creating a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> title (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> CreateAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<List>(MethodType.Post, "lists", parameters);
        }

        /// <summary>
        /// <para>Updating a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> title (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<Linked<Account>> UpdateAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Put, "lists/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Updating a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> title (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<Linked<Status>> UpdateAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Put, "lists/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Deleting a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<Linked<Account>> DeleteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Account>>(MethodType.Delete, "lists/{id}", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Deleting a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<Linked<Status>> DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Linked<Status>>(MethodType.Delete, "lists/{id}", "id", parameters);
        }

        /// <summary>
        /// <para>Adding accounts to a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> account_ids (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> AddAccountAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<List>(MethodType.Post, "lists/{id}/accounts", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Deleting a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> account_ids (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> AddAccountAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<List>(MethodType.Post, "lists/{id}/accounts", "id", parameters);
        }

        /// <summary>
        /// <para>Adding accounts to a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> account_ids (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> DeleteAccountAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<List>(MethodType.Delete, "lists/{id}/accounts", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Deleting a list.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> account_ids (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns list object.</para>
        /// </returns>
        public Task<List> DeleteAccountAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<List>(MethodType.Delete, "lists/{id}/accounts", "id", parameters);
        }
    }
}
