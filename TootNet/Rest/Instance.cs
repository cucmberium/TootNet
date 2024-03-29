// Generated by TootNet.Generator.  DO NOT EDIT!

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Instance : ApiBase
    {
        internal Instance(Tokens e) : base(e) { }

        /// <summary>
        /// <para>View server information.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<Objects.Instance> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Objects.Instance>(MethodType.Get, "instance", Utils.ExpressionToDictionary(parameters), apiVersion: "v2");
        }

        /// <inheritdoc cref="GetAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.Instance> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Objects.Instance>(MethodType.Get, "instance", parameters, apiVersion: "v2");
        }

        /// <summary>
        /// <para>List of connected domains.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of string object.</para>
        /// </returns>
        public Task<ListResponse<string>> PeersAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<string>>(MethodType.Get, "instance/peers", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PeersAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<string>> PeersAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<string>>(MethodType.Get, "instance/peers", parameters);
        }

        /// <summary>
        /// <para>Weekly activity.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of activity object.</para>
        /// </returns>
        public Task<ListResponse<Objects.Activity>> ActivityAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Activity>>(MethodType.Get, "instance/activity", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="ActivityAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.Activity>> ActivityAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Activity>>(MethodType.Get, "instance/activity", parameters);
        }

        /// <summary>
        /// <para>List of rules.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of rule object.</para>
        /// </returns>
        public Task<ListResponse<Objects.Rule>> RulesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Rule>>(MethodType.Get, "instance/rules", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="RulesAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.Rule>> RulesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.Rule>>(MethodType.Get, "instance/rules", parameters);
        }

        /// <summary>
        /// <para>View moderated servers.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of domainblock object.</para>
        /// </returns>
        public Task<ListResponse<Objects.DomainBlock>> DomainBlocksAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.DomainBlock>>(MethodType.Get, "instance/domain_blocks", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="DomainBlocksAsync(Expression{Func{string, object}}[])"/>
        public Task<ListResponse<Objects.DomainBlock>> DomainBlocksAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<ListResponse<Objects.DomainBlock>>(MethodType.Get, "instance/domain_blocks", parameters);
        }

        /// <summary>
        /// <para>View extended description.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the extendeddescription object.</para>
        /// </returns>
        public Task<Objects.ExtendedDescription> ExtendedDescriptionAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Objects.ExtendedDescription>(MethodType.Get, "instance/extended_description", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="ExtendedDescriptionAsync(Expression{Func{string, object}}[])"/>
        public Task<Objects.ExtendedDescription> ExtendedDescriptionAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Objects.ExtendedDescription>(MethodType.Get, "instance/extended_description", parameters);
        }

        /// <summary>
        /// <para>View translation languages.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the dict string,(array string) object.</para>
        /// </returns>
        public Task<DictResponse<string, IEnumerable<string>>> TranslationLanguagesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<DictResponse<string, IEnumerable<string>>>(MethodType.Get, "instance/translation_languages", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="TranslationLanguagesAsync(Expression{Func{string, object}}[])"/>
        public Task<DictResponse<string, IEnumerable<string>>> TranslationLanguagesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<DictResponse<string, IEnumerable<string>>>(MethodType.Get, "instance/translation_languages", parameters);
        }
    }
}
