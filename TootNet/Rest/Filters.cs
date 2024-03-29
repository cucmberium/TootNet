// Generated by TootNet.Generator.  DO NOT EDIT!

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Filters : ApiBase
    {
        internal Filters(Tokens e) : base(e) { }

        /// <summary>
        /// <para>View all filters.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of filter object.</para>
        /// </returns>
        public Task<ListResponse<Objects.Filter>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Filter>>(MethodType.Get, "filters", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="GetAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.Filter>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Filter>>(MethodType.Get, "filters", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>View a specific filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Objects.Filter> IdAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Filter>(MethodType.Get, "filters/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="IdAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.Filter> IdAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Filter>(MethodType.Get, "filters/{id}", "id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Create a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> title (required)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> context (required)</para>
        /// <para>- <c>string</c> filter_action (optional)</para>
        /// <para>- <c>int</c> expires_in (optional)</para>
        /// <para>- <c>string</c> keywords_attributes[keyword] (optional)</para>
        /// <para>- <c>bool</c> keywords_attributes[whole_word] (optional)</para>
        /// <para>- <c>string</c> keywords_attributes[id] (optional)</para>
        /// <para>- <c>bool</c> keywords_attributes[_destroy] (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Objects.Filter> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Objects.Filter>(MethodType.Post, "filters", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="PostAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.Filter> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Objects.Filter>(MethodType.Post, "filters", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Update a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> title (optional)</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> context (optional)</para>
        /// <para>- <c>string</c> filter_action (optional)</para>
        /// <para>- <c>int</c> expires_in (optional)</para>
        /// <para>- <c>string</c> keywords_attributes[keyword] (optional)</para>
        /// <para>- <c>bool</c> keywords_attributes[whole_word] (optional)</para>
        /// <para>- <c>string</c> keywords_attributes[id] (optional)</para>
        /// <para>- <c>bool</c> keywords_attributes[_destroy] (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filter object.</para>
        /// </returns>
        public Task<Objects.Filter> PutAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Filter>(MethodType.Put, "filters/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="PutAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.Filter> PutAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.Filter>(MethodType.Put, "filters/{id}", "id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Delete a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "filters/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="DeleteAsync(Expression{Func{string, object}}[])"/>
        public Task DeleteAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "filters/{id}", "id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>View keywords added to a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> filter_id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of filterkeyword object.</para>
        /// </returns>
        public Task<ListResponse<Objects.FilterKeyword>> GetFilterKeywordsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ListResponse<Objects.FilterKeyword>>(MethodType.Get, "filters/{filter_id}/keywords", "filter_id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="GetFilterKeywordsAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.FilterKeyword>> GetFilterKeywordsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ListResponse<Objects.FilterKeyword>>(MethodType.Get, "filters/{filter_id}/keywords", "filter_id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Add a keyword to a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> filter_id (required)</para>
        /// <para>- <c>string</c> keyword (required)</para>
        /// <para>- <c>bool</c> whole_word (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filterkeyword object.</para>
        /// </returns>
        public Task<Objects.FilterKeyword> PostFilterKeywordsAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterKeyword>(MethodType.Post, "filters/{filter_id}/keywords", "filter_id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="PostFilterKeywordsAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.FilterKeyword> PostFilterKeywordsAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterKeyword>(MethodType.Post, "filters/{filter_id}/keywords", "filter_id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>View a single keyword.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filterkeyword object.</para>
        /// </returns>
        public Task<Objects.FilterKeyword> GetKeywordAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterKeyword>(MethodType.Get, "filters/keywords/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="GetKeywordAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.FilterKeyword> GetKeywordAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterKeyword>(MethodType.Get, "filters/keywords/{id}", "id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Edit a keyword within a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> keyword (required)</para>
        /// <para>- <c>bool</c> whole_word (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filterkeyword object.</para>
        /// </returns>
        public Task<Objects.FilterKeyword> PutKeywordAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterKeyword>(MethodType.Put, "filters/keywords/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="PutKeywordAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.FilterKeyword> PutKeywordAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterKeyword>(MethodType.Put, "filters/keywords/{id}", "id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Remove keywords from a filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteKeywordAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "filters/keywords/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="DeleteKeywordAsync(Expression{Func{string, object}}[])"/>
        public Task DeleteKeywordAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "filters/keywords/{id}", "id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>View all status filters.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> filter_id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of filterstatus object.</para>
        /// </returns>
        public Task<ListResponse<Objects.FilterStatus>> GetFilterStatusesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ListResponse<Objects.FilterStatus>>(MethodType.Get, "filters/{filter_id}/statuses", "filter_id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="GetFilterStatusesAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.FilterStatus>> GetFilterStatusesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<ListResponse<Objects.FilterStatus>>(MethodType.Get, "filters/{filter_id}/statuses", "filter_id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Add a status to a filter group.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> filter_id (required)</para>
        /// <para>- <c>long</c> status_id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filterstatus object.</para>
        /// </returns>
        public Task<Objects.FilterStatus> PostFilterStatusesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterStatus>(MethodType.Post, "filters/{filter_id}/statuses", "filter_id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="PostFilterStatusesAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.FilterStatus> PostFilterStatusesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterStatus>(MethodType.Post, "filters/{filter_id}/statuses", "filter_id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>View a single status filter.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filterstatus object.</para>
        /// </returns>
        public Task<Objects.FilterStatus> GetFilterStatusAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterStatus>(MethodType.Get, "filters/statuses/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="GetFilterStatusAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.FilterStatus> GetFilterStatusAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterStatus>(MethodType.Get, "filters/statuses/{id}", "id", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>Remove a status from a filter group.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the filterstatus object.</para>
        /// </returns>
        public Task<Objects.FilterStatus> DeleteFilterStatusAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterStatus>(MethodType.Delete, "filters/statuses/{id}", "id", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="DeleteFilterStatusAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.FilterStatus> DeleteFilterStatusAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync<Objects.FilterStatus>(MethodType.Delete, "filters/statuses/{id}", "id", parameters, apiVersion: "v2");
        }
    }
}
